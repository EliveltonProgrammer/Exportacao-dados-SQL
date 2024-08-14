using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Globalization;
using System.Windows.Forms;
using System.Diagnostics.Contracts;
using Microsoft.Office.Interop.Excel;
using Microsoft.SqlServer.Server;

namespace Migration
{
    public partial class frmReadWorkOrder : Form
    {
        Migration_WorkOrder mgWO = new Migration_WorkOrder();
        bool executingExport = false;

        public static string WONumTicketStart = String.Empty;
        public static string WONumTicketEnd = String.Empty;
        public static string WOStatusTicket = string.Empty;

        public frmReadWorkOrder()
        {
            InitializeComponent();
        }

        private void frmReadWorkOrderTickets_Load(object sender, EventArgs e)
        {
            lbLoadingGrid.Visible = false;
            progressBarLoadingGrid.Visible = false;
            btnExportXls.Enabled = false;
            btnProcessActions.Enabled = false;
            progressBar.Visible = false;
            lbExporting.Visible = false;
            lbContRows.Text = "0";
            lbContColums.Text = "0";
            //dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrder(Convert.ToInt32(tbxFilterNumTicketStart.Text = null), Convert.ToInt32(tbxFilterNumTicketEnd.Text=null));
        }

        private void btnFilterNumTicket_Click(object sender, EventArgs e)
        {
            FilterNumInterval();
        }

        private void btnFilterDateTicket_Click(object sender, EventArgs e)
        {
            FilterDateInterval();
        }

        private void tbxFilterStatusTicket_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltersIntervalsAndStatus();
        }

        private void btnEraseGrid_Click(object sender, EventArgs e)
        {
            EraseGrid();
        }

        private void btnExportXls_Click(object sender, EventArgs e)
        {
            ExportGridXls();
        }

        private void btnProcessActions_Click(object sender, EventArgs e)
        {
            ReadActions();
        }

        public async void ProgressActionsAuto()
        {
            try
            {
                if (dataGridViewWorkOrders.Rows.Count == 0)
                {
                    progressBarLoadingGrid.Visible = true;
                    lbLoadingGrid.Visible = true;
                }
                else if (dataGridViewWorkOrders.Rows.Count > 0)
                {
                    progressBarLoadingGrid.Visible = false;
                    lbLoadingGrid.Visible = false;
                }            
                progressBarLoadingGrid.Visible = false;
                lbLoadingGrid.Visible = false;
            }
            catch (Exception ex)
            {

            }
        }

