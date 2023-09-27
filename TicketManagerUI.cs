using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Newtonsoft.Json;
using System.Drawing.Printing;
using OfficeOpenXml;
using OfficeOpenXml.Export.HtmlExport;
using HtmlAgilityPack;

namespace TicketSender
{
    public partial class TicketManagerUI : UserControl
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected TicketManager iTicketManager = null;
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        protected DataTable iDataTable = null;

        public TicketManagerUI()
        {
            InitializeComponent();
            TicketClass sample = new TicketClass();
            DataTable table = dsTickets.Tables.Add();
            table.TableName = "TicketTable";
            dgvTickets.DataMember = table.TableName;
            
            iDataTable = table;

            foreach (var field in TicketClass.TableSchema)
            {
                DataColumn dcol = new DataColumn(field.FieldName, typeof(string));
                dcol.Caption = field.Title;
                table.Columns.Add(dcol);
            }

            dgvTickets.AutoGenerateColumns = true;

            foreach (var field in TicketClass.TableSchema)
            {
                DataGridViewColumn vcol = dgvTickets.Columns[field.FieldName];
                vcol.HeaderText = field.Title;
                vcol.Width = field.Attribute.DefaultWidth;
                vcol.Visible = !field.Attribute.IsHidden;
            }

            TicketManager = TicketManager.Instance;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public TicketManager TicketManager
        {
            get => iTicketManager;

            set
            {
                if (iTicketManager == value)
                    return;

                iDataTable.Clear();
                iTicketManager = value;

                if (iTicketManager != null)
                {
                    iTicketManager.OnQueueChange += ITicketManager_OnQueueChange;
                    ITicketManager_OnQueueChange(iTicketManager);
                }
            }
        }

        private void ITicketManager_OnQueueChange(object obj)
        {
            if (TicketManager == null)
                return;

            iDataTable.BeginLoadData();
            try
            {
                iDataTable.Clear();

                foreach (var ticket in iTicketManager.Tickets)
                {
                    DataRow row = iDataTable.NewRow();
                    
                    foreach (var keyvalue in ticket.ToFormData())
                    {
                        row[keyvalue.Key] = keyvalue.Value;
                    }

                    iDataTable.Rows.Add(row);
                }
            }
            finally
            {
                iDataTable.EndLoadData();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            ExcelPackage excel = new ExcelPackage();
            ExcelWorksheet page = excel.Workbook.Worksheets.Add("Талоны");
            int counterY = 1, 
                counterX = 1;

            page.InsertRow(1, 1);

            foreach (var field in TicketClass.TableSchema)
            {
                page.InsertColumn(counterX, 1);
                var col = page.Column(counterX);

                col.Width = field.Attribute.DefaultWidth / 7;
                page.Cells[1, counterX].Value = field.Title;
                
                counterX++;
            }

            counterY = 2;
            foreach (var ticket in iTicketManager.Tickets)
            {
                counterX = 1;
                var ticketData = ticket.ToFormData();
                page.InsertRow(counterY, 1);
                
                foreach (var field in TicketClass.TableSchema)
                {
                    string value = "";

                    ticketData.TryGetValue(field.FieldName, out value);

                    page.Cells[counterY, counterX].Value = value;
                    counterX++;
                }

                counterY++;
            }

            excel.SaveAs("test.xlsx");
            //excel.Workbook.Worksheets[1]
//            OfficeOpenXml.Export.HtmlExport
            

            PrintDocument doc = new PrintDocument();
            doc.PrintPage += (s, t) =>
            {
                var bmp = new Bitmap(dgvTickets.Width, dgvTickets.Height);
                dgvTickets.DrawToBitmap(bmp, dgvTickets.ClientRectangle);
                t.Graphics.DrawImage(bmp, new Point(100, 100));
            };
            pdPrint.Document = doc;

            if (pdPrint.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void tsbClearQueue_Click(object sender, EventArgs e)
        {
            iTicketManager.ClearQueue();
        }
    }
}
