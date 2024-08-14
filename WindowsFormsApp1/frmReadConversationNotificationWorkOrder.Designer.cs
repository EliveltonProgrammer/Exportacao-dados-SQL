namespace Migration
{
    partial class frmReadConversationNotificationWorkOrder
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReadConversationNotificationWorkOrder));
            this.dataGridViewConversationNotificationWorkOrder = new System.Windows.Forms.DataGridView();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbContColums = new System.Windows.Forms.Label();
            this.lbTxtContColums = new System.Windows.Forms.Label();
            this.lbContRows = new System.Windows.Forms.Label();
            this.lbTxtContRows = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxFilterNumTicketEnd = new System.Windows.Forms.TextBox();
            this.tbxFilterNumTicketStart = new System.Windows.Forms.TextBox();
            this.lbExporting = new System.Windows.Forms.Label();
            this.btnSetSeq = new System.Windows.Forms.Button();
            this.btnEraseGrid = new System.Windows.Forms.Button();
            this.btnFilterNumTicket = new System.Windows.Forms.Button();
            this.btnExportXls = new System.Windows.Forms.Button();
            this.chxFilterAttachs = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStatusFilter = new System.Windows.Forms.Label();
            this.lbLoadingGrid = new System.Windows.Forms.Label();
            this.progressBarLoadingGrid = new System.Windows.Forms.ProgressBar();
            this.chxAutoColsRows = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConversationNotificationWorkOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewConversationNotificationWorkOrder
            // 
            this.dataGridViewConversationNotificationWorkOrder.AllowUserToAddRows = false;
            this.dataGridViewConversationNotificationWorkOrder.AllowUserToDeleteRows = false;
            this.dataGridViewConversationNotificationWorkOrder.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewConversationNotificationWorkOrder.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewConversationNotificationWorkOrder.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewConversationNotificationWorkOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewConversationNotificationWorkOrder.Location = new System.Drawing.Point(1, 37);
            this.dataGridViewConversationNotificationWorkOrder.Name = "dataGridViewConversationNotificationWorkOrder";
            this.dataGridViewConversationNotificationWorkOrder.ReadOnly = true;
            this.dataGridViewConversationNotificationWorkOrder.Size = new System.Drawing.Size(932, 398);
            this.dataGridViewConversationNotificationWorkOrder.TabIndex = 0;
            this.dataGridViewConversationNotificationWorkOrder.DefaultCellStyleChanged += new System.EventHandler(this.dataGridViewConversationNotificationWorkOrder_DefaultCellStyleChanged);
            this.dataGridViewConversationNotificationWorkOrder.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewConversationNotificationWorkOrder_CellFormatting);
            this.dataGridViewConversationNotificationWorkOrder.CellValueNeeded += new System.Windows.Forms.DataGridViewCellValueEventHandler(this.dataGridViewConversationNotificationWorkOrder_CellValueNeeded);
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
            this.progressBar.TabIndex = 32;
            this.progressBar.UseWaitCursor = true;
            this.progressBar.Value = 50;
            // 
            // lbContColums
            // 
            this.lbContColums.AutoSize = true;
            this.lbContColums.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContColums.Location = new System.Drawing.Point(879, 455);
            this.lbContColums.Name = "lbContColums";
            this.lbContColums.Size = new System.Drawing.Size(81, 15);
            this.lbContColums.TabIndex = 31;
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
            this.lbTxtContColums.TabIndex = 30;
            this.lbTxtContColums.Text = "Colunas:";
            // 
            // lbContRows
            // 
            this.lbContRows.AutoSize = true;
            this.lbContRows.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbContRows.Location = new System.Drawing.Point(884, 439);
            this.lbContRows.Name = "lbContRows";
            this.lbContRows.Size = new System.Drawing.Size(70, 15);
            this.lbContRows.TabIndex = 29;
            this.lbContRows.Text = "&&ContRows";
            // 
            // lbTxtContRows
            // 
            this.lbTxtContRows.AutoSize = true;
            this.lbTxtContRows.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTxtContRows.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbTxtContRows.Location = new System.Drawing.Point(829, 439);
            this.lbTxtContRows.Name = "lbTxtContRows";
            this.lbTxtContRows.Size = new System.Drawing.Size(58, 15);
            this.lbTxtContRows.TabIndex = 28;
            this.lbTxtContRows.Text = "Registros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "até:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(7, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 35;
            this.label1.Text = "Nº Ticket:";
            // 
            // tbxFilterNumTicketEnd
            // 
            this.tbxFilterNumTicketEnd.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterNumTicketEnd.Location = new System.Drawing.Point(137, 8);
            this.tbxFilterNumTicketEnd.Name = "tbxFilterNumTicketEnd";
            this.tbxFilterNumTicketEnd.Size = new System.Drawing.Size(42, 22);
            this.tbxFilterNumTicketEnd.TabIndex = 2;
            // 
            // tbxFilterNumTicketStart
            // 
            this.tbxFilterNumTicketStart.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.tbxFilterNumTicketStart.Location = new System.Drawing.Point(67, 8);
            this.tbxFilterNumTicketStart.Name = "tbxFilterNumTicketStart";
            this.tbxFilterNumTicketStart.Size = new System.Drawing.Size(42, 22);
            this.tbxFilterNumTicketStart.TabIndex = 1;
            // 
            // lbExporting
            // 
            this.lbExporting.AutoSize = true;
            this.lbExporting.Font = new System.Drawing.Font("Microsoft JhengHei", 6.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbExporting.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lbExporting.Location = new System.Drawing.Point(743, 455);
            this.lbExporting.Name = "lbExporting";
            this.lbExporting.Size = new System.Drawing.Size(65, 13);
            this.lbExporting.TabIndex = 39;
            this.lbExporting.Text = "Exportando...";
            this.lbExporting.UseWaitCursor = true;
            // 
            // btnSetSeq
            // 
            this.btnSetSeq.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSetSeq.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetSeq.Image = global::Migration.Properties.Resources.dataexport;
            this.btnSetSeq.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSetSeq.Location = new System.Drawing.Point(92, 443);
            this.btnSetSeq.Name = "btnSetSeq";
            this.btnSetSeq.Size = new System.Drawing.Size(176, 23);
            this.btnSetSeq.TabIndex = 10;
            this.btnSetSeq.Text = "Gerar Sequencial das ações";
            this.btnSetSeq.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSetSeq.UseVisualStyleBackColor = false;
            this.btnSetSeq.Click += new System.EventHandler(this.btnSetSeq_Click);
            // 
            // btnEraseGrid
            // 
            this.btnEraseGrid.Image = global::Migration.Properties.Resources.erase;
            this.btnEraseGrid.Location = new System.Drawing.Point(907, 6);
            this.btnEraseGrid.Name = "btnEraseGrid";
            this.btnEraseGrid.Size = new System.Drawing.Size(26, 26);
            this.btnEraseGrid.TabIndex = 7;
            this.btnEraseGrid.UseVisualStyleBackColor = true;
            this.btnEraseGrid.Click += new System.EventHandler(this.btnEraseGrid_Click);
            // 
            // btnFilterNumTicket
            // 
            this.btnFilterNumTicket.Image = ((System.Drawing.Image)(resources.GetObject("btnFilterNumTicket.Image")));
            this.btnFilterNumTicket.Location = new System.Drawing.Point(183, 6);
            this.btnFilterNumTicket.Name = "btnFilterNumTicket";
            this.btnFilterNumTicket.Size = new System.Drawing.Size(26, 26);
            this.btnFilterNumTicket.TabIndex = 3;
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
            this.btnExportXls.TabIndex = 9;
            this.btnExportXls.Text = "       Exportar";
            this.btnExportXls.UseVisualStyleBackColor = false;
            this.btnExportXls.Click += new System.EventHandler(this.btnExportXls_Click);
            // 
            // chxFilterAttachs
            // 
            this.chxFilterAttachs.AutoSize = true;
            this.chxFilterAttachs.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxFilterAttachs.Location = new System.Drawing.Point(233, 2);
            this.chxFilterAttachs.Name = "chxFilterAttachs";
            this.chxFilterAttachs.Size = new System.Drawing.Size(156, 19);
            this.chxFilterAttachs.TabIndex = 8;
            this.chxFilterAttachs.Text = "Exibir Colunas de anexos";
            this.chxFilterAttachs.UseVisualStyleBackColor = true;
            this.chxFilterAttachs.CheckedChanged += new System.EventHandler(this.chxFilterAttachs_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(416, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 15);
            this.label3.TabIndex = 41;
            this.label3.Text = "Status Relacionado:";
            // 
            // lbStatusFilter
            // 
            this.lbStatusFilter.AutoSize = true;
            this.lbStatusFilter.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatusFilter.Location = new System.Drawing.Point(524, 13);
            this.lbStatusFilter.Name = "lbStatusFilter";
            this.lbStatusFilter.Size = new System.Drawing.Size(75, 15);
            this.lbStatusFilter.TabIndex = 42;
            this.lbStatusFilter.Text = "&&StatusFilter";
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
            this.lbLoadingGrid.TabIndex = 44;
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
            this.progressBarLoadingGrid.TabIndex = 43;
            this.progressBarLoadingGrid.Value = 40;
            // 
            // chxAutoColsRows
            // 
            this.chxAutoColsRows.AutoSize = true;
            this.chxAutoColsRows.Font = new System.Drawing.Font("Microsoft JhengHei", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chxAutoColsRows.Location = new System.Drawing.Point(233, 18);
            this.chxAutoColsRows.Name = "chxAutoColsRows";
            this.chxAutoColsRows.Size = new System.Drawing.Size(144, 19);
            this.chxAutoColsRows.TabIndex = 45;
            this.chxAutoColsRows.Text = "Auto ajuste das Linhas";
            this.toolTip.SetToolTip(this.chxAutoColsRows, "Default: 15");
            this.chxAutoColsRows.UseVisualStyleBackColor = true;
            // 
            // frmReadConversationNotificationWorkOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(934, 471);
            this.Controls.Add(this.chxAutoColsRows);
            this.Controls.Add(this.lbLoadingGrid);
            this.Controls.Add(this.progressBarLoadingGrid);
            this.Controls.Add(this.lbStatusFilter);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbxFilterNumTicketEnd);
            this.Controls.Add(this.tbxFilterNumTicketStart);
            this.Controls.Add(this.chxFilterAttachs);
            this.Controls.Add(this.btnEraseGrid);
            this.Controls.Add(this.btnSetSeq);
            this.Controls.Add(this.lbExporting);
            this.Controls.Add(this.btnFilterNumTicket);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.lbContColums);
            this.Controls.Add(this.lbTxtContColums);
            this.Controls.Add(this.lbContRows);
            this.Controls.Add(this.lbTxtContRows);
            this.Controls.Add(this.btnExportXls);
            this.Controls.Add(this.dataGridViewConversationNotificationWorkOrder);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmReadConversationNotificationWorkOrder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cabeçalho / Ações / Anexos Tickets [Conversation/Notification]";
            this.Load += new System.EventHandler(this.frmReadConversationNotificationWorkOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewConversationNotificationWorkOrder)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.DataGridView dataGridViewConversationNotificationWorkOrder;
        private System.Windows.Forms.Button btnExportXls;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lbContColums;
        private System.Windows.Forms.Label lbTxtContColums;
        private System.Windows.Forms.Label lbContRows;
        private System.Windows.Forms.Label lbTxtContRows;
        private System.Windows.Forms.Button btnEraseGrid;
        private System.Windows.Forms.Button btnFilterNumTicket;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbxFilterNumTicketEnd;
        public System.Windows.Forms.TextBox tbxFilterNumTicketStart;
        private System.Windows.Forms.Label lbExporting;
        private System.Windows.Forms.Button btnSetSeq;
        public System.Windows.Forms.CheckBox chxFilterAttachs;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label lbStatusFilter;
        private System.Windows.Forms.Label lbLoadingGrid;
        private System.Windows.Forms.ProgressBar progressBarLoadingGrid;
        public System.Windows.Forms.CheckBox chxAutoColsRows;
        private System.Windows.Forms.ToolTip toolTip;
    }
}