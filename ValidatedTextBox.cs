using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace TicketSender
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender">Sender control</param>
    /// <param name="inputText">Input text</param>
    /// <returns>Return: null or empty string if no errors</returns>
    public delegate string TextValidator(Control sender, string inputText);

    public partial class ValidatedTextBox : UserControl
    {
        [Category("Appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue("Заголовок")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Заголовок элемента")]
        public string Caption
        {
            get => lbCaption.Text;
            set
            {
                iCaption = value;
                UpdateUI();
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Показывать заголовок элемента")]
        public bool ShowCaption
        {
            get => iShowCaption;
            set
            {
                iShowCaption = value;
                UpdateUI();
            }
        }

        [Category("Appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue("text")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Текст элемента")]
        public override string Text
        {
            get => tbText.Text;
            set
            {
                if (UseAvailabledCharList)
                    value = SanitizeStringByAvaiabledCharList(value);

                HasCorrectValue = false;

                string errorResult = (TextValidator != null) ? TextValidator(this, value) : "";
                bool isEmpty = false;

                if (string.IsNullOrEmpty(errorResult) && string.IsNullOrEmpty(value) && !CanIsEmpty)
                {
                    errorResult = $"Поле '{Caption}' не может быть пустым";
                    isEmpty = true;
                }

                if (string.IsNullOrEmpty(errorResult) || isEmpty)
                {
                    iHasActiveError = isEmpty;
                    iErrorText = errorResult;
                    iAntiloop = true;
                    try
                    {
                        HasCorrectValue = true && !isEmpty;
                        iText = value;
                        UpdateUI();
                        OnTextValidated?.Invoke(this, true, "");
                    }
                    finally
                    {
                        iAntiloop = false;
                    }
                }
                else
                {
                    iHasActiveError = true;
                    iErrorText = errorResult;
                    iAntiloop = true;
                    try
                    {
                        UpdateUI();
                    }
                    finally
                    {
                        iAntiloop = false;
                    }
                    OnTextValidated?.Invoke(this, false, errorResult);
                }
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Отображать текст ошибки под элементом")]
        public bool ShowError
        {
            get => iShowError;
            set
            {
                iShowError = value;
                UpdateUI();
            }
        }
        [Category("Action")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Событие, возникающее после проверки текста")]
        public event Action<Control, bool, string> OnTextValidated = null;
        [Category("Action")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(null)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Метод проверки текста")]
        public event TextValidator TextValidator = null;
        [Category("Appearance")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(HorizontalAlignment.Left)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Горизонтальное выравнивание текста")]
        public HorizontalAlignment TextAlign { get => tbText.TextAlign; set => tbText.TextAlign = value; }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Доступный набор символов (в т.ч. спец символы через \\)")]
        public string AvailabledCharList
        {
            get => iAvailableCharList;
            set
            {
                iAvailableCharList = value;
                Text = Text;
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Использовать доступный набор символов")]
        public bool UseAvailabledCharList
        {
            get => iUseAvailableCharList;
            set
            {
                iUseAvailableCharList = value;
                Text = Text;
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Показывать ошибку при некорректном вводе символа")]
        public bool ShowErrorForIncorrectInputKey
        {
            get => iShowErrorForIncorrectInputKey;
            set
            {
                iShowErrorForIncorrectInputKey = value;
                UpdateUI();
            }
        }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue("")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Понятный текст ошибки при неверном вводе")]
        public string ErrorTextForIncorrectInputKey { get; set; }

        [Category("Behavior")]
        [Browsable(true)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [DefaultValue(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Description("Может быть пустым")]
        public bool CanIsEmpty
        {
            get => iCanIsEmpty;
            set
            {
                iCanIsEmpty = value;
                Text = Text;
            }
        }

        public bool HasCorrectValue { get; private set; }

        protected string iCaption = "";
        protected string iText = "";
        protected bool iHasActiveError = false;
        protected string iErrorText = "";
        protected bool iAntiloop = false;
        protected bool iShowCaption = false;
        protected bool iShowError = false;
        protected bool iUseAvailableCharList = false;
        protected string iAvailableCharList = "";
        protected bool iShowErrorForIncorrectInputKey = false;
        protected bool iCanIsEmpty = false;

        public ValidatedTextBox()
        {
            InitializeComponent();
            UpdateUI();
        }

        private void UpdateUI()
        {
            tlpContainer.SuspendLayout();
            lbCaption.Visible = iShowCaption;
            lbCaption.Text = iCaption;
            lbCaption.Size = new Size(lbCaption.Size.Width, TextRenderer.MeasureText(iCaption, lbCaption.Font, lbCaption.Size, TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.WordBreak).Height);
            lbError.Visible = iHasActiveError && iShowError;

            if (iHasActiveError)
            {
                lbError.Text = iErrorText;
                lbError.Size = new Size(lbError.Size.Width, TextRenderer.MeasureText(iErrorText, lbError.Font, lbError.Size + new Size(0, int.MaxValue), TextFormatFlags.GlyphOverhangPadding | TextFormatFlags.WordBreak).Height);
            }

            tbText.Text = iText;
            tlpContainer.ResumeLayout(true);
        }

        private string SanitizeStringByAvaiabledCharList(string input)
        {
            if (input == null)
                return "";

            string result = "";

            foreach (var c in input)
            {
                if (Regex.IsMatch(new string(c, 1), AvailabledCharList))
                    result += c;
            }

            return result;
        }

        private void tbText_TextChanged(object sender, EventArgs e)
        {
            if (iAntiloop)
                return;

            Text = tbText.Text;
        }

        private void ValidatedTextBox_SizeChanged(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void ValidatedTextBox_Click(object sender, EventArgs e)
        {
            tbText.Focus();
        }

        private void tbText_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (UseAvailabledCharList)
            {
                switch (e.KeyChar)
                {
                    case (char)(Keys.Back):
                        e.Handled = false;
                        return;
                    case (char)(Keys.Return):
                        e.Handled = true;
                        Parent?.SelectNextControl(ActiveControl, true, false, true, true);
                        return;
                }

                e.Handled = !Regex.IsMatch(new string(e.KeyChar, 1), AvailabledCharList);

                if (e.Handled && ShowErrorForIncorrectInputKey)
                {
                    iHasActiveError = true;
                    iErrorText = ErrorTextForIncorrectInputKey;
                    UpdateUI();
                }
            }
        }

        private void tbText_Validated(object sender, EventArgs e)
        {
            Text = Text;
        }
    }
}
