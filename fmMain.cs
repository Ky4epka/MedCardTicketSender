using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Serialization;
using System.Text.RegularExpressions;

namespace TicketSender
{

    public enum MessageType
    {
        Notify,
        True,
        False
    }


    public partial class fmMain : Form
    {

        public const string GROUP_MARK = "%group:([0-9]*)%";

        public SettingsClass Settings { get; private set; }
        protected bool iLoading = false;
        protected bool iMessageVisible = false;
        protected MessageType iMessageType = MessageType.Notify;
        protected string iMessage = "";
        protected bool iQueueToggle = false;
        protected string iLastClipboardText = "";
        protected bool iInvalidField = false;
        protected bool iMonitorBufferActive = false;
        protected bool iToggleTopmost = false;

        public bool MonitorBufferActive 
        { 
            get => iMonitorBufferActive; 
            set 
            {
                Settings.IsClipboardMonitorActive = value;
                iMonitorBufferActive = value; 
                UpdateUI(); 
            } 
        }

        public bool ToggleTopmost
        {
            get => iToggleTopmost;
            set
            {
                Settings.TopmostForm = value;
                iToggleTopmost = value;
                UpdateUI();
            }
        }


        public fmMain()
        {
            InitializeComponent();
            LoadSettings();
            ApplySettings();

            TicketManager.Instance.OnSendingStart += (s) =>
            {
                ShowMessage("Загрузка", MessageType.Notify);
            };

            TicketManager.Instance.OnSendingSuccess += (s) =>
            {
                ShowMessage("OK", MessageType.True);
                MessageBox.Show("Отправлено успешно.", "Статус", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };

            TicketManager.Instance.OnSendingError += (s, e) =>
            {
                ShowMessage(e, MessageType.False);
            };

            tbFullNameField.OnTextValidated += TbFullNameField_OnTextValidated;
            tbBirthYearField.OnTextValidated += TbFullNameField_OnTextValidated;
            tbAddress.OnTextValidated += TbFullNameField_OnTextValidated;
            tbTargetCabinetField.OnTextValidated += TbFullNameField_OnTextValidated;

            UpdateUI();
        }

        private void TbFullNameField_OnTextValidated(Control arg1, bool arg2, string arg3)
        {
            UpdateUI();
        }

        public void PushFormData(Dictionary<string, string> formData)
        {
            RecurseControls(this, (c) => {
                if (c.Tag == null) return;

                string key = ((string)c.Tag).Trim();
                string value;
                formData.TryGetValue(key, out value);

                if (key.Length > 0)
                {
                    if (c is CheckBox)
                        (c as CheckBox).Checked = (value == "1");
                    else
                    {
                        c.Text = value;
                    }
                }
            });

            UpdateUI();
        }

        public Dictionary<string, string> PopFormData()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            RecurseControls(this, (c) => {
                if (c.Tag == null) return;

                string key = ((string)c.Tag).Trim();

                if (key.Length > 0)
                {
                    if (c is CheckBox)
                        result[key] = (c as CheckBox).Checked ? "1" : "0";
                    else
                        result[key] = c.Text;
                }
            });

            return result;
        }

        public void ShowMessage(string message, MessageType messageType)
        {
            iMessageVisible = true;
            iMessage = message;
            iMessageType = messageType;
            tmrMessageController.Enabled = iMessageVisible;
            tmrMessageController.Interval = 5000;
            UpdateUI();
        }

        public void HideMessage()
        {
            iMessageVisible = false;
            UpdateUI();
        }

