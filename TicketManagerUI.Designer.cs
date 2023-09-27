
namespace TicketSender
{
    partial class TicketManagerUI
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TicketManagerUI));
            this.dsTickets = new System.Data.DataSet();
            this.dgvTickets = new System.Windows.Forms.DataGridView();
            this.pdPrint = new System.Windows.Forms.PrintDialog();
            this.pdDocument = new System.Drawing.Printing.PrintDocument();
            this.ppdPrint = new System.Windows.Forms.PrintPreviewDialog();
            this.pTitle = new System.Windows.Forms.Panel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.label1 = new System.Windows.Forms.Label();
            this.tsbClearQueue = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dsTickets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).BeginInit();
            this.pTitle.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dsTickets
            // 
            this.dsTickets.DataSetName = "NewDataSet";
            // 
            // dgvTickets
            // 
            this.dgvTickets.AllowUserToAddRows = false;
            this.dgvTickets.AllowUserToDeleteRows = false;
            this.dgvTickets.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTickets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTickets.DataSource = this.dsTickets;
            this.dgvTickets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTickets.Location = new System.Drawing.Point(0, 57);
            this.dgvTickets.Name = "dgvTickets";
            this.dgvTickets.Size = new System.Drawing.Size(303, 337);
            this.dgvTickets.TabIndex = 2;
            // 
            // pdPrint
            // 
            this.pdPrint.AllowSomePages = true;
            this.pdPrint.UseEXDialog = true;
            // 
            // ppdPrint
            // 
            this.ppdPrint.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.ppdPrint.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.ppdPrint.ClientSize = new System.Drawing.Size(400, 300);
            this.ppdPrint.Document = this.pdDocument;
            this.ppdPrint.Enabled = true;
            this.ppdPrint.Icon = ((System.Drawing.Icon)(resources.GetObject("ppdPrint.Icon")));
            this.ppdPrint.Name = "ppdPrint";
            this.ppdPrint.Visible = false;
            // 
            // pTitle
            // 
            this.pTitle.AutoSize = true;
            this.pTitle.Controls.Add(this.toolStrip1);
            this.pTitle.Controls.Add(this.label1);
            this.pTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTitle.Location = new System.Drawing.Point(0, 0);
            this.pTitle.Name = "pTitle";
            this.pTitle.Padding = new System.Windows.Forms.Padding(5);
            this.pTitle.Size = new System.Drawing.Size(303, 57);
            this.pTitle.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClearQueue});
            this.toolStrip1.Location = new System.Drawing.Point(5, 27);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(293, 25);
            this.toolStrip1.TabIndex = 5;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(5, 5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Очередь талонов";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tsbClearQueue
            // 
            this.tsbClearQueue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClearQueue.Image = ((System.Drawing.Image)(resources.GetObject("tsbClearQueue.Image")));
            this.tsbClearQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClearQueue.Name = "tsbClearQueue";
            this.tsbClearQueue.Size = new System.Drawing.Size(111, 22);
            this.tsbClearQueue.Text = "Очистить очередь";
            this.tsbClearQueue.Click += new System.EventHandler(this.tsbClearQueue_Click);
            // 
            // TicketManagerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTickets);
            this.Controls.Add(this.pTitle);
            this.Name = "TicketManagerUI";
            this.Size = new System.Drawing.Size(303, 394);
            ((System.ComponentModel.ISupportInitialize)(this.dsTickets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTickets)).EndInit();
            this.pTitle.ResumeLayout(false);
            this.pTitle.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Data.DataSet dsTickets;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.PrintDialog pdPrint;
        private System.Drawing.Printing.PrintDocument pdDocument;
        private System.Windows.Forms.PrintPreviewDialog ppdPrint;
        private System.Windows.Forms.Panel pTitle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbClearQueue;
    }
}
