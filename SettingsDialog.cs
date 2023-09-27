using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSender
{
    public partial class SettingsDialog : Form
    {
        public SettingsClass Settings { get; set; }

        public SettingsDialog(IWin32Window owner, SettingsClass settings)
        {
            InitializeComponent();
            Settings = settings;
            PushData(settings);
            //ShowDialog(owner);
        }

        protected void PushData(SettingsClass settings)
        {
            tbServerURL.Text = settings.ServerUrl;
            tbAccessPhrase.Text = settings.AccessPhrase;
            dsDepartamentData.Merge(settings.DepartamentData);
        }

        protected void PopData(SettingsClass settings)
        {
            settings.ServerUrl = tbServerURL.Text;
            settings.AccessPhrase = tbAccessPhrase.Text;
            settings.DepartamentData.Clear();
            settings.DepartamentData.Merge(dsDepartamentData, true);
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            PopData(Settings);
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
