namespace Migration
{
    partial class frmAnalysePlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAnalysePlan));
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxPlanLayoutActions = new System.Windows.Forms.TextBox();
            this.btnSelDirDestProcess = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.btnExecAnalyse = new System.Windows.Forms.Button();
            this.btnSelPlanLayoutAttach = new System.Windows.Forms.Button();
            this.tbxPlanLayoutTickets = new System.Windows.Forms.TextBox();
            this.tbxPlanLayoutPersons = new System.Windows.Forms.TextBox();
            this.btnSelDirDefaultAttachs = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(47, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 16);
            this.label3.TabIndex = 41;
            this.label3.Text = "Layout TICKETS ACTIONS:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(47, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 40;
            this.label2.Text = "Layout TICKETS:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(47, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 16);
            this.label1.TabIndex = 39;
            this.label1.Text = "Layout PERSONS:";
            // 
            // tbxPlanLayoutActions
            // 
            this.tbxPlanLayoutActions.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPlanLayoutActions.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlanLayoutActions.Location = new System.Drawing.Point(50, 115);
            this.tbxPlanLayoutActions.Name = "tbxPlanLayoutActions";
            this.tbxPlanLayoutActions.ReadOnly = true;
            this.tbxPlanLayoutActions.Size = new System.Drawing.Size(210, 22);
            this.tbxPlanLayoutActions.TabIndex = 37;
            // 
            // btnSelDirDestProcess
            // 
            this.btnSelDirDestProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnSelDirDestProcess.Image")));
            this.btnSelDirDestProcess.Location = new System.Drawing.Point(262, 113);
            this.btnSelDirDestProcess.Name = "btnSelDirDestProcess";
            this.btnSelDirDestProcess.Size = new System.Drawing.Size(26, 26);
            this.btnSelDirDestProcess.TabIndex = 36;
            this.btnSelDirDestProcess.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 169);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(334, 10);
            this.progressBar.Step = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 35;
            // 
            // btnExecAnalyse
            // 
            this.btnExecAnalyse.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecAnalyse.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnExecAnalyse.Image = global::Migration.Properties.Resources.dataexport;
            this.btnExecAnalyse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecAnalyse.Location = new System.Drawing.Point(106, 143);
            this.btnExecAnalyse.Name = "btnExecAnalyse";
            this.btnExecAnalyse.Size = new System.Drawing.Size(120, 23);
            this.btnExecAnalyse.TabIndex = 34;
            this.btnExecAnalyse.Text = "Executar Análise";
            this.btnExecAnalyse.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecAnalyse.UseVisualStyleBackColor = false;
            // 
            // btnSelPlanLayoutAttach
            // 
            this.btnSelPlanLayoutAttach.Image = ((System.Drawing.Image)(resources.GetObject("btnSelPlanLayoutAttach.Image")));
            this.btnSelPlanLayoutAttach.Location = new System.Drawing.Point(262, 22);
            this.btnSelPlanLayoutAttach.Name = "btnSelPlanLayoutAttach";
            this.btnSelPlanLayoutAttach.Size = new System.Drawing.Size(26, 26);
            this.btnSelPlanLayoutAttach.TabIndex = 30;
            this.btnSelPlanLayoutAttach.UseVisualStyleBackColor = true;
            // 
            // tbxPlanLayoutTickets
            // 
            this.tbxPlanLayoutTickets.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPlanLayoutTickets.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlanLayoutTickets.Location = new System.Drawing.Point(50, 69);
            this.tbxPlanLayoutTickets.Name = "tbxPlanLayoutTickets";
            this.tbxPlanLayoutTickets.ReadOnly = true;
            this.tbxPlanLayoutTickets.Size = new System.Drawing.Size(210, 22);
            this.tbxPlanLayoutTickets.TabIndex = 33;
            // 
            // tbxPlanLayoutPersons
            // 
            this.tbxPlanLayoutPersons.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPlanLayoutPersons.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlanLayoutPersons.Location = new System.Drawing.Point(50, 24);
            this.tbxPlanLayoutPersons.Name = "tbxPlanLayoutPersons";
            this.tbxPlanLayoutPersons.ReadOnly = true;
            this.tbxPlanLayoutPersons.Size = new System.Drawing.Size(210, 22);
            this.tbxPlanLayoutPersons.TabIndex = 31;
            // 
            // btnSelDirDefaultAttachs
            // 
            this.btnSelDirDefaultAttachs.Image = ((System.Drawing.Image)(resources.GetObject("btnSelDirDefaultAttachs.Image")));
            this.btnSelDirDefaultAttachs.Location = new System.Drawing.Point(262, 67);
            this.btnSelDirDefaultAttachs.Name = "btnSelDirDefaultAttachs";
            this.btnSelDirDefaultAttachs.Size = new System.Drawing.Size(26, 26);
            this.btnSelDirDefaultAttachs.TabIndex = 32;
            this.btnSelDirDefaultAttachs.UseVisualStyleBackColor = true;
            // 
            // frmAnalysePlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(333, 177);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbxPlanLayoutActions);
            this.Controls.Add(this.btnSelDirDestProcess);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExecAnalyse);
            this.Controls.Add(this.btnSelPlanLayoutAttach);
            this.Controls.Add(this.tbxPlanLayoutTickets);
            this.Controls.Add(this.tbxPlanLayoutPersons);
            this.Controls.Add(this.btnSelDirDefaultAttachs);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmAnalysePlan";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Análise Relacional de dados [Logs]";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox tbxPlanLayoutActions;
        private System.Windows.Forms.Button btnSelDirDestProcess;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button btnExecAnalyse;
        private System.Windows.Forms.Button btnSelPlanLayoutAttach;
        public System.Windows.Forms.TextBox tbxPlanLayoutTickets;
        public System.Windows.Forms.TextBox tbxPlanLayoutPersons;
        private System.Windows.Forms.Button btnSelDirDefaultAttachs;
    }
}