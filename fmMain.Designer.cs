
namespace TicketSender
{
    partial class fmMain
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pContainer = new System.Windows.Forms.Panel();
            this.tlpContainer = new System.Windows.Forms.TableLayoutPanel();
            this.tbFullNameField = new TicketSender.ValidatedTextBox();
            this.tbBirthYearField = new TicketSender.ValidatedTextBox();
            this.tbAddress = new TicketSender.ValidatedTextBox();
            this.tbTargetCabinetField = new TicketSender.ValidatedTextBox();
            this.lbMessage = new System.Windows.Forms.Label();
            this.btToggleQueue = new System.Windows.Forms.Button();
            this.btSend = new System.Windows.Forms.Button();
            this.pDepartament = new System.Windows.Forms.Panel();
            this.cbDepartamentField = new System.Windows.Forms.ComboBox();
            this.cbLockDepartamentField = new System.Windows.Forms.CheckBox();
            this.lbDepartament = new System.Windows.Forms.Label();
            this.mMain = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miToggleBufferMonitor = new System.Windows.Forms.ToolStripMenuItem();
            this.miToggleTopForm = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.miMinimizeWindow = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMessageController = new System.Windows.Forms.Timer(this.components);
            this.tmrQueueProcessor = new System.Windows.Forms.Timer(this.components);
            this.pTicketManager = new System.Windows.Forms.Panel();
            this.ticketManagerUI2 = new TicketSender.TicketManagerUI();
            this.tmrClipboardMonitor = new System.Windows.Forms.Timer(this.components);
            this.ttNotify = new System.Windows.Forms.ToolTip(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.pMainContainer = new System.Windows.Forms.Panel();
            this.dsDepartamentData = new System.Data.DataSet();
            this.DepartamentTable = new System.Data.DataTable();
            this.dataColumn1 = new System.Data.DataColumn();
            this.dataColumn2 = new System.Data.DataColumn();
            this.dataColumn3 = new System.Data.DataColumn();
            this.pContainer.SuspendLayout();
            this.tlpContainer.SuspendLayout();
            this.pDepartament.SuspendLayout();
            this.mMain.SuspendLayout();
            this.pTicketManager.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.pMainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDepartamentData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentTable)).BeginInit();
            this.SuspendLayout();
            // 
            // pContainer
            // 
            this.pContainer.AutoSize = true;
            this.pContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pContainer.Controls.Add(this.tlpContainer);
            this.pContainer.Dock = System.Windows.Forms.DockStyle.Left;
            this.pContainer.Location = new System.Drawing.Point(0, 40);
            this.pContainer.Name = "pContainer";
            this.pContainer.Padding = new System.Windows.Forms.Padding(1);
            this.pContainer.Size = new System.Drawing.Size(371, 521);
            this.pContainer.TabIndex = 0;
            // 
            // tlpContainer
            // 
            this.tlpContainer.AutoSize = true;
            this.tlpContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tlpContainer.ColumnCount = 1;
            this.tlpContainer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpContainer.Controls.Add(this.tbFullNameField, 0, 1);
            this.tlpContainer.Controls.Add(this.tbBirthYearField, 0, 2);
            this.tlpContainer.Controls.Add(this.tbAddress, 0, 3);
            this.tlpContainer.Controls.Add(this.tbTargetCabinetField, 0, 4);
            this.tlpContainer.Controls.Add(this.lbMessage, 0, 15);
            this.tlpContainer.Controls.Add(this.btToggleQueue, 0, 16);
            this.tlpContainer.Controls.Add(this.btSend, 0, 14);
            this.tlpContainer.Controls.Add(this.pDepartament, 0, 12);
            this.tlpContainer.Controls.Add(this.lbDepartament, 0, 11);
            this.tlpContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpContainer.Location = new System.Drawing.Point(1, 1);
            this.tlpContainer.Name = "tlpContainer";
            this.tlpContainer.RowCount = 17;
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpContainer.Size = new System.Drawing.Size(369, 519);
            this.tlpContainer.TabIndex = 8;
            // 
            // tbFullNameField
            // 
            this.tbFullNameField.AutoSize = true;
            this.tbFullNameField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbFullNameField.AvailabledCharList = "[А-Яа-я\\.\\s]+";
            this.tbFullNameField.Caption = "ФИО пациент";
            this.tbFullNameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbFullNameField.ErrorTextForIncorrectInputKey = "Неверный ввод! Доступныесимволы: А-Я, а-я, ПРОБЕЛ, точка";
            this.tbFullNameField.Location = new System.Drawing.Point(3, 3);
            this.tbFullNameField.Name = "tbFullNameField";
            this.tbFullNameField.ShowCaption = true;
            this.tbFullNameField.ShowError = true;
            this.tbFullNameField.ShowErrorForIncorrectInputKey = true;
            this.tbFullNameField.Size = new System.Drawing.Size(363, 67);
            this.tbFullNameField.TabIndex = 0;
            this.tbFullNameField.Tag = "fullname";
            this.tbFullNameField.Text = "";
            this.tbFullNameField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbFullNameField.UseAvailabledCharList = true;
            // 
            // tbBirthYearField
            // 
            this.tbBirthYearField.AutoSize = true;
            this.tbBirthYearField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbBirthYearField.AvailabledCharList = "[0-9]+";
            this.tbBirthYearField.Caption = "Полный год рождения";
            this.tbBirthYearField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbBirthYearField.ErrorTextForIncorrectInputKey = "Неверный ввод! Доступны только десятичные символы: 0-9";
            this.tbBirthYearField.Location = new System.Drawing.Point(3, 76);
            this.tbBirthYearField.Name = "tbBirthYearField";
            this.tbBirthYearField.ShowCaption = true;
            this.tbBirthYearField.ShowError = true;
            this.tbBirthYearField.ShowErrorForIncorrectInputKey = true;
            this.tbBirthYearField.Size = new System.Drawing.Size(363, 67);
            this.tbBirthYearField.TabIndex = 1;
            this.tbBirthYearField.Tag = "birthyear";
            this.tbBirthYearField.Text = "";
            this.tbBirthYearField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbBirthYearField.UseAvailabledCharList = true;
            // 
            // tbAddress
            // 
            this.tbAddress.AutoSize = true;
            this.tbAddress.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbAddress.AvailabledCharList = "[А-Яа-я0-9\\s\\.\\/-]+";
            this.tbAddress.Caption = "Адрес проживания";
            this.tbAddress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbAddress.ErrorTextForIncorrectInputKey = "Неверный ввод! Доступны только десятичные символы: 0-9, А-Я, а-я, точка, пробел, " +
    "знак дроби \"/\"";
            this.tbAddress.Location = new System.Drawing.Point(3, 149);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.ShowCaption = true;
            this.tbAddress.ShowError = true;
            this.tbAddress.ShowErrorForIncorrectInputKey = true;
            this.tbAddress.Size = new System.Drawing.Size(363, 67);
            this.tbAddress.TabIndex = 2;
            this.tbAddress.Tag = "address";
            this.tbAddress.Text = "";
            this.tbAddress.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbAddress.UseAvailabledCharList = true;
            // 
            // tbTargetCabinetField
            // 
            this.tbTargetCabinetField.AutoSize = true;
            this.tbTargetCabinetField.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tbTargetCabinetField.AvailabledCharList = "[А-Яа-я0-9\\s\\.\\/-]+";
            this.tbTargetCabinetField.Caption = "Целевой кабинет";
            this.tbTargetCabinetField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbTargetCabinetField.ErrorTextForIncorrectInputKey = "Неверный ввод! Доступны только десятичные символы: 0-9, А-Я, а-я, точка, пробел, " +
    "знак дроби \"/\"";
            this.tbTargetCabinetField.Location = new System.Drawing.Point(3, 222);
            this.tbTargetCabinetField.Name = "tbTargetCabinetField";
            this.tbTargetCabinetField.ShowCaption = true;
            this.tbTargetCabinetField.ShowError = true;
            this.tbTargetCabinetField.ShowErrorForIncorrectInputKey = true;
            this.tbTargetCabinetField.Size = new System.Drawing.Size(363, 67);
            this.tbTargetCabinetField.TabIndex = 3;
            this.tbTargetCabinetField.Tag = "targetcabinet";
            this.tbTargetCabinetField.Text = "";
            this.tbTargetCabinetField.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbTargetCabinetField.UseAvailabledCharList = true;
            // 
            // lbMessage
            // 
            this.lbMessage.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbMessage.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbMessage.Location = new System.Drawing.Point(3, 424);
            this.lbMessage.MinimumSize = new System.Drawing.Size(0, 56);
            this.lbMessage.Name = "lbMessage";
            this.lbMessage.Size = new System.Drawing.Size(363, 56);
            this.lbMessage.TabIndex = 35;
            this.lbMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btToggleQueue
            // 
            this.btToggleQueue.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btToggleQueue.Location = new System.Drawing.Point(3, 483);
            this.btToggleQueue.Name = "btToggleQueue";
            this.btToggleQueue.Size = new System.Drawing.Size(363, 33);
            this.btToggleQueue.TabIndex = 7;
            this.btToggleQueue.Text = "Показать очередь";
            this.btToggleQueue.UseVisualStyleBackColor = true;
            this.btToggleQueue.Click += new System.EventHandler(this.btToggleQueue_Click);
            // 
            // btSend
            // 
            this.btSend.Dock = System.Windows.Forms.DockStyle.Top;
            this.btSend.Location = new System.Drawing.Point(5, 378);
            this.btSend.Margin = new System.Windows.Forms.Padding(5);
            this.btSend.Name = "btSend";
            this.btSend.Size = new System.Drawing.Size(359, 41);
            this.btSend.TabIndex = 5;
            this.btSend.Text = "В очередь";
            this.btSend.UseVisualStyleBackColor = true;
            this.btSend.Click += new System.EventHandler(this.btSend_Click);
            // 
            // pDepartament
            // 
            this.pDepartament.Controls.Add(this.cbDepartamentField);
            this.pDepartament.Controls.Add(this.cbLockDepartamentField);
            this.pDepartament.Dock = System.Windows.Forms.DockStyle.Top;
            this.pDepartament.Location = new System.Drawing.Point(5, 327);
            this.pDepartament.Margin = new System.Windows.Forms.Padding(5);
            this.pDepartament.MinimumSize = new System.Drawing.Size(0, 21);
            this.pDepartament.Name = "pDepartament";
            this.pDepartament.Size = new System.Drawing.Size(359, 21);
            this.pDepartament.TabIndex = 32;
            // 
            // cbDepartamentField
            // 
            this.cbDepartamentField.DataSource = this.dsDepartamentData;
            this.cbDepartamentField.DisplayMember = "DepartamentTable.DisplayName";
            this.cbDepartamentField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cbDepartamentField.FormattingEnabled = true;
            this.cbDepartamentField.Location = new System.Drawing.Point(0, 0);
            this.cbDepartamentField.Name = "cbDepartamentField";
            this.cbDepartamentField.Size = new System.Drawing.Size(216, 21);
            this.cbDepartamentField.TabIndex = 4;
            this.cbDepartamentField.Tag = "HANDLER_NAME";
            this.cbDepartamentField.ValueMember = "DepartamentTable.Value";
            // 
            // cbLockDepartamentField
            // 
            this.cbLockDepartamentField.Dock = System.Windows.Forms.DockStyle.Right;
            this.cbLockDepartamentField.Location = new System.Drawing.Point(216, 0);
            this.cbLockDepartamentField.Name = "cbLockDepartamentField";
            this.cbLockDepartamentField.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.cbLockDepartamentField.Size = new System.Drawing.Size(143, 21);
            this.cbLockDepartamentField.TabIndex = 6;
            this.cbLockDepartamentField.Tag = "blockdepartedit";
            this.cbLockDepartamentField.Text = "Блокировать изменение";
            this.cbLockDepartamentField.UseVisualStyleBackColor = true;
            this.cbLockDepartamentField.Click += new System.EventHandler(this.cbLockDepartamentField_CheckedChanged);
            // 
            // lbDepartament
            // 
            this.lbDepartament.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDepartament.Location = new System.Drawing.Point(3, 292);
            this.lbDepartament.Name = "lbDepartament";
            this.lbDepartament.Size = new System.Drawing.Size(363, 30);
            this.lbDepartament.TabIndex = 31;
            this.lbDepartament.Text = "Подразделение";
            this.lbDepartament.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mMain
            // 
            this.mMain.Dock = System.Windows.Forms.DockStyle.None;
            this.mMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.miToggleBufferMonitor,
            this.miToggleTopForm,
            this.toolStripMenuItem1,
            this.miMinimizeWindow});
            this.mMain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.mMain.Location = new System.Drawing.Point(0, 0);
            this.mMain.Name = "mMain";
            this.mMain.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.mMain.Size = new System.Drawing.Size(959, 23);
            this.mMain.TabIndex = 12;
            this.mMain.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem,
            this.toolStripMenuItem2,
            this.выходToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 19);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.параметрыToolStripMenuItem.Text = "Параметры";
            this.параметрыToolStripMenuItem.Click += new System.EventHandler(this.параметрыToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(135, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(138, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // miToggleBufferMonitor
            // 
            this.miToggleBufferMonitor.Name = "miToggleBufferMonitor";
            this.miToggleBufferMonitor.Size = new System.Drawing.Size(215, 19);
            this.miToggleBufferMonitor.Text = "Включить монитор буфера обмена";
            this.miToggleBufferMonitor.Click += new System.EventHandler(this.miToggleBufferMonitor_Click);
            // 
            // miToggleTopForm
            // 
            this.miToggleTopForm.Name = "miToggleTopForm";
            this.miToggleTopForm.Size = new System.Drawing.Size(156, 19);
            this.miToggleTopForm.Text = "Режим поверх всех окон";
            this.miToggleTopForm.Click += new System.EventHandler(this.miToggleTopForm_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Enabled = false;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(39, 19);
            this.toolStripMenuItem1.Text = "----";
            // 
            // miMinimizeWindow
            // 
            this.miMinimizeWindow.Name = "miMinimizeWindow";
            this.miMinimizeWindow.Size = new System.Drawing.Size(100, 19);
            this.miMinimizeWindow.Text = "Свернуть окно";
            this.miMinimizeWindow.Click += new System.EventHandler(this.miMinimizeWindow_Click);
            // 
            // tmrMessageController
            // 
            this.tmrMessageController.Tick += new System.EventHandler(this.tmrMessageController_Tick);
            // 
            // tmrQueueProcessor
            // 
            this.tmrQueueProcessor.Enabled = true;
            this.tmrQueueProcessor.Interval = 1000;
            this.tmrQueueProcessor.Tick += new System.EventHandler(this.tmrQueueProcessor_Tick);
            // 
            // pTicketManager
            // 
            this.pTicketManager.Controls.Add(this.ticketManagerUI2);
            this.pTicketManager.Dock = System.Windows.Forms.DockStyle.Left;
            this.pTicketManager.Location = new System.Drawing.Point(371, 40);
            this.pTicketManager.Name = "pTicketManager";
            this.pTicketManager.Size = new System.Drawing.Size(587, 521);
            this.pTicketManager.TabIndex = 6;
            // 
            // ticketManagerUI2
            // 
            this.ticketManagerUI2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ticketManagerUI2.Location = new System.Drawing.Point(0, 0);
            this.ticketManagerUI2.Name = "ticketManagerUI2";
            this.ticketManagerUI2.Padding = new System.Windows.Forms.Padding(1);
            this.ticketManagerUI2.Size = new System.Drawing.Size(587, 521);
            this.ticketManagerUI2.TabIndex = 8;
            this.ticketManagerUI2.Load += new System.EventHandler(this.ticketManagerUI2_Load);
            // 
            // tmrClipboardMonitor
            // 
            this.tmrClipboardMonitor.Tick += new System.EventHandler(this.tmrClipboardMonitor_Tick);
            // 
            // ttNotify
            // 
            this.ttNotify.ToolTipTitle = "Внимание!";
            // 
            // errorProvider1
            // 
            this.errorProvider1.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.AlwaysBlink;
            this.errorProvider1.ContainerControl = this;
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(959, 0);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Top;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.MinimumSize = new System.Drawing.Size(0, 40);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(959, 40);
            this.toolStripContainer1.TabIndex = 13;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.mMain);
            this.toolStripContainer1.TopToolStripPanel.MinimumSize = new System.Drawing.Size(0, 40);
            // 
            // pMainContainer
            // 
            this.pMainContainer.AutoSize = true;
            this.pMainContainer.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pMainContainer.Controls.Add(this.pTicketManager);
            this.pMainContainer.Controls.Add(this.pContainer);
            this.pMainContainer.Controls.Add(this.toolStripContainer1);
            this.pMainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMainContainer.Location = new System.Drawing.Point(0, 0);
            this.pMainContainer.Name = "pMainContainer";
            this.pMainContainer.Size = new System.Drawing.Size(959, 561);
            this.pMainContainer.TabIndex = 9;
            // 
            // dsDepartamentData
            // 
            this.dsDepartamentData.DataSetName = "DepartamentData";
            this.dsDepartamentData.Tables.AddRange(new System.Data.DataTable[] {
            this.DepartamentTable});
            // 
            // DepartamentTable
            // 
            this.DepartamentTable.Columns.AddRange(new System.Data.DataColumn[] {
            this.dataColumn1,
            this.dataColumn2,
            this.dataColumn3});
            this.DepartamentTable.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, false)});
            this.DepartamentTable.TableName = "DepartamentTable";
            // 
            // dataColumn1
            // 
            this.dataColumn1.AutoIncrement = true;
            this.dataColumn1.Caption = "Id";
            this.dataColumn1.ColumnName = "Id";
            this.dataColumn1.DataType = typeof(int);
            // 
            // dataColumn2
            // 
            this.dataColumn2.Caption = "DisplayName";
            this.dataColumn2.ColumnName = "DisplayName";
            // 
            // dataColumn3
            // 
            this.dataColumn3.Caption = "Value";
            this.dataColumn3.ColumnName = "Value";
            // 
            // fmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(959, 561);
            this.Controls.Add(this.pMainContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.mMain;
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(330, 600);
            this.Name = "fmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Отправка талона";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmMain_FormClosed);
            this.pContainer.ResumeLayout(false);
            this.pContainer.PerformLayout();
            this.tlpContainer.ResumeLayout(false);
            this.tlpContainer.PerformLayout();
            this.pDepartament.ResumeLayout(false);
            this.mMain.ResumeLayout(false);
            this.mMain.PerformLayout();
            this.pTicketManager.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.pMainContainer.ResumeLayout(false);
            this.pMainContainer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dsDepartamentData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DepartamentTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pContainer;
        private System.Windows.Forms.MenuStrip mMain;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.Timer tmrMessageController;
        private System.Windows.Forms.Timer tmrQueueProcessor;
        private System.Windows.Forms.Panel pTicketManager;
        private TicketManagerUI ticketManagerUI2;
        private System.Windows.Forms.Timer tmrClipboardMonitor;
        private System.Windows.Forms.ToolTip ttNotify;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.TableLayoutPanel tlpContainer;
        private System.Windows.Forms.Label lbMessage;
        private System.Windows.Forms.Button btToggleQueue;
        private System.Windows.Forms.Button btSend;
        private System.Windows.Forms.Panel pDepartament;
        private System.Windows.Forms.ComboBox cbDepartamentField;
        private System.Windows.Forms.CheckBox cbLockDepartamentField;
        private System.Windows.Forms.Label lbDepartament;
        private ValidatedTextBox tbFullNameField;
        private ValidatedTextBox tbBirthYearField;
        private ValidatedTextBox tbAddress;
        private ValidatedTextBox tbTargetCabinetField;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel pMainContainer;
        private System.Windows.Forms.ToolStripMenuItem miToggleBufferMonitor;
        private System.Windows.Forms.ToolStripMenuItem miToggleTopForm;
        private System.Windows.Forms.ToolStripMenuItem miMinimizeWindow;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Data.DataSet dsDepartamentData;
        private System.Data.DataTable DepartamentTable;
        private System.Data.DataColumn dataColumn1;
        private System.Data.DataColumn dataColumn2;
        private System.Data.DataColumn dataColumn3;
    }
}

