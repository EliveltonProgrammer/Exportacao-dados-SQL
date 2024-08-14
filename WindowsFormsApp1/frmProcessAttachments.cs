using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Migration
{
    public partial class frmProcessAttachments : Form
    {
        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool CopyFile(string lpExistingFileName, string lpNewFileName, bool bFailIfExists);

        public frmProcessAttachments()
        {
            InitializeComponent();
        }

        private void frmProcessAttachments_Load(object sender, EventArgs e)
        {
            tbxPlanLayoutAttach.Text = @"C:\Attachments_ToRead.xlsx";
            tbxDiscDefaultAttachs.Text = @"Y:\";
            tbxSelDirDestProcess.Text = @"C:\Movidesk\Anexos\";
            btnExecCopy.Enabled = false;
            progressBar.Visible = false;
            progressBar.Value = 0;
        }

        public void btnSelPlanAttach_Click(object sender, EventArgs e)
        {
            SelectArchivePlanConvert();
        }

        public void btnSelDirDefaultAttachs_Click(object sender, EventArgs e)
        {
            SelectDirectorysAttachsDefault();
        }

        private void btnSelDirDestProcess_Click(object sender, EventArgs e)
        {
            SelectDirectoryDestProcess();
        }

        private void btnExecDirectorys_Click(object sender, EventArgs e)
        {
            CreateDirectorysAttachs();
        }

        private void btnExecCopy_Click(object sender, EventArgs e)
        {
            CopyAttachsDirectorys();
        }

        public void SelectArchivePlanConvert()
        {
            tbxPlanLayoutAttach.Text = string.Empty;

            SelectArchivesPropirters();
            DialogResult diag = this.openFileDialog.ShowDialog();
            tbxPlanLayoutAttach.Text = openFileDialog.FileName;
        }

        public void SelectDirectorysAttachsDefault()
        {
            tbxDiscDefaultAttachs.Text = string.Empty;

            SelectDirectorysPropierts();
            DialogResult diag = this.folderBrowserDialog.ShowDialog();
            tbxDiscDefaultAttachs.Text = folderBrowserDialog.SelectedPath;
        }

        public void SelectDirectoryDestProcess()
        {
            tbxSelDirDestProcess.Text = string.Empty;

            SelectDirectorysPropierts();
            DialogResult diag = this.folderBrowserDialog.ShowDialog();
            tbxSelDirDestProcess.Text = folderBrowserDialog.SelectedPath + "\\";
        }

        public void SelectDirectorysPropierts()
        {
            folderBrowserDialog.Description = "Selecionar Diretório de destino do Processo";
        }

        public void SelectArchivesPropirters()
        {
            openFileDialog.Title = "Selecionar arquivo Planilha anexos: Attachments";
            openFileDialog.InitialDirectory = "C:\\";
            openFileDialog.Filter = ("Planilha XLSX | *.xlsx|Planilha XLS|*.xls");
        }

        public async void CreateDirectorysAttachs()
        {
            btnExecDirectorys.Enabled = false;
            btnExecCopy.Enabled = false;
            progressBar.Visible = true;
            {
                if (!Directory.Exists(tbxSelDirDestProcess.Text))
                {
                    Directory.CreateDirectory(tbxSelDirDestProcess.Text);
                }

                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(tbxPlanLayoutAttach.Text); //lendo Textbox
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];

                string celValue1 = worksheet.Cells[1, 1].Value;
                string celValue2 = worksheet.Cells[1, 2].Value;
                string celValue3 = worksheet.Cells[1, 3].Value;
                string celValue4 = worksheet.Cells[1, 4].Value;

                if (celValue1 == "Ticket" && celValue2 == "Sequencia" && celValue3 == "Diretório" && celValue4 == "Nome Arquivo")
                {
                    try
                    {
                        for (int i = 2; i <= worksheet.UsedRange.Rows.Count; i++)
                        {
                            string col1 = worksheet.Cells[i, 1].Value.ToString();
                            string col2 = worksheet.Cells[i, 2].Value.ToString();
                            string subDiretorio = Path.Combine(col1, col2);

                            progressBar.Value = 30;

                            if (!Directory.Exists(col1))
                            {
                                Directory.CreateDirectory(tbxSelDirDestProcess.Text + col1);
                            }
                            progressBar.Value = 60;

                            if (!Directory.Exists(subDiretorio))
                            {
                                Directory.CreateDirectory(tbxSelDirDestProcess.Text + subDiretorio);
                            }
                            progressBar.Value = 90;
                        }
                        workbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        /*workbook.Close();
                        excelApp.Quit();
                        Marshal.ReleaseComObject(worksheet);
                        Marshal.ReleaseComObject(workbook);
                        Marshal.ReleaseComObject(excelApp);*/

                        if (MessageBox.Show("Processo Finalizado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;
                        {
                            if (MessageBox.Show("Abrir o diretório de destino?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                Process.Start(tbxSelDirDestProcess.Text);
                            }
                        }
                        if (MessageBox.Show("Iniciar Processo de Separação/Cópia dos anexos?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            CopyAttachsDirectorys();
                        }
                        if (MessageBox.Show("Optado por não Executar o Processo!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Question) == DialogResult.Yes) ;
                        {
                            progressBar.Visible = false;
                            progressBar.Value = 0;
                            return;
                        }
                    }
                    catch
                    {
                    }
                    progressBar.Value = 100;
                    progressBar.Value = 0;
                    progressBar.Visible = false;
                    btnExecCopy.Enabled = true;
                }
                else
                {
                    if (MessageBox.Show("Layout XLS Attachments_ToRead ['Ticket', 'Sequencia', 'Diretório', 'Nome Arquivo'] consta-se incorreto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes)
                        workbook.Close();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    return;
                }
            }
        }




        public async void CopyAttachsDirectorys()
        {
            btnExecDirectorys.Enabled = false;
            btnExecCopy.Enabled = false;
            progressBar.Visible = true;
            {
                Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook workbook = excelApp.Workbooks.Open(tbxPlanLayoutAttach.Text); //lendo Textbox
                Microsoft.Office.Interop.Excel.Worksheet worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets[1];
                Range xlRange = worksheet.UsedRange;

                string celValue1 = worksheet.Cells[1, 1].Value;
                string celValue2 = worksheet.Cells[1, 2].Value;
                string celValue3 = worksheet.Cells[1, 3].Value;
                string celValue4 = worksheet.Cells[1, 4].Value;

                if (celValue1 == "Ticket" && celValue2 == "Sequencia" && celValue3 == "Diretório" && celValue4 == "Nome Arquivo")
                {
                    try
                    {
                        progressBar.Value = 20;

                        int rowCount = xlRange.Rows.Count;
                        int colCount = xlRange.Columns.Count;

                        progressBar.Value = 30;

                        for (int i = 2; i <= rowCount; i++)
                        {
                            string directory = (xlRange.Cells[i, 1] as Range).Value2.ToString();
                            string subDirectory = (xlRange.Cells[i, 2] as Range).Value2.ToString();
                            string fileDirectory = (xlRange.Cells[i, 3] as Range).Value2.ToString();
                            string fileName = (xlRange.Cells[i, 4] as Range).Value2.ToString();

                            progressBar.Value = 40;

                            string numTicket = directory;
                            string numAction = subDirectory;
                            string sourcePath = tbxDiscDefaultAttachs.Text + fileDirectory + "\\" + fileName;
                            string targetPath = tbxSelDirDestProcess.Text + directory + "\\" + subDirectory + "\\" + fileName;

                            string logPathCopied = tbxSelDirDestProcess.Text + "log_arquivos_copiados.txt";
                            string logPathErrCopy = tbxSelDirDestProcess.Text + "log_arquivos_nao_encontrados.txt";

                            /*if (File.Exists(logPathCopied) || File.Exists(logPathErrCopy))
                            {
                                File.Delete(logPathCopied);
                                File.Delete(logPathErrCopy);
                            }*/
                            try
                            {
                                progressBar.Value = 50;

                                if (File.Exists(sourcePath))
                                {
                                    CopyFile(sourcePath, targetPath, false);
                                    //File.Copy(sourcePath, targetPath, true); //utilizado anteriormente

                                    // Escreve o log no arquivo de arquivos copiados
                                    using (StreamWriter sw = File.AppendText(logPathCopied))
                                    {
                                        sw.WriteLine("Diretório completo: " + sourcePath);
                                        sw.WriteLine("Arquivo: " + fileName);
                                        sw.WriteLine("Ticket: " + numTicket);
                                        sw.WriteLine("Sequencia da ação: " + numAction);
                                        sw.WriteLine("Data e hora: " + DateTime.Now.ToString());
                                        sw.WriteLine();
                                    }
                                }
                                else
                                {
                                    // Escreve o log no arquivo de arquivos não copiados
                                    using (StreamWriter sw = File.AppendText(logPathErrCopy))
                                    {
                                        sw.WriteLine("Diretório do Arquivo não encontrado: " + sourcePath);
                                        sw.WriteLine("Arquivo: " + fileName);
                                        sw.WriteLine("Ticket: " + numTicket);
                                        sw.WriteLine("Sequencia da ação: " + numAction);
                                        sw.WriteLine("Data e hora: " + DateTime.Now.ToString());
                                        sw.WriteLine();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                // Escreve o log no arquivo de arquivos não copiados
                                using (StreamWriter sw = File.AppendText(logPathErrCopy))
                                {
                                    sw.WriteLine("Erro ao copiar arquivo: " + ex.Message);
                                    sw.WriteLine("Arquivo: " + fileName);
                                    sw.WriteLine("Ticket: " + numTicket);
                                    sw.WriteLine("Sequencia da ação: " + numAction);
                                    sw.WriteLine("Data e hora: " + DateTime.Now.ToString());
                                    sw.WriteLine();
                                }
                                progressBar.Value = 70;
                            }
                            /*try
                             {
                                 progressBar.Value = 70;

                                 string sourceDirectoryEmlMsg = tbxDiscDefaultAttachs.Text + fileDirectory;
                                 string destinationDirectoryEmlMsg = tbxSelDirDestProcess.Text + directory + "\\" + subDirectory;

                                 string[] sourceFilesEmlMsg = Directory.GetFiles(sourceDirectoryEmlMsg, "*", SearchOption.TopDirectoryOnly)
                                 .Where(s => s.EndsWith(".msg") || s.EndsWith(".eml"))
                                 .ToArray();

                                 foreach (string sourceFilePathEmlMsg in sourceFilesEmlMsg)
                                 {
                                     string fileNameEmlMsg = Path.GetFileName(sourceFilePathEmlMsg);
                                     string destinationFilePathEmlMsg = Path.Combine(destinationDirectoryEmlMsg, fileNameEmlMsg);

                                     using (FileStream sourceStream = new FileStream(sourceFilePathEmlMsg, FileMode.Open))
                                     using (FileStream destinationStream = new FileStream(destinationFilePathEmlMsg, FileMode.CreateNew))
                                     {
                                         sourceStream.CopyTo(destinationStream);

                                         // Escreve o log no arquivo de arquivos copiados
                                         using (StreamWriter sw = File.AppendText(logPathCopied))
                                         {
                                             sw.WriteLine("Arquivo copiado: " + sourceFilePathEmlMsg);
                                             sw.WriteLine("Origem: " + sourcePath);
                                             sw.WriteLine("Data e hora: " + DateTime.Now.ToString());
                                             sw.WriteLine();
                                         }
                                     }
                                 }*/
                            progressBar.Value = 95;
                        }
                        workbook.Close();
                        excelApp.Quit();
                        System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                        /*workbook.Close();
                        excelApp.Quit();
                        Marshal.ReleaseComObject(worksheet);
                        Marshal.ReleaseComObject(workbook);
                        Marshal.ReleaseComObject(excelApp);*/
                        {
                            if (MessageBox.Show("Processo Finalizado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;
                            {
                                if (MessageBox.Show("Abrir o diretório de destino?", "Mensagem", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                                {
                                    Process.Start(tbxSelDirDestProcess.Text);
                                }
                                progressBar.Value = 98;
                            }
                        }
                    }
                    catch
                    {
                    }
                    progressBar.Value = 100;
                    progressBar.Value = 0;
                    progressBar.Visible = false;
                    btnExecCopy.Enabled = false;
                    btnExecDirectorys.Enabled = true;
                }
                else
                {
                    if (MessageBox.Show("Layout XLS Attachments_ToRead ['Ticket'|'Sequencia'|'Diretório'|'Nome Arquivo'] consta-se incorreto!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes)
                        workbook.Close();
                    excelApp.Quit();
                    System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
                    return;
                }
            }
        }

        private void chxActiveCopyAttachs_CheckedChanged(object sender, EventArgs e)
        {
            if (chxActiveCopyAttachs.Checked == true)
            {
                btnExecCopy.Enabled = true;
                btnExecDirectorys.Enabled = false;
            }
            else
            {
                btnExecCopy.Enabled = false;
                btnExecDirectorys.Enabled = true;
            }
        }
    }
}