        public void ParseClipboard(string clipboardText)
        {
            /*
             * 
            fieldsTemplates.Add("magickey", "(ТАЛОН НА ПРИЕМ К ВРАЧУ №)(.+)%group:1%");
            fieldsTemplates.Add("FullName", "(ФИО\\s*:\\s*)([\\w\\s]+$)%group:2%");
            fieldsTemplates.Add("BirthDate", "(Дата рождения\\s*:\\s*)([0-9\\.]+)%group:2%");
            fieldsTemplates.Add("Address", "(Адрес регистрации\\s*:\\s*)([\\W\\w\\n]+)(Контактные данные)%group:2%");

             */

            Dictionary<string, string> templates = new Dictionary<string, string>()
            {
                { "magickey", "(ТАЛОН НА ПРИЕМ К ВРАЧУ №)(.+)%group:1%"},
                //
                { tbFullNameField.Tag as string, "(ФИО\\s*:\\s*)([А-Яа-я\\v$]+)%group:2%" },
                { tbBirthYearField.Tag as string, "(Дата рождения\\s*:\\s*)([0-9\\.]+)%group:2%"},
                { tbAddress.Tag as string, "(Адрес регистрации\\s*:\\s*)([\\W\\w\\n]+)(Контактные данные)%group:2%"}
            };

            var result = ParseTextAsKeyValues(templates, clipboardText);

            string field;

            if (!result.TryGetValue("magickey", out field))
                return;

            if (result.TryGetValue(tbFullNameField.Tag as string, out field))
            {
                string res = "";

                foreach (var c in field)
                {
                    if (char.IsUpper(c))
                        res += " ";

                    res += c;
                }


                tbFullNameField.Text = res;
            }

            if (result.TryGetValue(tbBirthYearField.Tag as string, out field))
            {
                DateTime d;

                if (DateTime.TryParse(field, out d))
                {
                    tbBirthYearField.Text = d.Year.ToString();
                }
            }

            if (result.TryGetValue(tbAddress.Tag as string, out field))
                tbAddress.Text = field;
        }

        private string extractValueFromMatch(string template, Match match, int groupIndex)
        {
            if (!match.Success)
                return "";

            string result = "";

            if ((groupIndex >= 0) && (groupIndex < match.Groups.Count))
                result = match.Groups[groupIndex].Value;
            else
                result = match.Value;

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fieldsTempaltes">Dictionary of fields templates where: key - field name, value - field template, place a %value% in target group to get a needed value</param>
        /// <param name="sourceText"></param>
        /// <returns>Dictionary with data of finded fields where: key - field name, value - parsed text on template</returns>
        private Dictionary<string, string> ParseTextAsKeyValues(Dictionary<string, string> fieldsTempaltes, string sourceText)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            foreach (var fieldTemplate in fieldsTempaltes)
            {
                string template = fieldTemplate.Value;
                //Finding special groupid index marker in field template
                Match match = Regex.Match(template, GROUP_MARK, RegexOptions.IgnoreCase | RegexOptions.Multiline);
                int groupIndex = 0;

                if (match.Success)
                {
                    if (!int.TryParse(match.Groups[1].Value, out groupIndex))
                        groupIndex = 0;

                    template = template.Replace(match.Value, "");
                }

                match = Regex.Match(sourceText, template, RegexOptions.IgnoreCase | RegexOptions.Multiline);

                if (!match.Success)
                    continue;

                result.Add(fieldTemplate.Key, extractValueFromMatch(template, match, groupIndex));
            }

            return result; 
        }