        public async void FilterNumInterval()
        {
            try
            {
                if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                {
                    if (MessageBox.Show("Intervalo da Númeração dos Tickets não definido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;

                    btnExportXls.Enabled = false;
                    btnProcessActions.Enabled = false;
                }

                else if (tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty)
                {
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderNum(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text));

                    ProgressActionsAuto();
                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;

                    //Total linhas
                    for (int i = 1; i < dataGridViewWorkOrders.Rows.Count + 1; i++)
                    {
                        lbContRows.Text = i.ToString();
                    }
                    //Total colunas
                    for (int i = 1; i < dataGridViewWorkOrders.Columns.Count + 1; i++)
                    {
                        lbContColums.Text = i.ToString();
                    }
                }
                ProgressActionsAuto();
            }
            catch (Exception ex) { }
        }



        public async void FilterDateInterval()
        {
            try
            {
                if (tbxFilterDtStartTicket.Text == string.Empty || tbxFilterDtEndTicket.Text == string.Empty)
                {
                    if (MessageBox.Show("Intervalo de Período de Abertura não definido!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;

                    btnExportXls.Enabled = false;
                    btnProcessActions.Enabled = false;
                }

                else if (tbxFilterDtStartTicket.Text != string.Empty || tbxFilterDtEndTicket.Text != string.Empty)
                {
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderDate(Convert.ToDateTime(tbxFilterDtStartTicket.Text), Convert.ToDateTime(tbxFilterDtEndTicket.Text));

                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;

                    //Total linhas
                    for (int i = 1; i < dataGridViewWorkOrders.Rows.Count + 1; i++)
                    {
                        lbContRows.Text = i.ToString();
                    }
                    //Total colunas
                    for (int i = 1; i < dataGridViewWorkOrders.Columns.Count + 1; i++)
                    {
                        lbContColums.Text = i.ToString();
                    }
                }
                ProgressActionsAuto();
            }
            catch (Exception ex) { }
        }

        public async void FiltersIntervalsAndStatus()
        {
            try
            {
                if (//tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty ||
               tbxFilterDtStartTicket.Text == string.Empty || tbxFilterDtEndTicket.Text == string.Empty ||
               cbxFilterStatusTicket.SelectedText == null)
                {
                    if (MessageBox.Show("Filtros de Intervalo ou Status não definidos!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information) == DialogResult.Yes) ;

                    btnExportXls.Enabled = false;
                    btnProcessActions.Enabled = false;
                }

                else if (//tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty &&
                    tbxFilterDtStartTicket.Text != string.Empty && tbxFilterDtEndTicket.Text != string.Empty &&
                    cbxFilterStatusTicket.SelectedIndex == 0)
                {
                    if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                    {
                        tbxFilterNumTicketStart.Text = "0";
                        tbxFilterNumTicketEnd.Text = "60000";
                    }
                    if (tbxFilterDtStartTicket.Text == "__/__/____ __:__" || tbxFilterDtEndTicket.Text == "__/__/____ __:__")
                    {
                        tbxFilterDtStartTicket.Text = "01/01/2023 00:00";
                        tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
                    }
                    //Todos Status
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderNumDateStatus(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text),
                        Convert.ToDateTime(tbxFilterDtStartTicket.Text), Convert.ToDateTime(tbxFilterDtEndTicket.Text), "'1','2','3','6','7','8','9'," +
                        "'301','304','601','901','1201','1501','1801','1802','2101','2102','2103','2402','2403','2405','2406','2407','2701','2702','2703'," +
                        "'2704','3001','3301','3302','3303','3304','3601','3901'");

                    ProgressActionsAuto();
                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;
                }

                else if (//tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty &&
                    tbxFilterDtStartTicket.Text != string.Empty && tbxFilterDtEndTicket.Text != string.Empty &&
                   cbxFilterStatusTicket.SelectedIndex == 1)
                {
                    if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                    {
                        tbxFilterNumTicketStart.Text = "0";
                        tbxFilterNumTicketEnd.Text = "60000";
                    }
                    if (tbxFilterDtStartTicket.Text == "__/__/____ __:__" || tbxFilterDtEndTicket.Text == "__/__/____ __:__")
                    {
                        tbxFilterDtStartTicket.Text = "01/01/2023 00:00";
                        tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
                    }
                    //Todos em Abertos (Diferente de = 3-Fechado)
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderNumDateStatus(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text),
                         Convert.ToDateTime(tbxFilterDtStartTicket.Text), Convert.ToDateTime(tbxFilterDtEndTicket.Text), "'1','2','6','7','8','9','301'," +
                        "'304','601','901','1501','2101','2102','2402','2405','2406','2407','2702','2703','3001','3302','3303','3601','3901'");

                    ProgressActionsAuto();
                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;
                }

                else if (//tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty &&
                    tbxFilterDtStartTicket.Text != string.Empty && tbxFilterDtEndTicket.Text != string.Empty &&
                cbxFilterStatusTicket.SelectedIndex == 2)
                {
                    if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                    {
                        tbxFilterNumTicketStart.Text = "0";
                        tbxFilterNumTicketEnd.Text = "60000";
                    }
                    if (tbxFilterDtStartTicket.Text == "__/__/____ __:__" || tbxFilterDtEndTicket.Text == "__/__/____ __:__")
                    {
                        tbxFilterDtStartTicket.Text = "01/01/2023 00:00";
                        tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
                    }
                    //Status 1-Open
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderNumDateStatus(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text),
                         Convert.ToDateTime(tbxFilterDtStartTicket.Text), Convert.ToDateTime(tbxFilterDtEndTicket.Text), "'1','2101','2702','3302'");

                    ProgressActionsAuto();
                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;
                }

                else if (//tbxFilterNumTicketStart.Text != string.Empty && tbxFilterNumTicketEnd.Text != string.Empty &&
                     tbxFilterDtStartTicket.Text != string.Empty && tbxFilterDtEndTicket.Text != string.Empty &&
                cbxFilterStatusTicket.SelectedIndex == 4)
                {
                    if (tbxFilterNumTicketStart.Text == string.Empty || tbxFilterNumTicketEnd.Text == string.Empty)
                    {
                        tbxFilterNumTicketStart.Text = "0";
                        tbxFilterNumTicketEnd.Text = "60000";
                    }
                    if (tbxFilterDtStartTicket.Text == "__/__/____ __:__" || tbxFilterDtEndTicket.Text == "__/__/____ __:__")
                    {
                        tbxFilterDtStartTicket.Text = "01/01/2023 00:00";
                        tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
                    }
                    //Status 3-Fechado
                    dataGridViewWorkOrders.DataSource = mgWO.SelectWorkOrderNumDateStatus(Convert.ToInt32(tbxFilterNumTicketStart.Text), Convert.ToInt32(tbxFilterNumTicketEnd.Text),
                         Convert.ToDateTime(tbxFilterDtStartTicket.Text), Convert.ToDateTime(tbxFilterDtEndTicket.Text), "'3','2103','2704','3304'");

                    ProgressActionsAuto();
                    btnExportXls.Enabled = true;
                    btnProcessActions.Enabled = true;
                }
                //Total linhas
                for (int i = 1; i < dataGridViewWorkOrders.Rows.Count + 1; i++)
                {
                    lbContRows.Text = i.ToString();
                }
                //Total colunas
                for (int i = 1; i < dataGridViewWorkOrders.Columns.Count + 1; i++)
                {
                    lbContColums.Text = i.ToString();
                }
                ProgressActionsAuto();
            }
            catch (Exception ex) { }
        }

        private void EraseGrid()
        {
            if (dataGridViewWorkOrders.Rows.Count > 0)
            {
                btnExportXls.Enabled = false;
                btnProcessActions.Enabled = false;

                dataGridViewWorkOrders.Columns.Clear();
                dataGridViewWorkOrders.Refresh();
            }
        }

        public async void ExportGridXls()
        {
            if (dataGridViewWorkOrders.Rows.Count > 0)
            {
                try
                {
                    executingExport = true;

                    //instância Excel
                    var excelApp = new Microsoft.Office.Interop.Excel.Application();
                    var workbook = excelApp.Application.Workbooks.Add(Type.Missing);
                    var worksheet = workbook.Worksheets.Add(Type.Missing);
                    Worksheet xlWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Worksheets.get_Item(1);

                    //obter qte de linhas e colunas DataGridView
                    int cols = dataGridViewWorkOrders.Columns.Count;
                    int rows = dataGridViewWorkOrders.Rows.Count;

                    //adiciona os cabeçalhos das colunas DataGridView
                    for (int i = 1; i < cols + 1; i++)
                    {
                        worksheet.Cells[1, i] = dataGridViewWorkOrders.Columns[i - 1].HeaderText;
                    }

                    //adiciona os dados das linhas DataGridView
                    for (int i = 0; i < rows; i++)
                    {
                        for (int j = 0; j < cols; j++)
                        {
                            var cellValue = worksheet.Cells[i + 2, j + 1] = dataGridViewWorkOrders.Rows[i].Cells[j].Value.ToString();

                            //remove Formatação HTML
                            var plaintText = Regex.Replace(cellValue.ToString(), @"<[^>]*(div|br|body|margin|color|font(-family|-size)?|/?(p|span|b|i|u|strong|em|strike)|text-align|line-height|background-color)[^>]*>|style\s*=\s*""[^""]*""", string.Empty);

                            worksheet.Rows[i + 1].RowHeight = 15;
                            worksheet.Cells[i + 2, j + 1] = plaintText;
                        }
                        Range N = xlWorkSheet.get_Range("N1", "N" + (dataGridViewWorkOrders.Rows.Count + 1));
                        N.NumberFormat = "mm/dd/yyyy hh:mm:ss";

                        Range O = xlWorkSheet.get_Range("O1", "O" + (dataGridViewWorkOrders.Rows.Count + 1));
                        O.NumberFormat = "mm/dd/yyyy hh:mm:ss";

                        Range P = xlWorkSheet.get_Range("P1", "P" + (dataGridViewWorkOrders.Rows.Count + 1));
                        P.NumberFormat = "mm/dd/yyyy hh:mm:ss";

                        excelApp.Columns.AutoFit();
                        excelApp.Visible = true;
                    }
                    workbook.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro : " + ex.Message);
                }
                executingExport = false;
            }
        }

        public async void ReadActions()
        {
            try
            {
                WONumTicketStart = dataGridViewWorkOrders.Rows[0].Cells[0].Value.ToString();
                WONumTicketEnd = dataGridViewWorkOrders.Rows[dataGridViewWorkOrders.Rows.Count - 1].Cells[dataGridViewWorkOrders.Columns.Count - 22].Value.ToString();

                frmReadConversationNotificationWorkOrder frm = new frmReadConversationNotificationWorkOrder();
                frm.Show();

                frm.tbxFilterNumTicketStart.Text = WONumTicketStart;
                frm.tbxFilterNumTicketEnd.Text = WONumTicketEnd;

                WOStatusTicket = Convert.ToString(cbxFilterStatusTicket.SelectedIndex);

                if (cbxFilterStatusTicket.SelectedIndex == 0)
                {
                    WOStatusTicket = "'1','2','3','6','7','8','9','301','304','601','901','1201','1501','1801','1802','2101','2102','2103','2402','2403','2405','2406','2407','2701'," +
                        "'2702','2703','2704','3001','3301','3302','3303','3304','3601','3901'";
                }
                if (cbxFilterStatusTicket.SelectedIndex == 1)
                {
                    WOStatusTicket = "'1','2','6','7','8','9','301','304','601','901','1501','2101','2102','2402','2405','2406','2407','2702','2703','3001','3302','3303','3601','3901'";
                }
                if (cbxFilterStatusTicket.SelectedIndex == 2)
                {
                    WOStatusTicket = "'1','2101','2702','3302'";
                }
                if (cbxFilterStatusTicket.SelectedIndex == 4)
                {
                    WOStatusTicket = "'3','2103','2704','3304'";
                }

                frm.lbStatusFilter.Text = cbxFilterStatusTicket.Text.ToString();

                frmReadConversationNotificationWorkOrder.CNStatusTicket = WOStatusTicket;
                frm.FilterIntervalNumber();
            }
            catch(Exception ex) { }
        }

        private void dataHoraDoSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbxFilterDtStartTicket.Text = DateTime.Now.ToString("g");
            tbxFilterDtEndTicket.Text = DateTime.Now.ToString("g");
        }

        private void dataHoraAtualUltimoMinutoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbxFilterDtStartTicket.Text = DateTime.Now.ToString("g");
            tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59"; 
        }

        private void doraHoraAtualComeçoAoFinalDoDiaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbxFilterDtStartTicket.Text = DateTime.Now.ToString("d") + "00:00";
            tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
        }

        private void intervaloDe30DiasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DateTime dataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dataFinal = dataInicial.AddMonths(1).AddDays(-1);
            string formatDate = "dd/MM/yyyy";

            tbxFilterDtStartTicket.Text = dataInicial.ToString(formatDate) + "00:00";
            tbxFilterDtEndTicket.Text = dataFinal.ToString(formatDate) + "23:59";
        }

        private void dataHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tbxFilterDtStartTicket.Text = "01/01/1969 00:00";
            tbxFilterDtEndTicket.Text = DateTime.Now.ToString("d") + "23:59";
        }

        private void btnAccessFrmReadCN_Click(object sender, EventArgs e)
        {
            frmReadConversationNotificationWorkOrder frm = new frmReadConversationNotificationWorkOrder();
            frm.Show();
        }
    }
}