using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Excel;

namespace Migration
{
    public partial class frmMigrations : Form
    {
        public frmMigrations()
        {
            InitializeComponent();
        }

        public void btnReadDataGridWO_Click(object sender, EventArgs e)
        {
            frmReadWorkOrder form = new frmReadWorkOrder();
            form.ShowDialog();
        }

        private void btnReadDataGridActWO_Click(object sender, EventArgs e)
        {
            frmReadConversationNotificationWorkOrder form = new frmReadConversationNotificationWorkOrder();
            form.ShowDialog();
        }

        private void processAttachToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProcessAttachments form = new frmProcessAttachments();
            form.ShowDialog();
        }

        private void executarConsultasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuery frm = new frmQuery();
            frm.Show();
        }
    }
}