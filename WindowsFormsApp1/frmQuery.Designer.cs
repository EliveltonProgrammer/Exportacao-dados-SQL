namespace Migration
{
    partial class frmQuery
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmQuery));
            this.tbxTextQuery = new System.Windows.Forms.RichTextBox();
            this.btnExecQuery = new System.Windows.Forms.Button();
            this.dataGridViewQuerys = new System.Windows.Forms.DataGridView();
            this.btnResetText = new System.Windows.Forms.Button();
            this.btnStopExecution = new System.Windows.Forms.Button();
            this.btnOpenText = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuerys)).BeginInit();
            this.SuspendLayout();
            // 
            // tbxTextQuery
            // 
            this.tbxTextQuery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbxTextQuery.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxTextQuery.Location = new System.Drawing.Point(10, 12);
            this.tbxTextQuery.Name = "tbxTextQuery";
            this.tbxTextQuery.Size = new System.Drawing.Size(540, 307);
            this.tbxTextQuery.TabIndex = 0;
            this.tbxTextQuery.Text = "Digite ou cole a consulta aqui...";
            // 
            // btnExecQuery
            // 
            this.btnExecQuery.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExecQuery.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnExecQuery.Image = global::Migration.Properties.Resources.dataexport;
            this.btnExecQuery.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExecQuery.Location = new System.Drawing.Point(6, 333);
            this.btnExecQuery.Name = "btnExecQuery";
            this.btnExecQuery.Size = new System.Drawing.Size(117, 23);
            this.btnExecQuery.TabIndex = 23;
            this.btnExecQuery.Text = "Executar Query";
            this.btnExecQuery.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExecQuery.UseVisualStyleBackColor = false;
            this.btnExecQuery.Click += new System.EventHandler(this.btnExecQuery_Click);
            // 
            // dataGridViewQuerys
            // 
            this.dataGridViewQuerys.AllowUserToAddRows = false;
            this.dataGridViewQuerys.AllowUserToDeleteRows = false;
            this.dataGridViewQuerys.AllowUserToOrderColumns = true;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dataGridViewQuerys.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewQuerys.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewQuerys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewQuerys.Location = new System.Drawing.Point(574, 47);
            this.dataGridViewQuerys.Name = "dataGridViewQuerys";
            this.dataGridViewQuerys.ReadOnly = true;
            this.dataGridViewQuerys.Size = new System.Drawing.Size(428, 251);
            this.dataGridViewQuerys.TabIndex = 24;
            // 
            // btnResetText
            // 
            this.btnResetText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnResetText.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnResetText.Image = global::Migration.Properties.Resources.erase;
            this.btnResetText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnResetText.Location = new System.Drawing.Point(480, 333);
            this.btnResetText.Name = "btnResetText";
            this.btnResetText.Size = new System.Drawing.Size(73, 23);
            this.btnResetText.TabIndex = 25;
            this.btnResetText.Text = "Limpar";
            this.btnResetText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnResetText.UseVisualStyleBackColor = false;
            this.btnResetText.Click += new System.EventHandler(this.btnResetText_Click);
            // 
            // btnStopExecution
            // 
            this.btnStopExecution.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnStopExecution.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnStopExecution.Image = global::Migration.Properties.Resources.dataexport;
            this.btnStopExecution.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnStopExecution.Location = new System.Drawing.Point(125, 333);
            this.btnStopExecution.Name = "btnStopExecution";
            this.btnStopExecution.Size = new System.Drawing.Size(97, 23);
            this.btnStopExecution.TabIndex = 26;
            this.btnStopExecution.Text = "Interromper";
            this.btnStopExecution.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStopExecution.UseVisualStyleBackColor = false;
            this.btnStopExecution.Click += new System.EventHandler(this.btnStopExecution_Click);
            // 
            // btnOpenText
            // 
            this.btnOpenText.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpenText.Font = new System.Drawing.Font("Microsoft YaHei", 8.25F);
            this.btnOpenText.Image = global::Migration.Properties.Resources.dataexport;
            this.btnOpenText.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOpenText.Location = new System.Drawing.Point(224, 333);
            this.btnOpenText.Name = "btnOpenText";
            this.btnOpenText.Size = new System.Drawing.Size(105, 23);
            this.btnOpenText.TabIndex = 27;
            this.btnOpenText.Text = "Abrir arquivo";
            this.btnOpenText.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOpenText.UseVisualStyleBackColor = false;
            this.btnOpenText.Click += new System.EventHandler(this.btnOpenText_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // frmQuery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(558, 359);
            this.Controls.Add(this.btnOpenText);
            this.Controls.Add(this.btnStopExecution);
            this.Controls.Add(this.btnResetText);
            this.Controls.Add(this.dataGridViewQuerys);
            this.Controls.Add(this.btnExecQuery);
            this.Controls.Add(this.tbxTextQuery);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmQuery";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewQuerys)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.RichTextBox tbxTextQuery;
        private System.Windows.Forms.Button btnExecQuery;
        public System.Windows.Forms.DataGridView dataGridViewQuerys;
        private System.Windows.Forms.Button btnResetText;
        private System.Windows.Forms.Button btnStopExecution;
        private System.Windows.Forms.Button btnOpenText;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}