using Microsoft.SqlServer.Server;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migration
{
    public partial class frmQuery : Form
    {
        ConnectDB connection = new ConnectDB();
        Querys query = new Querys();

        public frmQuery()
        {
            InitializeComponent();
            Text = "Banco de dados Configurado para consultas: [" + connection.dataBase + "]";
        }

        private void btnExecQuery_Click(object sender, EventArgs e)
        {
            Select();
        }

        private void btnResetText_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        public void Select()
        {
            if (tbxTextQuery.Text == string.Empty || String.IsNullOrEmpty(tbxTextQuery.Text) || tbxTextQuery.Text == "Digite ou cole a consulta aqui...")
            {
                MessageBox.Show("Digite uma consulta com estrutura válida...");
                MessageBox.Show(query.queryReturn);
            }
            else
            {
                dataGridViewQuerys.DataSource = query.Select(tbxTextQuery.SelectedText);
            }
            if (dataGridViewQuerys.Rows.Count > 0)
            {
                Size = new Size(1027, 398);
            }
            else
            {
                Size = new Size(574, 398);
            }
        }
            
        private void ResetFields()
        {
            tbxTextQuery.Text = string.Empty;
            dataGridViewQuerys.DataSource = query.Select(tbxTextQuery.SelectedText);
            //dataGridViewQuerys.DataSource = null;

            Size = new Size(574, 398);
        }

        private void btnStopExecution_Click(object sender, EventArgs e)
        {
            connection.Desconectar();
            MessageBox.Show("Conexão com o Banco de dados " + connection.dataBase +  " Interrompida!");
        }

        private void btnOpenText_Click(object sender, EventArgs e)
        {
            SelectArchive();
        }

        public void SelectArchive()
        {
            tbxTextQuery.Text = string.Empty;

            SelectArchivesPropirters();
            DialogResult diag = this.openFileDialog.ShowDialog();
            
            string filepath = openFileDialog.FileName;
            string fileContent = File.ReadAllText(filepath);

            tbxTextQuery.Text = fileContent;

            if (openFileDialog.FileName == string.Empty)
            {
                return;
            }
        }

        public void SelectArchivesPropirters()
        {
            openFileDialog.Title = "Selecionar arquivos que contém Estrutura SQL ou Texto";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = ("Procedure SQL|*.sql|Texto|*.txt");
        }
    }
}