        public bool CheckFields()
        {
            tbFullNameField.Text = tbFullNameField.Text.Trim();
            return true;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (new SettingsDialog(this, Settings).ShowDialog(this) == DialogResult.OK)
            {
                SaveSettings();
                ApplySettings();
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (!CheckFields())
                return;

            TicketClass ticket = new TicketClass();
            ticket.Address = tbAddress.Text;
            ticket.BirthYear = tbBirthYearField.Text;
            ticket.Departament = cbDepartamentField.SelectedValue?.ToString() ?? "";
            ticket.FullName = tbFullNameField.Text;
            ticket.SendTime = DateTime.Now;
            ticket.TargetCabinet = tbTargetCabinetField.Text;

            tbAddress.Text = "";
            tbBirthYearField.Text = "";
            tbFullNameField.Text = "";

            if (!TicketManager.Instance.AddTicketToQueue(ticket))
                MessageBox.Show(this, "Не удалось добавить талон! Такие данные уже присутствуют в очереди.");
        }

        protected void RecurseControls(Control baseControl, Action<Control> action)
        {
            if (baseControl == null)
                return;

            action(baseControl);

            if (!baseControl.HasChildren)
                return;

            foreach (Control control in baseControl.Controls)
            {
                RecurseControls(control, action);
            }
        }

        protected bool HasCorrectFields()
        {
            return
                tbFullNameField.HasCorrectValue &&
                tbBirthYearField.HasCorrectValue &&
                tbAddress.HasCorrectValue &&
                tbTargetCabinetField.HasCorrectValue;
        }

        protected void UpdateUI()
        {
            btSend.Enabled = !iLoading && HasCorrectFields();
            cbDepartamentField.Enabled = !cbLockDepartamentField.Checked;

            Color messageColor = Color.Black;

            switch (iMessageType)
            {
                case MessageType.Notify:
                    messageColor = Color.Black;
                    break;
                case MessageType.True:
                    messageColor = Color.Green;
                    break;
                case MessageType.False:
                    messageColor = Color.Red;
                    break;
            }

            lbMessage.Text = iMessage;
            lbMessage.ForeColor = messageColor;
            lbMessage.Visible = iMessageVisible;

            if (iQueueToggle)
                btToggleQueue.Text = "Скрыть очередь";
            else
                btToggleQueue.Text = "Показать очередь";

            pTicketManager.Visible = iQueueToggle;

            tmrClipboardMonitor.Enabled = iMonitorBufferActive;

            if (iMonitorBufferActive)
                miToggleBufferMonitor.Text = "Выключить монитор буфера обмена";
            else
                miToggleBufferMonitor.Text = "Включить монитор буфера обмена";

            TopMost = iToggleTopmost;

            if (iToggleTopmost)
                miToggleTopForm.Text = "Выключить режим поверх всех окон";
            else
                miToggleTopForm.Text = "Включить режим поверх всех окон";
        }

        public void ApplySettings()
        {
            ToggleTopmost = Settings.TopmostForm;
            MonitorBufferActive = Settings.IsClipboardMonitorActive;
            dsDepartamentData.Clear();
            dsDepartamentData.Merge(Settings.DepartamentData);
            PushFormData(Settings.formDataAsDict);
        }

        public void LoadSettings()
        {
            Settings = SettingsClass.LoadFromFile("settings.cfg");
        }

        public void SaveSettings()
        {
            Settings.formDataAsDict = PopFormData();
            SettingsClass.SaveToFile("settings.cfg", Settings);
        }


        private void fmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.formDataAsDict = PopFormData();
            SaveSettings();
        }

        private void cbLockDepartamentField_CheckedChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void tmrMessageController_Tick(object sender, EventArgs e)
        {
            HideMessage();
            tmrMessageController.Enabled = false;
        }

        private void tmrQueueProcessor_Tick(object sender, EventArgs e)
        {
            TicketManager.Instance.ProcessQueue();
        }

        private void ticketManagerUI2_Load(object sender, EventArgs e)
        {

        }

        private void btToggleQueue_Click(object sender, EventArgs e)
        {
            iQueueToggle = !iQueueToggle;
            UpdateUI();
        }

        private void tmrClipboardMonitor_Tick(object sender, EventArgs e)
        {
            string clipboardText = Clipboard.GetText();

            if (string.IsNullOrEmpty(clipboardText))
                return;

            if (clipboardText.Equals(iLastClipboardText))
                return;

            iLastClipboardText = clipboardText;
            ParseClipboard(Clipboard.GetText());
        }

        private void miToggleBufferMonitor_Click(object sender, EventArgs e)
        {
            MonitorBufferActive = !MonitorBufferActive;
        }

        private void miMinimizeWindow_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void miToggleTopForm_Click(object sender, EventArgs e)
        {
            ToggleTopmost = !ToggleTopmost;
        }
    }
}
