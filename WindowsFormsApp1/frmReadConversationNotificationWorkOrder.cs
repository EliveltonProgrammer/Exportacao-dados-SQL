using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.IO;
using System.Windows.Forms.VisualStyles;
using System.Globalization;

namespace Migration
{
    public partial class frmReadConversationNotificationWorkOrder : Form
    {
        Migration_ConversationNotification_WorkOrder mgActWO = new Migration_ConversationNotification_WorkOrder();
        //Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();

        bool executing = false;
        bool executingExport = false;

        public static string CNNumTicketStart = frmReadWorkOrder.WONumTicketStart;
        public static string CNNumTicketEnd = frmReadWorkOrder.WONumTicketEnd;
        public static string CNStatusTicket = frmReadWorkOrder.WOStatusTicket;

        public frmReadConversationNotificationWorkOrder()
        {
            InitializeComponent();
        }

        private void frmReadConversationNotificationWorkOrder_Load(object sender, EventArgs e)
        {
            ProgressActionsAuto();
            chxFilterAttachs.Enabled = false;
            btnExportXls.Enabled = false;
            btnSetSeq.Enabled = false;
            progressBar.Visible = false;
            lbExporting.Visible = false;
            lbContRows.Text = "0";
            lbContColums.Text = "0";
        }

        private void btnFilterNumTicket_Click(object sender, EventArgs e)
        {
            FilterIntervalNumber();
        }

        private void btnEraseGrid_Click(object sender, EventArgs e)
        {
            EraseGrid();
        }

        public void btnExportXls_Click(object sender, EventArgs e)
        {
            ExportGridXls();
        }

        private void btnSetSeq_Click(object sender, EventArgs e)
        {
            SequenceRows();
        }

        public async void ProgressActionsAuto()
        {
            try
            {
                if (dataGridViewConversationNotificationWorkOrder.Rows.Count == 0)
                {
                    progressBarLoadingGrid.Visible = true;
                    lbLoadingGrid.Visible = true;
                }
                else if (dataGridViewConversationNotificationWorkOrder.Rows.Count > 0)
                {
                    progressBarLoadingGrid.Visible = false;
                    lbLoadingGrid.Visible = false;
                }

                progressBarLoadingGrid.Visible = false;
                lbLoadingGrid.Visible = false;
            }
            catch (Exception ex) { }
        }

