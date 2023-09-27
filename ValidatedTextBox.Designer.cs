
namespace TicketSender
{
    partial class ValidatedTextBox
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
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tbText = new System.Windows.Forms.TextBox();
            this.lbCaption = new System.Windows.Forms.Label();
            this.lbError = new System.Windows.Forms.Label();
            this.tlpContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpContainer
            // 
            this.tlpContainer.AutoSize = true;
            this.tlpContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.Controls.Add(this.tbText, 0, 1);
            this.tlpContainer.Controls.Add(this.lbCaption, 0, 0);
            this.tlpContainer.Controls.Add(this.lbError, 0, 2);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(0, 0);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 3;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.Size = new System.Drawing.Size(257, 98);
            this.tlpContainer.TabIndex = 0;
            this.tlpContainer.Click += new System.EventHandler(this.ValidatedTextBox_Click);
            // 
            // tbText
            // 
            this.tbText.Dock = System.Windows.Forms.DockStyle.Top;
            this.tbText.Location = new System.Drawing.Point(3, 33);
            this.tbText.MinimumSize = new System.Drawing.Size(50, 21);
            this.tbText.Name = "tbText";
            this.tbText.Size = new System.Drawing.Size(251, 20);
            this.tbText.TabIndex = 19;
            this.tbText.TextChanged += new System.EventHandler(this.tbText_TextChanged);
            this.tbText.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbText_KeyPress);
            this.tbText.Validated += new System.EventHandler(this.tbText_Validated);
            // 
            // lbCaption
            // 
            this.lbCaption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbCaption.Location = new System.Drawing.Point(3, 3);
            this.lbCaption.Margin = new System.Windows.Forms.Padding(3);
            this.lbCaption.Name = "lbCaption";
            this.lbCaption.Size = new System.Drawing.Size(251, 24);
            this.lbCaption.TabIndex = 18;
            this.lbCaption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbCaption.Click += new System.EventHandler(this.ValidatedTextBox_Click);
            // 
            // lbError
            // 
            this.lbError.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(3, 62);
            this.lbError.Margin = new System.Windows.Forms.Padding(3, 6, 3, 3);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(251, 33);
            this.lbError.TabIndex = 17;
            this.lbError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lbError.Click += new System.EventHandler(this.ValidatedTextBox_Click);
            // 
            // ValidatedTextBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.tlpContainer);
            this.Name = "ValidatedTextBox";
            this.Size = new System.Drawing.Size(257, 98);
            this.SizeChanged += new System.EventHandler(this.ValidatedTextBox_SizeChanged);
            this.Click += new System.EventHandler(this.ValidatedTextBox_Click);
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.TextBox tbText;
        private System.Windows.Forms.Label lbCaption;
        private System.Windows.Forms.Label lbError;
    }
}
