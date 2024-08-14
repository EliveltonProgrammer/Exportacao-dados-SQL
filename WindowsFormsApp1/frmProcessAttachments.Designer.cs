namespace Migration
{
    partial class frmProcessAttachments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProcessAttachments));
            this.btnSelPlanLayoutAttach = new System.Windows.Forms.Button();
            this.tbxDiscDefaultAttachs = new System.Windows.Forms.TextBox();
            this.tbxPlanLayoutAttach = new System.Windows.Forms.TextBox();
            this.btnSelDirDefaultAttachs = new System.Windows.Forms.Button();
            this.btnExecDirectorys = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.tbxSelDirDestProcess = new System.Windows.Forms.TextBox();
            this.btnSelDirDestProcess = new System.Windows.Forms.Button();
            this.btnExecCopy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.chxActiveCopyAttachs = new System.Windows.Forms.CheckBox();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // btnSelPlanLayoutAttach
            // 
            this.btnSelPlanLayoutAttach.Image = ((System.Drawing.Image)(resources.GetObject("btnSelPlanLayoutAttach.Image")));
            this.btnSelPlanLayoutAttach.Location = new System.Drawing.Point(245, 18);
            this.btnSelPlanLayoutAttach.Name = "btnSelPlanLayoutAttach";
            this.btnSelPlanLayoutAttach.Size = new System.Drawing.Size(26, 26);
            this.btnSelPlanLayoutAttach.TabIndex = 18;
            this.btnSelPlanLayoutAttach.UseVisualStyleBackColor = true;
            this.btnSelPlanLayoutAttach.Click += new System.EventHandler(this.btnSelPlanAttach_Click);
            // 
            // tbxDiscDefaultAttachs
            // 
            this.tbxDiscDefaultAttachs.BackColor = System.Drawing.SystemColors.Window;
            this.tbxDiscDefaultAttachs.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxDiscDefaultAttachs.Location = new System.Drawing.Point(33, 65);
            this.tbxDiscDefaultAttachs.Name = "tbxDiscDefaultAttachs";
            this.tbxDiscDefaultAttachs.ReadOnly = true;
            this.tbxDiscDefaultAttachs.Size = new System.Drawing.Size(210, 22);
            this.tbxDiscDefaultAttachs.TabIndex = 21;
            this.tbxDiscDefaultAttachs.Text = "Selecionar unidade dos anexos";
            // 
            // tbxPlanLayoutAttach
            // 
            this.tbxPlanLayoutAttach.BackColor = System.Drawing.SystemColors.Window;
            this.tbxPlanLayoutAttach.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPlanLayoutAttach.Location = new System.Drawing.Point(33, 20);
            this.tbxPlanLayoutAttach.Name = "tbxPlanLayoutAttach";
            this.tbxPlanLayoutAttach.ReadOnly = true;
            this.tbxPlanLayoutAttach.Size = new System.Drawing.Size(210, 22);
            this.tbxPlanLayoutAttach.TabIndex = 19;
            this.tbxPlanLayoutAttach.Text = "Selecionar Layout XLS convertido";
            // 
            // btnSelDirDefaultAttachs
            // 
            this.btnSelDirDefaultAttachs.Image = ((System.Drawing.Image)(resources.GetObject("btnSelDirDefaultAttachs.Image")));
            this.btnSelDirDefaultAttachs.Location = new System.Drawing.Point(245, 63);
            this.btnSelDirDefaultAttachs.Name = "btnSelDirDefaultAttachs";
            this.btnSelDirDefaultAttachs.Size = new System.Drawing.Size(26, 26);
            this.btnSelDirDefaultAttachs.TabIndex = 20;
            this.btnSelDirDefaultAttachs.UseVisualStyleBackColor = true;
            this.btnSelDirDefaultAttachs.Click += new System.EventHandler(this.btnSelDirDefaultAttachs_Click);
            // 
            // btnExecDirectorys
            // 
            this.btnExecDirectorys.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecDirectorys.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnExecDirectorys.Image = global::Migration.Properties.Resources.dataexport;
            this.btnExecDirectorys.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecDirectorys.Location = new System.Drawing.Point(33, 144);
            this.btnExecDirectorys.Name = "btnExecDirectorys";
            this.btnExecDirectorys.Size = new System.Drawing.Size(114, 23);
            this.btnExecDirectorys.TabIndex = 22;
            this.btnExecDirectorys.Text = "Gerar Diretórios";
            this.btnExecDirectorys.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecDirectorys.UseVisualStyleBackColor = false;
            this.btnExecDirectorys.Click += new System.EventHandler(this.btnExecDirectorys_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 169);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(303, 10);
            this.progressBar.Step = 0;
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 23;
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // tbxSelDirDestProcess
            // 
            this.tbxSelDirDestProcess.BackColor = System.Drawing.SystemColors.Window;
            this.tbxSelDirDestProcess.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxSelDirDestProcess.Location = new System.Drawing.Point(33, 111);
            this.tbxSelDirDestProcess.Name = "tbxSelDirDestProcess";
            this.tbxSelDirDestProcess.ReadOnly = true;
            this.tbxSelDirDestProcess.Size = new System.Drawing.Size(210, 22);
            this.tbxSelDirDestProcess.TabIndex = 25;
            this.tbxSelDirDestProcess.Text = "Selecionar diretório de destino";
            // 
            // btnSelDirDestProcess
            // 
            this.btnSelDirDestProcess.Image = ((System.Drawing.Image)(resources.GetObject("btnSelDirDestProcess.Image")));
            this.btnSelDirDestProcess.Location = new System.Drawing.Point(245, 109);
            this.btnSelDirDestProcess.Name = "btnSelDirDestProcess";
            this.btnSelDirDestProcess.Size = new System.Drawing.Size(26, 26);
            this.btnSelDirDestProcess.TabIndex = 24;
            this.btnSelDirDestProcess.UseVisualStyleBackColor = true;
            this.btnSelDirDestProcess.Click += new System.EventHandler(this.btnSelDirDestProcess_Click);
            // 
            // btnExecCopy
            // 
            this.btnExecCopy.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecCopy.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnExecCopy.Image = global::Migration.Properties.Resources.dataexport;
            this.btnExecCopy.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecCopy.Location = new System.Drawing.Point(150, 144);
            this.btnExecCopy.Name = "btnExecCopy";
            this.btnExecCopy.Size = new System.Drawing.Size(121, 23);
            this.btnExecCopy.TabIndex = 26;
            this.btnExecCopy.Text = "     Copiar Anexos";
            this.btnExecCopy.UseVisualStyleBackColor = false;
            this.btnExecCopy.Click += new System.EventHandler(this.btnExecCopy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(30, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 27;
            this.label1.Text = "Layout:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label2.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 28;
            this.label2.Text = "Unidade Default anexos:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.label3.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label3.Location = new System.Drawing.Point(30, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(123, 16);
            this.label3.TabIndex = 29;
            this.label3.Text = "Diretório de gravação:";
            // 
            // chxActiveCopyAttachs
            // 
            this.chxActiveCopyAttachs.AutoSize = true;
            this.chxActiveCopyAttachs.Location = new System.Drawing.Point(10, 149);
            this.chxActiveCopyAttachs.Name = "chxActiveCopyAttachs";
            this.chxActiveCopyAttachs.Size = new System.Drawing.Size(15, 14);
            this.chxActiveCopyAttachs.TabIndex = 30;
            this.toolTip.SetToolTip(this.chxActiveCopyAttachs, "Selecione caso, a Estrutura de diretórios tenha sido gerada \r\n   conforme Layout " +
        "carregado de Attachments_ToRead");
            this.chxActiveCopyAttachs.UseVisualStyleBackColor = true;
            this.chxActiveCopyAttachs.CheckedChanged += new System.EventHandler(this.chxActiveCopyAttachs_CheckedChanged);
            // 
            // frmProcessAttachments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(301, 177);
            this.Controls.Add(this.chxActiveCopyAttachs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnExecCopy);
            this.Controls.Add(this.tbxSelDirDestProcess);
            this.Controls.Add(this.btnSelDirDestProcess);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnExecDirectorys);
            this.Controls.Add(this.btnSelPlanLayoutAttach);
            this.Controls.Add(this.tbxDiscDefaultAttachs);
            this.Controls.Add(this.tbxPlanLayoutAttach);
            this.Controls.Add(this.btnSelDirDefaultAttachs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmProcessAttachments";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Anexos [Attachments]";
            this.Load += new System.EventHandler(this.frmProcessAttachments_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSelPlanLayoutAttach;
        public System.Windows.Forms.TextBox tbxDiscDefaultAttachs;
        public System.Windows.Forms.TextBox tbxPlanLayoutAttach;
        private System.Windows.Forms.Button btnSelDirDefaultAttachs;
        private System.Windows.Forms.Button btnExecDirectorys;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        public System.Windows.Forms.TextBox tbxSelDirDestProcess;
        private System.Windows.Forms.Button btnSelDirDestProcess;
        private System.Windows.Forms.Button btnExecCopy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chxActiveCopyAttachs;
        private System.Windows.Forms.ToolTip toolTip;
    }
}