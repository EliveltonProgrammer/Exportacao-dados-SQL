namespace Migration
{
    partial class frmReadWorkOrder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadWorkOrder));
            this.dataGridViewWorkOrders = new System.Windows.Forms.DataGridView();
            this.tbxFilterNumTicketStart = new System.Windows.Forms.TextBox();
            this.tbxFilterNumTicketEnd = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbTxtContRows = new System.Windows.Forms.Label();
            this.lbContRows = new System.Windows.Forms.Label();
            this.lbContColums = new System.Windows.Forms.Label();
            this.lbTxtContColums = new System.Windows.Forms.Label();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbExporting = new System.Windows.Forms.Label();
            this.cbxFilterStatusTicket = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxFilterDtStartTicket = new System.Windows.Forms.MaskedTextBox();
            this.contextMenuWorkOrder = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.dataHoraDoSistemaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataHoraAtualUltimoMinutoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intervaloDe30DiasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataHoraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbxFilterDtEndTicket = new System.Windows.Forms.MaskedTextBox();
            this.btnProcessActions = new System.Windows.Forms.Button();
            this.btnFilterDateTicket = new System.Windows.Forms.Button();
            this.btnEraseGrid = new System.Windows.Forms.Button();
            this.btnFilterNumTicket = new System.Windows.Forms.Button();
            this.btnExportXls = new System.Windows.Forms.Button();
            this.btnAccessFrmReadCN = new System.Windows.Forms.Button();
            this.lbLoadingGrid = new System.Windows.Forms.Label();
            this.progressBarLoadingGrid = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkOrders)).BeginInit();
            this.contextMenuWorkOrder.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewWorkOrders
            // 
            this.dataGridViewWorkOrders.AllowUserToAddRows = false;
            this.dataGridViewWorkOrders.AllowUserToDeleteRows = false;
            this.dataGridViewWorkOrders.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridViewWorkOrders.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewWorkOrders.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewWorkOrders.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewWorkOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewWorkOrders.GridColor = System.Drawing.SystemColors.Control;
            this.dataGridViewWorkOrders.Location = new System.Drawing.Point(1, 37);
            this.dataGridViewWorkOrders.Name = "dataGridViewWorkOrders";
            this.dataGridViewWorkOrders.ReadOnly = true;
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dataGridViewWorkOrders.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewWorkOrders.Size = new System.Drawing.Size(932, 398);
            this.dataGridViewWorkOrders.TabIndex = 0;
            // 
            // tbxFilterNumTicketStart
            // 
            this.tbxFilterNumTicketStart.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterNumTicketStart.Location = new System.Drawing.Point(67, 8);
            this.tbxFilterNumTicketStart.Name = "tbxFilterNumTicketStart";
            this.tbxFilterNumTicketStart.Size = new System.Drawing.Size(42, 22);
            this.tbxFilterNumTicketStart.TabIndex = 16;
            // 
            // tbxFilterNumTicketEnd
            // 
            this.tbxFilterNumTicketEnd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterNumTicketEnd.Location = new System.Drawing.Point(139, 8);
            this.tbxFilterNumTicketEnd.Name = "tbxFilterNumTicketEnd";
            this.tbxFilterNumTicketEnd.Size = new System.Drawing.Size(42, 22);
            this.tbxFilterNumTicketEnd.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nº Ticket:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(112, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "até:";
            // 
            // lbTxtContRows
            // 
            this.lbTxtContRows.AutoSize = true;
            this.lbTxtContRows.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTxtContRows.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTxtContRows.Location = new System.Drawing.Point(829, 439);
            this.lbTxtContRows.Name = "lbTxtContRows";
            this.lbTxtContRows.Size = new System.Drawing.Size(58, 15);
            this.lbTxtContRows.TabIndex = 22;
            this.lbTxtContRows.Text = "Registros:";
            // 
            // lbContRows
            // 
            this.lbContRows.AutoSize = true;
            this.lbContRows.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContRows.Location = new System.Drawing.Point(884, 439);
            this.lbContRows.Name = "lbContRows";
            this.lbContRows.Size = new System.Drawing.Size(70, 15);
            this.lbContRows.TabIndex = 23;
            this.lbContRows.Text = "&&ContRows";
            // 
            // lbContColums
            // 
            this.lbContColums.AutoSize = true;
            this.lbContColums.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContColums.Location = new System.Drawing.Point(879, 455);
            this.lbContColums.Name = "lbContColums";
            this.lbContColums.Size = new System.Drawing.Size(81, 15);
            this.lbContColums.TabIndex = 25;
            this.lbContColums.Text = "&&ContColums";
            // 
            // lbTxtContColums
            // 
            this.lbTxtContColums.AutoSize = true;
            this.lbTxtContColums.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTxtContColums.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTxtContColums.Location = new System.Drawing.Point(829, 455);
            this.lbTxtContColums.Name = "lbTxtContColums";
            this.lbTxtContColums.Size = new System.Drawing.Size(52, 15);
            this.lbTxtContColums.TabIndex = 24;
            this.lbTxtContColums.Text = "Colunas:";
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(744, 444);
            this.progressBar.MarqueeAnimationSpeed = 45;
            this.progressBar.Minimum = 10;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(56, 10);
            this.progressBar.Step = 30;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar.TabIndex = 26;
            this.progressBar.Value = 50;
            // 
            // lbExporting
            // 
            this.lbExporting.AutoSize = true;
            this.lbExporting.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExporting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbExporting.Location = new System.Drawing.Point(743, 455);
            this.lbExporting.Name = "lbExporting";
            this.lbExporting.Size = new System.Drawing.Size(65, 13);
            this.lbExporting.TabIndex = 40;
            this.lbExporting.Text = "Exportando...";
            // 
            // cbxFilterStatusTicket
            // 
            this.cbxFilterStatusTicket.DropDownHeight = 160;
            this.cbxFilterStatusTicket.DropDownWidth = 210;
            this.cbxFilterStatusTicket.FormattingEnabled = true;
            this.cbxFilterStatusTicket.IntegralHeight = false;
            this.cbxFilterStatusTicket.Items.AddRange(new object[] {
            "Todos os Status",
            "Em Abertos",
            "1-Open (Aberto)",
            "2-Onhold (Em Espera)",
            "3-Closed (Fechado)",
            "6-Em Correção-Cliente/Fixing-Customer",
            "7-Em Análise-PPI-Multitask/Analysis-PPI-Multitask",
            "8-Em Análise ou Correção de Suporte/Analysis or Custom fixing",
            "9-Aguardando Cliente/Waiting Customer",
            "301-Aguardando confirmação de solução/Waiting solution confirmation",
            "304-Em Análise ou Correção de Produto/Analysis or fixing-PPI-Multitask",
            "601-Visita técnica (Suporte)/On-site support",
            "901-Solução em análise pelo Cliente/Solution under Customer analysis",
            "1201-Falta de Retorno",
            "1501-Em Análise ou Correção de Sustentação/Analysis or fixing-Sustentation PPI-Mu" +
                "ltitask",
            "1801-Resolvido"});
            this.cbxFilterStatusTicket.Location = new System.Drawing.Point(631, 9);
            this.cbxFilterStatusTicket.Name = "cbxFilterStatusTicket";
            this.cbxFilterStatusTicket.Size = new System.Drawing.Size(128, 21);
            this.cbxFilterStatusTicket.TabIndex = 41;
            this.cbxFilterStatusTicket.SelectedIndexChanged += new System.EventHandler(this.tbxFilterStatusTicket_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(588, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 16);
            this.label3.TabIndex = 42;
            this.label3.Text = "Status:";
            // 
            // tbxFilterDtStartTicket
            // 
            this.tbxFilterDtStartTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilterDtStartTicket.ContextMenuStrip = this.contextMenuWorkOrder;
            this.tbxFilterDtStartTicket.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterDtStartTicket.Location = new System.Drawing.Point(334, 8);
            this.tbxFilterDtStartTicket.Mask = "00/00/0000 90:00";
            this.tbxFilterDtStartTicket.Name = "tbxFilterDtStartTicket";
            this.tbxFilterDtStartTicket.Size = new System.Drawing.Size(95, 22);
            this.tbxFilterDtStartTicket.TabIndex = 43;
            this.tbxFilterDtStartTicket.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // contextMenuWorkOrder
            // 
            this.contextMenuWorkOrder.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataHoraDoSistemaToolStripMenuItem,
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem,
            this.dataHoraAtualUltimoMinutoToolStripMenuItem,
            this.intervaloDe30DiasToolStripMenuItem,
            this.dataHoraToolStripMenuItem});
            this.contextMenuWorkOrder.Name = "contextMenuWorkOrder";
            this.contextMenuWorkOrder.Size = new System.Drawing.Size(297, 114);
            // 
            // dataHoraDoSistemaToolStripMenuItem
            // 
            this.dataHoraDoSistemaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataHoraDoSistemaToolStripMenuItem.Image")));
            this.dataHoraDoSistemaToolStripMenuItem.Name = "dataHoraDoSistemaToolStripMenuItem";
            this.dataHoraDoSistemaToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.dataHoraDoSistemaToolStripMenuItem.Text = "Data/Hora atuais";
            this.dataHoraDoSistemaToolStripMenuItem.Click += new System.EventHandler(this.dataHoraDoSistemaToolStripMenuItem_Click);
            // 
            // doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem
            // 
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Image")));
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Name = "doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem";
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Text = "Data/Hora Atual - Começo ao Final do dia";
            this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem.Click += new System.EventHandler(this.doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem_Click);
            // 
            // dataHoraAtualUltimoMinutoToolStripMenuItem
            // 
            this.dataHoraAtualUltimoMinutoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataHoraAtualUltimoMinutoToolStripMenuItem.Image")));
            this.dataHoraAtualUltimoMinutoToolStripMenuItem.Name = "dataHoraAtualUltimoMinutoToolStripMenuItem";
            this.dataHoraAtualUltimoMinutoToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.dataHoraAtualUltimoMinutoToolStripMenuItem.Text = "Data/Hora Atual - Final do dia";
            this.dataHoraAtualUltimoMinutoToolStripMenuItem.Click += new System.EventHandler(this.dataHoraAtualUltimoMinutoToolStripMenuItem_Click);
            // 
            // intervaloDe30DiasToolStripMenuItem
            // 
            this.intervaloDe30DiasToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("intervaloDe30DiasToolStripMenuItem.Image")));
            this.intervaloDe30DiasToolStripMenuItem.Name = "intervaloDe30DiasToolStripMenuItem";
            this.intervaloDe30DiasToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.intervaloDe30DiasToolStripMenuItem.Text = "Intervalo de 30 dias (Mês atual)";
            this.intervaloDe30DiasToolStripMenuItem.Click += new System.EventHandler(this.intervaloDe30DiasToolStripMenuItem_Click);
            // 
            // dataHoraToolStripMenuItem
            // 
            this.dataHoraToolStripMenuItem.Image = global::Migration.Properties.Resources.date;
            this.dataHoraToolStripMenuItem.Name = "dataHoraToolStripMenuItem";
            this.dataHoraToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.dataHoraToolStripMenuItem.Text = "Todos os dados";
            this.dataHoraToolStripMenuItem.Click += new System.EventHandler(this.dataHoraToolStripMenuItem_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(217, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 16);
            this.label4.TabIndex = 44;
            this.label4.Text = "Período de Abertura:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(431, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(26, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "até:";
            // 
            // tbxFilterDtEndTicket
            // 
            this.tbxFilterDtEndTicket.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbxFilterDtEndTicket.ContextMenuStrip = this.contextMenuWorkOrder;
            this.tbxFilterDtEndTicket.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterDtEndTicket.Location = new System.Drawing.Point(457, 8);
            this.tbxFilterDtEndTicket.Mask = "00/00/0000 90:00";
            this.tbxFilterDtEndTicket.Name = "tbxFilterDtEndTicket";
            this.tbxFilterDtEndTicket.Size = new System.Drawing.Size(95, 22);
            this.tbxFilterDtEndTicket.TabIndex = 46;
            this.tbxFilterDtEndTicket.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // btnProcessActions
            // 
            this.btnProcessActions.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnProcessActions.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProcessActions.Image = global::Migration.Properties.Resources.dataexport;
            this.btnProcessActions.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnProcessActions.Location = new System.Drawing.Point(92, 443);
            this.btnProcessActions.Name = "btnProcessActions";
            this.btnProcessActions.Size = new System.Drawing.Size(166, 23);
            this.btnProcessActions.TabIndex = 48;
            this.btnProcessActions.Text = "Gerar ações Relacionadas";
            this.btnProcessActions.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnProcessActions.UseVisualStyleBackColor = false;
            this.btnProcessActions.Click += new System.EventHandler(this.btnProcessActions_Click);
            // 
            // btnFilterDateTicket
            // 
            this.btnFilterDateTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterDateTicket.Image")));
            this.btnFilterDateTicket.Location = new System.Drawing.Point(556, 6);
            this.btnFilterDateTicket.Name = "btnFilterDateTicket";
            this.btnFilterDateTicket.Size = new System.Drawing.Size(26, 26);
            this.btnFilterDateTicket.TabIndex = 47;
            this.btnFilterDateTicket.UseVisualStyleBackColor = true;
            this.btnFilterDateTicket.Click += new System.EventHandler(this.btnFilterDateTicket_Click);
            // 
            // btnEraseGrid
            // 
            this.btnEraseGrid.Image = global::Migration.Properties.Resources.erase;
            this.btnEraseGrid.Location = new System.Drawing.Point(907, 6);
            this.btnEraseGrid.Name = "btnEraseGrid";
            this.btnEraseGrid.Size = new System.Drawing.Size(26, 26);
            this.btnEraseGrid.TabIndex = 21;
            this.btnEraseGrid.UseVisualStyleBackColor = true;
            this.btnEraseGrid.Click += new System.EventHandler(this.btnEraseGrid_Click);
            // 
            // btnFilterNumTicket
            // 
            this.btnFilterNumTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterNumTicket.Image")));
            this.btnFilterNumTicket.Location = new System.Drawing.Point(185, 6);
            this.btnFilterNumTicket.Name = "btnFilterNumTicket";
            this.btnFilterNumTicket.Size = new System.Drawing.Size(26, 26);
            this.btnFilterNumTicket.TabIndex = 20;
            this.btnFilterNumTicket.UseVisualStyleBackColor = true;
            this.btnFilterNumTicket.Click += new System.EventHandler(this.btnFilterNumTicket_Click);
            // 
            // btnExportXls
            // 
            this.btnExportXls.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExportXls.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportXls.Image = global::Migration.Properties.Resources.exportxls;
            this.btnExportXls.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExportXls.Location = new System.Drawing.Point(7, 443);
            this.btnExportXls.Name = "btnExportXls";
            this.btnExportXls.Size = new System.Drawing.Size(83, 23);
            this.btnExportXls.TabIndex = 15;
            this.btnExportXls.Text = "       Exportar";
            this.btnExportXls.UseVisualStyleBackColor = false;
            this.btnExportXls.Click += new System.EventHandler(this.btnExportXls_Click);
            // 
            // btnAccessFrmReadCN
            // 
            this.btnAccessFrmReadCN.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAccessFrmReadCN.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAccessFrmReadCN.Image = global::Migration.Properties.Resources.dataexport;
            this.btnAccessFrmReadCN.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccessFrmReadCN.Location = new System.Drawing.Point(260, 443);
            this.btnAccessFrmReadCN.Name = "btnAccessFrmReadCN";
            this.btnAccessFrmReadCN.Size = new System.Drawing.Size(128, 23);
            this.btnAccessFrmReadCN.TabIndex = 49;
            this.btnAccessFrmReadCN.Text = "Interface de ações";
            this.btnAccessFrmReadCN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAccessFrmReadCN.UseVisualStyleBackColor = false;
            this.btnAccessFrmReadCN.Click += new System.EventHandler(this.btnAccessFrmReadCN_Click);
            // 
            // lbLoadingGrid
            // 
            this.lbLoadingGrid.AutoSize = true;
            this.lbLoadingGrid.BackColor = System.Drawing.SystemColors.Control;
            this.lbLoadingGrid.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold);
            this.lbLoadingGrid.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbLoadingGrid.Location = new System.Drawing.Point(435, 237);
            this.lbLoadingGrid.Name = "lbLoadingGrid";
            this.lbLoadingGrid.Size = new System.Drawing.Size(77, 15);
            this.lbLoadingGrid.TabIndex = 51;
            this.lbLoadingGrid.Text = "Carregando...";
            // 
            // progressBarLoadingGrid
            // 
            this.progressBarLoadingGrid.Location = new System.Drawing.Point(373, 224);
            this.progressBarLoadingGrid.MarqueeAnimationSpeed = 45;
            this.progressBarLoadingGrid.Minimum = 10;
            this.progressBarLoadingGrid.Name = "progressBarLoadingGrid";
            this.progressBarLoadingGrid.Size = new System.Drawing.Size(192, 10);
            this.progressBarLoadingGrid.Step = 30;
            this.progressBarLoadingGrid.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBarLoadingGrid.TabIndex = 50;
            this.progressBarLoadingGrid.Value = 40;
            // 
            // frmReadWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(934, 471);
            this.Controls.Add(this.lbLoadingGrid);
            this.Controls.Add(this.progressBarLoadingGrid);
            this.Controls.Add(this.btnAccessFrmReadCN);
            this.Controls.Add(this.btnProcessActions);
            this.Controls.Add(this.btnFilterDateTicket);
            this.Controls.Add(this.tbxFilterDtEndTicket);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbxFilterDtStartTicket);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxFilterStatusTicket);
            this.Controls.Add(this.lbExporting);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbContColums);
            this.Controls.Add(this.lbTxtContColums);
            this.Controls.Add(this.lbContRows);
            this.Controls.Add(this.lbTxtContRows);
            this.Controls.Add(this.btnEraseGrid);
            this.Controls.Add(this.btnFilterNumTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExportXls);
            this.Controls.Add(this.dataGridViewWorkOrders);
            this.Controls.Add(this.tbxFilterNumTicketEnd);
            this.Controls.Add(this.tbxFilterNumTicketStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReadWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tickets [WorkOrder]";
            this.Load += new System.EventHandler(this.frmReadWorkOrderTickets_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewWorkOrders)).EndInit();
            this.contextMenuWorkOrder.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnExportXls;
        public System.Windows.Forms.DataGridView dataGridViewWorkOrders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnFilterNumTicket;
        public System.Windows.Forms.TextBox tbxFilterNumTicketStart;
        public System.Windows.Forms.TextBox tbxFilterNumTicketEnd;
        private System.Windows.Forms.Button btnEraseGrid;
        private System.Windows.Forms.Label lbTxtContRows;
        private System.Windows.Forms.Label lbContRows;
        private System.Windows.Forms.Label lbContColums;
        private System.Windows.Forms.Label lbTxtContColums;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbExporting;
        private System.Windows.Forms.ComboBox cbxFilterStatusTicket;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.MaskedTextBox tbxFilterDtStartTicket;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox tbxFilterDtEndTicket;
        private System.Windows.Forms.Button btnFilterDateTicket;
        private System.Windows.Forms.Button btnProcessActions;
        private System.Windows.Forms.ContextMenuStrip contextMenuWorkOrder;
        private System.Windows.Forms.ToolStripMenuItem dataHoraDoSistemaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataHoraAtualUltimoMinutoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intervaloDe30DiasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataHoraToolStripMenuItem;
        private System.Windows.Forms.Button btnAccessFrmReadCN;
        private System.Windows.Forms.Label lbLoadingGrid;
        private System.Windows.Forms.ProgressBar progressBarLoadingGrid;
    }
}