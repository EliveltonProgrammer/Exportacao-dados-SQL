using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Migration
{
    public class Querys
    {
        ConnectDB conn = new ConnectDB();
        DataTable table = new DataTable();
        public string queryReturn = string.Empty;

        public DataTable Select(string textquery)
        {
            frmQuery frm = new frmQuery();

            try
            {
                if (frm.dataGridViewQuerys.Rows.Count > 0)
                {
                    frm.dataGridViewQuerys.Rows.Clear();
                }

                SqlCommand command = new SqlCommand

                 (textquery, conn.Conectar());

                if (table.Rows.Count > 0)
                {
                    table.Rows.Clear();
                }
                else
                {
                    command.CommandType = CommandType.Text;
                    SqlDataAdapter da = new SqlDataAdapter(command);
                    da.Fill(table);
                }
            }
            catch (SqlException erro)
            {
                queryReturn = erro.ToString();
            }
            catch (Exception ex)
            {
                queryReturn = ex.ToString();
            }
            {
                conn.Desconectar();
            }
            return table;
        }

        public void ResetDataGrid()
        {
            frmQuery frm = new frmQuery();

            try
            {
                if (frm.dataGridViewQuerys.Rows.Count > 0)
                {
                    frm.dataGridViewQuerys.Rows.Clear();
                }

                SqlCommand command = new SqlCommand

                 ("", conn.Conectar());

                if (table.Rows.Count > 0)
                {
                    table.Rows.Clear();
                }
            }
            catch (Exception ex)
            {
                queryReturn = ex.ToString();
            }
        }
    }
}