namespace Migration
{
    partial class frmMigrations
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMigrations));
            this.toolTipIniciar = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.conversãoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.processAttachToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.queryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.executarConsultasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.workOrderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conversãoToolStripMenuItem,
            this.queryToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(269, 24);
            this.menuStrip1.TabIndex = 23;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // conversãoToolStripMenuItem
            // 
            this.conversãoToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.conversãoToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ticketsToolStripMenuItem,
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem,
            this.processAttachToolStripMenuItem});
            this.conversãoToolStripMenuItem.Image = global::Migration.Properties.Resources.dataexport;
            this.conversãoToolStripMenuItem.Name = "conversãoToolStripMenuItem";
            this.conversãoToolStripMenuItem.Size = new System.Drawing.Size(91, 20);
            this.conversãoToolStripMenuItem.Text = "Conversão";
            // 
            // ticketsToolStripMenuItem
            // 
            this.ticketsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ticketsToolStripMenuItem.Image = global::Migration.Properties.Resources.dataexport;
            this.ticketsToolStripMenuItem.Name = "ticketsToolStripMenuItem";
            this.ticketsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ticketsToolStripMenuItem.Text = "Tickets";
            this.ticketsToolStripMenuItem.Click += new System.EventHandler(this.btnReadDataGridWO_Click);
            // 
            // ticketActionsConversationNotificationAttachmentsToolStripMenuItem
            // 
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.BackColor = System.Drawing.SystemColors.Control;
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.Image = global::Migration.Properties.Resources.dataexport;
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.Name = "ticketActionsConversationNotificationAttachmentsToolStripMenuItem";
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.Text = "Tickets Actions";
            this.ticketActionsConversationNotificationAttachmentsToolStripMenuItem.Click += new System.EventHandler(this.btnReadDataGridActWO_Click);
            // 
            // processAttachToolStripMenuItem
            // 
            this.processAttachToolStripMenuItem.Image = global::Migration.Properties.Resources.dataexport;
            this.processAttachToolStripMenuItem.Name = "processAttachToolStripMenuItem";
            this.processAttachToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.processAttachToolStripMenuItem.Text = "Attachments Archives";
            this.processAttachToolStripMenuItem.Click += new System.EventHandler(this.processAttachToolStripMenuItem_Click);
            // 
            // queryToolStripMenuItem
            // 
            this.queryToolStripMenuItem.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.queryToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.executarConsultasToolStripMenuItem,
            this.workOrderToolStripMenuItem,
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem});
            this.queryToolStripMenuItem.Image = global::Migration.Properties.Resources.readdatagridview;
            this.queryToolStripMenuItem.Name = "queryToolStripMenuItem";
            this.queryToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.queryToolStripMenuItem.Text = "Querys";
            // 
            // executarConsultasToolStripMenuItem
            // 
            this.executarConsultasToolStripMenuItem.Image = global::Migration.Properties.Resources.readdatagridview;
            this.executarConsultasToolStripMenuItem.Name = "executarConsultasToolStripMenuItem";
            this.executarConsultasToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.executarConsultasToolStripMenuItem.Text = "Consultas não Parametrizadas";
            this.executarConsultasToolStripMenuItem.Click += new System.EventHandler(this.executarConsultasToolStripMenuItem_Click);
            // 
            // workOrderToolStripMenuItem
            // 
            this.workOrderToolStripMenuItem.Image = global::Migration.Properties.Resources.readdatagridview;
            this.workOrderToolStripMenuItem.Name = "workOrderToolStripMenuItem";
            this.workOrderToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.workOrderToolStripMenuItem.Text = "WorkOrder";
            // 
            // conversationNotificationAttachmentsResolutionToolStripMenuItem
            // 
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem.Image = global::Migration.Properties.Resources.readdatagridview;
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem.Name = "conversationNotificationAttachmentsResolutionToolStripMenuItem";
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem.Size = new System.Drawing.Size(346, 22);
            this.conversationNotificationAttachmentsResolutionToolStripMenuItem.Text = "Conversation/Notification/Attachments/Resolution";
            // 
            // frmMigrations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(269, 26);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMigrations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Migração de dados";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolTip toolTipIniciar;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem conversãoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ticketActionsConversationNotificationAttachmentsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem processAttachToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem queryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem workOrderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conversationNotificationAttachmentsResolutionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem executarConsultasToolStripMenuItem;
    }
}