        private void dataGridViewConversationNotificationWorkOrder_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == 6 && e.Value != null || Convert.ToString(e.Value) != string.Empty)
            {
                String textConverted = Regex.Replace(Convert.ToString(e.Value), "<.*?>|</.*?>", " "); ; ;
                e.Value = textConverted;
            }
            if (dataGridViewConversationNotificationWorkOrder.Columns[e.ColumnIndex].Name == "Texto Conversa" && e.Value == null)
            {
                e.Value = "<img>";
                e.FormattingApplied = true;
            }
        }

        private void EraseGrid()
        {
            if (dataGridViewConversationNotificationWorkOrder.Rows.Count > 0)
            {
                chxFilterAttachs.Enabled = false;
                btnExportXls.Enabled = false;

                dataGridViewConversationNotificationWorkOrder.Columns.Clear();
                dataGridViewConversationNotificationWorkOrder.Refresh();
            }

            if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
            {
                MessageBox.Show("Intervalo dos Tickets não definido corretamente.");
            }
            else
            {
                CNStatusTicket = frmReadWorkOrder.WOStatusTicket;
                mgActWO.SelectActionsWorkOrderNumber(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text), CNStatusTicket);
            }
        }

        public async void FilterIntervalNumber()
        {
            try
            {
                if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                {
                    if (MessageBox.Show("Intervalo por Nº Ticket não definido corretamente!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;

                    chxFilterAttachs.Enabled = false;
                    btnExportXls.Enabled = false;
                    btnSetSeq.Enabled = false;
                }

                else if (dataGridViewConversationNotificationWorkOrder.Rows.Count > 0)
                {
                    chxFilterAttachs.Enabled = true;
                    dataGridViewConversationNotificationWorkOrder.Columns.Clear();
                }
                else if (dataGridViewConversationNotificationWorkOrder.Rows.Count == 0)
                {
                    chxFilterAttachs.Enabled = true;
                    btnExportXls.Enabled = true;
                    btnSetSeq.Enabled = true;
                    executing = true;

                    Processing();

                    if (tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty && chxFilterAttachs.Checked == false)
                    {
                        dataGridViewConversationNotificationWorkOrder.DataSource = mgActWO.SelectActionsWorkOrderNumber(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text), CNStatusTicket);
                    }

                    //Total linhas
                    for (int i = 1; i < dataGridViewConversationNotificationWorkOrder.Rows.Count + 1; i++)
                    {
                        lbContRows.Text = i.ToString();
                    }
                    //Total colunas
                    for (int i = 1; i < dataGridViewConversationNotificationWorkOrder.Columns.Count + 1; i++)
                    {
                        lbContColums.Text = i.ToString();
                    }
                }
                executing = false;
                Processing();
            }
            catch (Exception ex) { }
        }


        public void SequenceRows()
        {
            try
            {
                //adiciona coluna 'Sequencia' no DataGridView
                DataGridViewColumn rowSeq = new DataGridViewColumn();
                rowSeq.HeaderText = "Sequencia";
                rowSeq.SortMode = DataGridViewColumnSortMode.Programmatic;
                rowSeq.CellTemplate = new DataGridViewTextBoxCell();
                dataGridViewConversationNotificationWorkOrder.Columns.Insert(11, rowSeq);

                int contador = 1;
                string valorAnteriorTicket = "";
                string valorAnteriorIdConversa = "";

                foreach (DataGridViewRow row in dataGridViewConversationNotificationWorkOrder.Rows)
                {
                    string col1 = row.Cells[0].Value.ToString();
                    string col8 = row.Cells[8].Value.ToString();

                    if (col1 != valorAnteriorTicket)
                    {
                        contador = 1;
                    }
                    valorAnteriorTicket = col1;
                    row.Cells[11].Value = contador;
                    contador++;

                    if (col8 == valorAnteriorIdConversa)
                    {
                        contador--;
                    }
                    valorAnteriorIdConversa = col8;
                    row.Cells[11].Value = contador - 1;
                }
                btnSetSeq.Enabled = false;
            }
            catch { }
        }


        public async void ExportGridXls()
        {
            if (dataGridViewConversationNotificationWorkOrder.Rows.Count > 0)
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Arquivos de Planilha (*.xlsx)|*.xlsx";
                saveFile.FileName = "Actions";
                saveFile.CheckPathExists = false;
                saveFile.CheckFileExists = false;

                if (saveFile.ShowDialog() == DialogResult.OK)

                    try
                    {
                        executing = false;
                        executingExport = true;
                        Processing();

                        //instância Excel
                        var excelApp = new Microsoft.Office.Interop.Excel.Application();
                        var workbook = excelApp.Application.Workbooks.Add(Type.Missing);
                        var worksheet = workbook.Worksheets.Add(Type.Missing);
                        Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);

                        //obter qte de linhas e colunas DataGridView
                        int cols = dataGridViewConversationNotificationWorkOrder.Columns.Count;
                        int rows = dataGridViewConversationNotificationWorkOrder.Rows.Count;

                        //adiciona cabeçalhos das colunas DataGridView
                        for (int i = 1; i < cols + 1; i++)
                        {
                            worksheet.Cells[1, i] = dataGridViewConversationNotificationWorkOrder.Columns[i - 1].HeaderText;
                        }

                        excelApp.Range["C2"].EntireColumn.NumberFormat = "yyyy/MM/dd HH:mm:ss";

                        //adiciona dados das linhas DataGridView
                        for (int i = 0; i < rows; i++)
                        {
                            for (int j = 0; j < cols; j++)
                            {
                                var cellValue = worksheet.Cells[i + 2, j + 1] = dataGridViewConversationNotificationWorkOrder.Rows[i].Cells[j].Value.ToString();

                                //executa formatação das celulas
                                var plaintText = Regex.Replace(cellValue.ToString(), @"<[^>]*(div|br|body|margin|color|font(-family|-size)?|/?(p|span|b|i|u|strong|em|strike)|text-align|line-height|background-color)[^>]*>|style\s*=\s*""[^""]*""", string.Empty)
                                   // plaintText = Regex.Replace(cellValue.ToString(), "<.*?>", string.Empty)

                                    /*.Replace("Atenciosamente", " Atenciosamente ").Trim()
                                    .Replace("Bom Dia", " Bom dia. ").Trim()
                                    .Replace("Boa Tarde", " Boa tarde. ").Trim()
                                    .Replace("Boa Noite", " Boa noite. ").Trim()
                                    .Replace("Bom Dia.", " Bom dia. ").Trim()
                                    .Replace("Boa Tarde.", " Boa tarde. ").Trim()
                                    .Replace("Boa Noite.", " Boa noite. ").Trim()
                                    .Replace("Bom dia", " Bom dia. ").Trim()
                                    .Replace("Boa tarde", " Boa tarde. ").Trim()
                                    .Replace("Boa noite", " Boa noite. ").Trim()
                                    .Replace("Bom dia.", " Bom dia. ").Trim()
                                    .Replace("Boa tarde.", " Boa tarde. ").Trim()
                                    .Replace("Boa noite.", " Boa noite. ").Trim()*/
                                    .Replace("&nbsp;", string.Empty).Trim()

                                    .Replace("Category : SoftwareDescription : >@font-face { \tfont-family: Calibri; } @font-face { " +
                                    "\tfont-family: Tahoma; } @page Section1 {size: 612.0pt 792.0pt; margin: 70.85pt 3.0cm 70.85pt 3.0cm;" +
                                    " } P.MsoNormal { \tFONT-SIZE: 12pt; MARGIN: 0cm 0cm 0pt; FONT-FAMILY: \"Times New Roman\",\"serif\" }" +
                                    " LI.", string.Empty).Trim()

                                    .Replace("Category : SoftwareDescription : > <!--  /* Font Definitions */  @font-face \t{font-family:Calibri;" +
                                    " \tpanose-1:2 15 5 2 2 2 4 3 2 4;} @font-face \t{font-family:Tahoma; \tpanose-1:2 11 6 4 3 5 4 4 2 4;}  /* Style " +
                                    "Definitions */  p.MsoNormal, li.MsoNormal, div.MsoNormal \t{margin:0cm; \tmargin-bottom:.0001pt; \tfont-",
                                    string.Empty).Trim()

                                    .Replace("\r\nCategory : SoftwareDescription : ********************************************************************" +
                                    "***************\r\nCategoria : SoftwareDescrição : ", string.Empty).Trim()

                                    .Replace("<table style=\"border-collapse:\r\n collapse;width:573pt\" border=\"0\" cellpadding=\"0\" cellspacing=\"0\"" +
                                    " width=\"764\">", string.Empty).Trim()

                                    .Replace("<table border=\"0\" cellpadding=\"0\" cellspacing=\"0\" width=\"764\" style=\"border-collapse:\r\n collapse;width:573pt\">\r\n", string.Empty).Trim()

                                    .Replace("\r\n          <span style=\"font-size: 11.0pt;font-family: Calibri , sans-serif;color: rgb(31,73,1", string.Empty).Trim()

                                    .Replace("<span style=\"font-size: 11.0pt;font-family: Calibri , sans-serif;color: rgb(31,73,1", string.Empty).Trim()

                                    .Replace(" <p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"", string.Empty).Trim()

                                    .Replace("Category : SoftwareDescription : ", string.Empty).Trim()

                                    .Replace("Category : HardwareDescription : ", string.Empty).Trim()

                                    .Replace("<span style=\"font-family:&quot;Arial&quot;,sans-serif;\r\ncolor:#212121\"  >", string.Empty).Trim()

                                    .Replace("><!-- /* Font Definitions */ @font-face \t{font-family:Calibri; \tpanose-1:2 15 5 2 2 2 4 3 2 4;} " +
                                    "@font-face \t{font-family:Tahoma; \tpanose-1:2 11 6 4 3 5 4 4 2 4;} /* Style Definitions */ p.MsoNormal, li.MsoNormal," +
                                    " div.MsoNormal \t{margin:0cm; \tmargin-bottom:.0001pt;", string.Empty).Trim()

                                    .Replace("<span style=\"font-size: 11.0pt;font-family: Calibri , sans-serif;co", string.Empty).Trim()

                                    .Replace("***********************************************************************************\r\nCategoria : Softw", string.Empty).Trim()

                                    .Replace(" ***********************************************************************************\r\nCategoria : SoftwareDescrição :", string.Empty)

                                    .Replace("<span style=\"font-size: 9.0pt;font-family: Tahoma", string.Empty).Trim()

                                    .Replace(" <p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"", string.Empty).Trim()

                                    .Replace(" De:<span style=\"font-size: 11.0pt;font-family: Calibri ,", string.Empty).Trim()

                                    .Replace("<div style=\"border: none;border-top: solid rgb(225,225,225) 1.0pt;padding: 3.0pt 0.0cm 0.0cm", string.Empty).Trim()

                                    .Replace("<span style=\"font-size: 11.0pt;font-family: Calibri , san", string.Empty).Trim()

                                    .Replace("De: servicedesk  Enviada em: terça-feira, 26 de dezembro de 2017 09:17 Para: Andre Barbosa de Oliveira &lt;andre.oliveira@ppi-multitask." +
                                    "com.br&gt; Cc: servicedesk &lt;servicedesk@ppi-multitask.com.br&gt; Assunto: [Request ID :##34482#", string.Empty).Trim()

                                    .Replace("Contact : Roberto VeigaDue by time : ->v\\:* {behavior:url(#default#VML);} o\\:* {behavior:url(#default#VML);} w\\:* {behavior:url(#default#VML);} " +
                                    ".shape {behavior:url(#default#VML);} ><!-- /* Font Definitions */ @font-face \t{font-family:Calibri; \tpanose-1:2 15 5 2 2 2 4 3 2 4;} @font-face \t{font-family:Tahoma;" +
                                    " \tpanose-1:2 11 6 4 3 5 4 4 2 4;} /* Style Definitions */ p.MsoNormal, li.MsoNormal, div.MsoNorm", string.Empty).Trim()

                                    .Replace("> <!--  /* Font Definitions */  @font-face \t{font-family:Calibri; \tpanose-1:2 15 5 2 2 2 4 3 2 4;} @font-face \t{font-family:Tahoma; \tpanose-1:2 11 6 4 3 5 4 4 2 4;}" +
                                    "  /* Style Definitions */  p.MsoNormal, li.MsoNormal, div.MsoNormal \t{margin:0cm; \tmargin-bottom:.0001pt; \tfont-size:12.0pt", string.Empty).Trim()

                                    .Replace("size:12.0pt; \tfont-family:\"Times New Roman\",\"serif\";} a:link, s", string.Empty).Trim()

                                    .Replace("MsoNormal { \tFONT-SIZE: 12pt; MARGIN: 0c", string.Empty).Trim()

                                    .Replace("size:12.0pt; \tfont-family:\"Times New Rom", string.Empty).Trim()

                                    .Replace("><!-- /* Font Definitions */ @font-face \t{font-family:Calibri; \tpanose-1:2 15 5 2 2 2 4 3 2 4;} @font-face \t{font-family:Tahoma; \tpanose-1:2 11 6 4 3 5 4 4 2 4;} /* " +
                                    "Style Definitions */ p.MsoNormal, li.MsoNorm", string.Empty).Trim()

                                    .Replace(".." + @"\" + "fileAttachments", "Y:" + @"\" + "fileAttachments")

                                    .Replace("<p class=\"MsoN", string.Empty).Trim()

                                    .Replace("De: ServiceDesk PPI-Multitask [mailto:servicedesk@ppi-multitask.com.br]  Enviada em: ", string.Empty).Trim()

                                    .Replace("&quot;", string.Empty).Trim()

                                    .Replace("<span st", string.Empty).Trim()

                                    .Replace("</sp", string.Empty).Trim()

                                    .Replace("De: ServiceDesk PPI-Multitask &lt;servicedesk-ppi@", string.Empty).Trim()

                                    .Replace("<img src=\"/inlineimages/Conver", string.Empty).Trim()

                                    .Replace("<img src=", string.Empty).Trim()

                                    .Replace("<tr st", string.Empty).Trim()

                                    .Replace("<td w", string.Empty).Trim()

                                    .Replace("</sp", string.Empty).Trim()

                                    .Replace("<img src=\"http://servicedesk.pp", string.Empty).Trim()

                                    .Replace("<table border=\"0\" cellspacing=\"0\" cellpaddin", string.Empty).Trim()

                                    .Replace("ATENÇÃO:  Esta mensagem é de REMETENTE EXTERNO - Tenha cuidado ao abrir links e anexos.   *** NOVO *** NÃO digite sua SENHA WEG quando solicitada por E-MAIL EXTERNO        ", string.Empty).Trim()

                                    .Replace(" \r\n \r\n  Normal\r\n  0\r\n  \r\n  \r\n  21\r\n  \r\n  \r\n  false\r\n  false\r\n  false\r\n  \r\n  PT-BR\r\n  X-NONE\r\n  X-NONE\r\n  \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n  \r\n  MicrosoftInternetExplorer4\r\n  \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n  \r\nyle=\"font-size:11.0pt;font-family:Calibri,sans-serif;\r\nmso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:\r\nPT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA\"  >", string.Empty).Trim()

                                    .Replace("\r\n  21\r\n  \r\n  \r\n  false\r\n  false\r\n  false\r\n  \r\n  PT-BR\r\n  X-NONE\r\n  X-NONE\r\n  \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n  \r\n  MicrosoftInternetExplorer4\r\n  \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n   \r\n  \r\nyle=\"font-size:11.0pt;font-family:Calibri,sans-serif;\r\nmso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:\r\nPT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA\"  >https://multitask-my.sharepoint.com/personal/andressaks_ppi-multitask_com_br/_layouts/15/onedrive.aspx?id=%2Fpersonal%2Fandressaks%5Fppi%2Dmultitask%5Fcom%5Fbr%2FDocuments%2FSuporte%2F2023%2F4%2E2%2E2304%2E1017&amp;ga=1yle=\"font-size:11.0pt;font-family:Calibri,sans-serif;\r\nmso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:\r\nPT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA\"  >", string.Empty).Trim()

                                    .Replace("21 false false false PT-BR X-NONE X-NONE MicrosoftInternetExplorer4 yle= font-size:11.0pt;font-family:Calibri,sans-serif;mso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:PT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA>https://multitask-my.sharepoint.com/personal/andressaks_ppi-multitask_com_br/_layouts/15/onedrive.aspx?id=%2Fpersonal%2Fandressaks%5Fppi%2Dmultitask%5Fcom%5Fbr%2FDocuments%2FSuporte%2F2023%2F4%2E2%2E2304%2E1017&amp;ga=1yle=font-size:11.0pt;font-family:Calibri,sans-serif;mso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:PT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA>", string.Empty).Trim()

                                    .Replace("<p style=\"margin-top: 0.0px;margin-bottom: 0.0px;padding: 5.0px 0.0px;font-family: Verdana , Arial , Helvetica , sans-serif;fo", string.Empty).Trim()

                                    .Replace("yle=\"font-size:11.0pt;font-family:Calibri,sans-serif;\r\nmso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:\r\nPT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA\"  >", string.Empty).Trim()

                                    .Replace("yle=font-size:11.0pt;font-family:Calibri,sans-serif;mso-fareast-font-family:Calibri;mso-fareast-theme-font:minor-latin;mso-ansi-language:PT-BR;mso-fareast-language:EN-US;mso-bidi-language:AR-SA  >", string.Empty).Trim()

                                    .Replace("Contact : Regina LopesDue by time : Wed, Dec 14 07:56:46 AST 2022", string.Empty).Trim()

                                    .Replace("***********************************************************************************Solicitante : Regina LopesData : Wed, Dec 14 07:56:46 AST 2022Categoria : SoftwareDescrição : ", string.Empty).Trim()

                                    .Replace("***********************************************************************************Solicitante : ", string.Empty).Trim()

                                    .Replace("src=", "<img>").Trim()
                                    .Replace("src=" + "data", "<img>").Trim()
                                    .Replace("<DIV>", string.Empty).Trim()
                                    .Replace("</DIV>", string.Empty).Trim()
                                    .Replace("<DIV></DIV>", string.Empty).Trim()

                                    .Replace(".  . ,", ",").Trim()

                                    .Replace("ATENÇÃO: Esta mensagem é de REMETENTE EXTERNO -Tenha cuidado ao abrir links e anexos.   ***NOVO * **NÃO digite sua SENHA WEG quando solicitada por E-MAIL EXTERNO", string.Empty).Trim()
                                    .Replace("ATENÇÃO:  Esta mensagem é de REMETENTE EXTERNO - Tenha cuidado ao abrir links e anexos.   *** NOVO *** NÃO digite sua SENHA WEG quando solicitada por E-MAIL EXTERNO       ", string.Empty).Trim()

                                    .Replace("<br /><br /><br /><br />========================= Forwarded Mail =========================<br /><br />    Message ID :  &lt;012b01d4504c$7d280ba0$777822e0$@maxbelt.com.br&gt;<br />     Sent Date :  Wed, 19 Sep 2018 16:10:54 -0300<br />      " +
                                    "X-Mailer :  Microsoft Outlook 15.0<br />          From :  informatica@maxbelt.com.br<br /> Sender MailID :  informatica@maxbelt.com.br<br />      Reply To :  informatica@maxbelt.com.br<br />            To :  melhoriacontinua@maxbelt.com.br<br />       " +
                                    "Subject :  RES: [Request ID :##36760##] : Integração - importação de ordem de produção / Re: [Identificação do Chamado :##36760##] : Integração - importação de ordem de produção<br /><br />------------------------- Contents -------------------------<br " +
                                    "/><br /><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Boa Tarde...</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: " +
                                    "0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Amanhã as 12:30 pode ser? Ou hoje as 18:00</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;" +
                                    "margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Att..</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"" +
                                    "font-size: 9.0pt;font-family: &quot;Arial Rounded MT Bold&quot;;color: rgb(31,78,121);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\"" +
                                    " width=\"51%\" style=\"width: 51.44%;\"><tbody><tr style=\"height: 13.4pt;\"><td width=\"0\" style=\"width: 0.3pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><p align=\"center\" style=\"text-align: " +
                                    "center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"> </span></p><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: rgb(0,112,192);\"><hr " +
                                    "style=\"color: black;\" /></span></div><p align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"> </span></p></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid " +
                                    "rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div>" +
                                    "</td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: " +
                                    "115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align:" +
                                    " center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"97\" colspan=\"2\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: " +
                                    "0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"96\" style=\"width:" +
                                    " 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\"" +
                                    " /></span></div></td><td width=\"96\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"fon", string.Empty).Trim()

                                    .Replace(" <col style=\"mso-width-source:userset;mso-width-alt:4278;\r\n width:88pt\" width=\"117\" span=\"2\">\r\n \r\n  Recursos\r\n   Ops em rateio\r\n \r\n \r\n  681.2\r\n  7\r\n \r\n \r\n  3300.1\r\n  7\r\n \r\n \r\n  3300.2\r\n  6\r\n \r\n \r\n  651.2\r\n  4\r\n \r\n \r\n  8000.2\r\n  4\r\n " +
                                    "\r\n \r\n  500\r\n  3\r\n \r\n \r\n  530\r\n  3\r\n \r\n \r\n  560\r\n  3\r\n \r\n \r\n  S120\r\n  3\r\n \r\n \r\n  8000.3\r\n  2\r\n \r\n \r\n  332.2\r\n  2\r\n \r\n", string.Empty).Trim()

                                    .Replace("<br /><br /><br /><br />========================= Forwarded Mail =========================<br /><br />    Message ID :  &lt;012b01d4504c$7d280ba0$777822e0$@maxbelt.com.br&gt;<br />     Sent Date :  Wed, 19 Sep 2018 16:10:54 -0300<br />      X-Mailer :  Microsoft Outlook 15.0<br />    " +
                                    "      From :  informatica@maxbelt.com.br<br /> Sender MailID :  informatica@maxbelt.com.br<br />      Reply To :  informatica@maxbelt.com.br<br />            To :  melhoriacontinua@maxbelt.com.br<br />       Subject :  RES: [Request ID :##36760##] : Integração - importação de ordem de produção / " +
                                    "Re: [Identificação do Chamado :##36760##] : Integração - importação de ordem de produção<br /><br />------------------------- Contents -------------------------<br /><br /><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Boa Tarde...</span></p><p style=\"" +
                                    "margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Amanhã as 12:30 pode ser? Ou hoje as 18:00</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"" +
                                    "color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Att..</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"" +
                                    "><span style=\"font-size: 9.0pt;font-family: &quot;Arial Rounded MT Bold&quot;;color: rgb(31,78,121);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"51%\" style=\"width: 51.44%;\" " +
                                    ">< tbody >< tr style =\"height: 13.4pt;\"><td width=\"0\" style=\"width: 0.3pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><p align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"" +
                                    "> </ span ></ p >< div align =\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: rgb(0,112,192);\"><hr style=\"color: black;\" /></span></div><p align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: " +
                                    "115.0%;color: black;\"> </span></p></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"" +
                                    "><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: " +
                                    "115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: " +
                                    "1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"97\" colspan=\"2\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"" +
                                    ">< span style =\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"96\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: " +
                                    "115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"96\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"fon", string.Empty).Trim()

                                .Replace("\"font-size:10.0pt;font-family:Verdana,sans-serif;\r\nmso-fareast-font-family:Times New Roman;color:black\"  >\r\nyle=\"font-size:12.0pt;font-family:Verdana,sans-serif;\r\nmso-fareast-font-family:Times New Roman;color:blue\"  >PPI-Multitask Sistemas e\r\nAutomacao Ltda. yle=\"font-size:10.0pt;font-family:Verdana,sans-serif;" +
                                   "\r\nmso-fareast-font-family:Times New Roman;color:black\"  >\r\n\r\nyle=\"font-size:10.0pt;font-family:Verdana,sans-serif;mso-fareast-font-family:\r\nTimes New Roman;color:black\"  >\r\n\r\n\r\n\r\n\r\n\r\nyle=\"font-size:10.0pt;font-family:Verdana,sans-serif;mso-fareast-font-family:\r\nTimes New Roman;color:black\"  >\r\n\r\n\r\n\r\nyle=\"font-size:10.0pt;\r\nfont-family:Verdana,sans-serif;" +
                                   "mso-fareast-font-family:Times New Roman;\r\ncolor:black\"  >", string.Empty).Trim()

                                   .Replace("yle=\"font-size:10.0pt;font-family:Verdana,sans-serif;mso-fareast-font-family:\r\nTimes New Roman;color:black\"  >\r\n", string.Empty).Trim()
                                   .Replace("yle=\"font-size:10.0pt;font-family:Verdana,sans-serif;mso-fareast-font-family:\r\nTimes New Roman;color:black\"  >\r\n", string.Empty).Trim()
                                   .Replace("yle=\"font-size:10.0pt;\r\nfont-family:Verdana,sans-serif;mso-fareast-font-family:Times New Roman;\r\ncolor:black\"  >Detalhesyle=\"font-size:10.0pt;font-family:Verdana,sans-serif;\r\nmso-fareast-font-family:Times New Roman;color:black\"  >\r\n", string.Empty).Trim()
                                   .Replace("yle=\"mso-fareast-font-family:\r\nTimes New Roman\"  >", string.Empty).Trim()
                                   .Replace("  ,normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()
                                   .Replace("normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">  ", string.Empty).Trim()

                                   .Replace("<br /><br /><br /><br />========================= Forwarded Mail =========================<br /><br />    Message ID :  &lt;012b01d4504c$7d280ba0$777822e0$@maxbelt.com.br&gt;<br />     Sent Date :  Wed, 19 Sep 2018 16:10:54 -0300<br />      X-Mailer :  Microsoft Outlook 15.0<br />          From :  informatica@maxbelt.com.br<br /> Sender MailID :  informatica@maxbelt.com.br<br />      Reply To :  informatica@maxbelt.com.br<br />" +
                                   "            To :  melhoriacontinua@maxbelt.com.br<br />       Subject :  RES: [Request ID :##36760##] : Integração - importação de ordem de produção / Re: [Identificação do Chamado :##36760##] : Integração - importação de ordem de produção<br /><br />------------------------- Contents -------------------------<br /><br /><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Boa Tarde...</span></p><p style=" +
                                   "\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">", string.Empty).Trim()

                                   .Replace("</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Att..</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"font-size: 9.0pt;font-family: &quot;Arial " +
                                   "Rounded MT Bold&quot;;color: rgb(31,78,121);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><table border=\"0\" cellspacing=\"0\" cellpadding=\"0\" width=\"51%\" style=\"width: 51.44%;\"><tbody><tr style=\"height: 13.4pt;\"><td width=\"0\" style=\"width: 0.3pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><p align=\"center\"" +
                                   "style =\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"> </span></p><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: rgb(0,112,192);\"><hr style=\"color: black;\" /></span></div><p align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"" +
                                   "> </ span ></ p ></ td >< td width =\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding:" +
                                   " 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"102\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"" +
                                   "><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"97\" colspan=\"2\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);" +
                                   "\" /></span></div></td><td width=\"96\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"font-size: 1.0pt;line-height: 115.0%;color: black;\"><hr style=\"color: rgb(46,116,181);\" /></span></div></td><td width=\"96\" style=\"width: 72.0pt;border: none;border-top: solid rgb(157,146,130) 1.0pt;" +
                                   "padding: 0.0cm 0.0cm 0.0cm 0.0cm;height: 13.4pt;\"><div align=\"center\" style=\"text-align: center;line-height: 115.0%;\"><span style=\"fon", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">  Bom dia.  ,ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">\r\n\r\normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">\r\n", string.Empty).Trim()

                                  .Replace("ormal\" style=\"mso-margin-top-alt:auto;margin-bottom:0cm;margin-bottom:\r\n.0001pt;line-height:normal;background:white\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"mso-margin-top-alt:auto;margin-bottom:0cm;margin-bottom:\r\n.0001pt;line-height:normal;background:white\">ormal\" style=\"mso-margin-top-alt:auto;margin-bottom:0cm;margin-bottom:\r\n.0001pt;line-height:normal;background:white\">ormal\" style=\"mso-margin-top-alt:auto;margin-bottom:0cm;margin-bottom:\r\n.0001pt;line-height:normal;background:white\">\r\n\r\n\r\n\r\n\r\normal\" style=\"mso-margin-top-alt:auto;mso-margin-bottom-alt:auto;", string.Empty).Trim()

                                  .Replace("<br /><br /><br /><br />========================= Forwarded Mail =========================<br /><br />    Message ID :  &lt;012b01d4504c$7d280ba0$777822e0$@maxbelt.com.br&gt;<br />     Sent Date :  Wed, 19 Sep 2018 16:10:54 -0300<br />      X-Mailer :  Microsoft Outlook 15.0<br />          From :  informatica@maxbelt.com.br<br /> Sender MailID :  informatica@maxbelt.com.br<br />      Reply To :  informatica@maxbelt.com.br<br />            To :  melhoriacontinua@maxbelt.com.br<br />       Subject :  RES: [Request ID :##36760##] : Integração - importação de ordem de produção / Re: [Identificação do Chamado :##36760##] : Integração - importação de ordem de produção<br /><br />------------------------- Contents -------------------------<br /><br /><div><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">Boa Tarde...</span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\"> </span></p><p style=\"margin-top: 0.0px;margin-bottom: 0.0px;\"><span style=\"color: rgb(31,73,125);\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">  Bom dia.  ,ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">\r\n\r\normal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">  Bom dia.  ,ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">ormal\" style=\"margin-bottom:0cm;margin-bottom:.0001pt;line-height:\r\nnormal\">", string.Empty).Trim()

                                  .Replace("ormal\" style=\"mso-margin-top-alt:auto;margin-bottom:0cm;margin-bottom:\r\n.0001pt;line-height:normal;background:white\">\r\n", string.Empty).Trim()

                                  .Replace("\"<br/><br/><br/><br/>=========================ForwardedMail=========================<br/><br/>MessageID:&lt;012b01d4504c$7d280ba0$777822e0$@maxbelt.com.br&gt;<br/>SentDate:Wed,19Sep201816:10:54-0300<br/>X-Mailer:MicrosoftOutlook15.0<br/>From:informatica@maxbelt.com.br<br/>SenderMailID:informatica@maxbelt.com.br<br/>ReplyTo:informatica@maxbelt.com.br<br/>To:melhoriacontinua@maxbelt.com.br<br/>Subject:RES:[RequestID:##36760##]:Integração-importaçãodeordemdeprodução/Re:[IdentificaçãodoChamado:##36760##]:Integração-importaçãodeordemdeprodução<br/><br/>-------------------------Contents-------------------------<br/><br/><div><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\">BoaTarde...</span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\"> </span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\">Amanhãas12:30podeser?Ouhojeas18:00</span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\"> </span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\">Att..</span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\"> </span></p><div><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"font-size:9.0pt;font-family:&quot;ArialRoundedMTBold&quot;;color:rgb(31,78,121);\\\"> </span></p><pstyle=\\\"margin-top:0.0px;margin-bottom:0.0px;\\\"><spanstyle=\\\"color:rgb(31,73,125);\\\"> </span></p><tableborder=\\\"0\\\"cellspacing=\\\"0\\\"cellpadding=\\\"0\\\"width=\\\"51%\\\"style=\\\"width:51.44%;\\\"><tbody><trstyle=\\\"height:13.4pt;\\\"><tdwidth=\\\"0\\\"style=\\\"width:0.3pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><palign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"> </span></p><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:rgb(0,112,192);\\\"><hrstyle=\\\"color:black;\\\"/></span></div><palign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"> </span></p></td><tdwidth=\\\"102\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"><hrstyle=\\\"color:rgb(46,116,181);\\\"/></span></div></td><tdwidth=\\\"102\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"><hrstyle=\\\"color:rgb(46,116,181);\\\"/></span></div></td><tdwidth=\\\"102\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"><hrstyle=\\\"color:rgb(46,116,181);\\\"/></span></div></td><tdwidth=\\\"97\\\"colspan=\\\"2\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"><hrstyle=\\\"color:rgb(46,116,181);\\\"/></span></div></td><tdwidth=\\\"96\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"font-size:1.0pt;line-height:115.0%;color:black;\\\"><hrstyle=\\\"color:rgb(46,116,181);\\\"/></span></div></td><tdwidth=\\\"96\\\"style=\\\"width:72.0pt;border:none;border-top:solidrgb(157,146,130)1.0pt;padding:0.0cm0.0cm0.0cm0.0cm;height:13.4pt;\\\"><divalign=\\\"center\\\"style=\\\"text-align:center;line-height:115.0%;\\\"><spanstyle=\\\"fon\"", string.Empty).Trim()

                                  .Replace("yle=", string.Empty).Trim()

                                  .Replace("- A&amp;L", string.Empty).Trim()

                                  .Replace("\r\n\r\n\r\n\r\n\r\n\r\n    ", string.Empty).Trim()
                                  .Replace(" \r\n\r\n\r\n\r\n", string.Empty).Trim()
                                  .Replace("\r\n\r\n\r\n\r\n", string.Empty).Trim()
                                  .Replace("\r\n\r\n\r\n", string.Empty).Trim()
                                  .Replace("\r\n\r\n", string.Empty).Trim()
                                  .Replace("\r\n\r\n", string.Empty).Trim()
                                  .Replace(" \r\n\r\n\r\n\r\n\r\n\r\n", string.Empty).Trim()
                                  .Replace("\r\n\r\n\r\n\r\nAndré F. dos Santos\r\n\r\n", string.Empty).Trim();

                                worksheet.Cells[i + 2, j + 1] = plaintText;
                            }
                             // Range C = xlWorkSheet.get_Range("C1", "C" + (dataGridViewConversationNotificationWorkOrder.Rows.Count + 1));
                             // C.NumberFormat = "yyyy/mm/dd hh:mm:ss";

                            if (chxAutoColsRows.Checked == true)
                            {
                                Range rangeAll = worksheet.UsedRange;
                                rangeAll.EntireColumn.AutoFit();
                                rangeAll.RowHeight = 15;
                                rangeAll.WrapText = true;
                                //worksheet.Rows[i + 1].RowHeight = 15;
                            }
                            excelApp.Columns.AutoFit();
                            excelApp.Visible = true;
                        }
                        workbook.SaveAs(saveFile.FileName, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing,
                            Type.Missing, Type.Missing, Type.Missing);

                        //workbook.Close();
                        // excelApp.Quit();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro : " + ex.Message);
                    }
                executingExport = false;
                Processing();
            }
        }

        private void chxFilterAttachs_CheckedChanged(object sender, EventArgs e)
        {
            if (chxFilterAttachs.Checked == true)
            {
                foreach (DataGridViewRow row in dataGridViewConversationNotificationWorkOrder.Rows)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGridViewConversationNotificationWorkOrder.DataSource];
                    cm.EndCurrentEdit();
                    cm.ResumeBinding();
                    cm.SuspendBinding();

                    if (string.IsNullOrEmpty(row.Cells["ID Anexo"].Value?.ToString()) &&
                        string.IsNullOrEmpty(row.Cells["Diretório"].Value?.ToString()))
                    {
                        row.Visible = false;
                    }
                }

                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Ticket");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Data/Hora");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Status");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Ação Publica/Interna");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Gerador");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Usuário");
                //dataGridViewConversationNotificationWorkOrder.Columns.Remove("ID Conversa");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Texto Conversa");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("Data Sequencia");
                dataGridViewConversationNotificationWorkOrder.Columns.Remove("ID Anexo");

                chxFilterAttachs.Enabled = false;

            }
        }


        private async void Processing()
        {
            try
            {
                if (executing == true)
                {
                    progressBar.Visible = true;
                }
                else if (executingExport == true && executing == false)
                {
                    progressBar.Visible = true;
                    lbExporting.Visible = true;
                }
                else
                {
                    progressBar.Visible = false;
                    lbExporting.Visible = false;
                }
            }
            catch
            {
            }
        }

        private void dataGridViewConversationNotificationWorkOrder_CellValueNeeded(object sender, DataGridViewCellValueEventArgs e)
        {
            if (dataGridViewConversationNotificationWorkOrder.Columns[e.ColumnIndex].Name == "Texto Conversa" && e.Value == null)
            {
                e.Value = "<img>";
            }
        }

        private void dataGridViewConversationNotificationWorkOrder_DefaultCellStyleChanged(object sender, EventArgs e)
        {
            dataGridViewConversationNotificationWorkOrder.Columns["Data/Hora"].DefaultCellStyle.Format = "yyyy/MM/dd HH:mm:ss";
        }
    }
}