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
    public class Migration_WorkOrder
    {
        ConnectDB conn = new ConnectDB();
        DataTable table = new DataTable();

        public DataTable SelectWorkOrderNum(int numTicketStart, int numTicketEnd)
        {
            SqlCommand command = new SqlCommand
        
       ("SELECT A.WORKORDERID as 'Ticket', " +
        "'Tipo de Ticket' = '2', " +
         "A.TITLE as 'Assunto', " +
         "AaaUser.USER_ID as 'ID Solicitante', " +
         "AaaUser.FIRST_NAME as 'Solicitante', " +
         "H.USER_ID as 'ID Responsavel', " +
         "H.FIRST_NAME as 'Responsavel', " +
        "'Equipe do Responsavel' = 'Suporte', " +
        "'Serviço' = 'Suporte de Software', " +
     //   "CONCAT(M.UDF_CHAR9,'-',SC.NAME) as 'Serviço', " +
         "CAT.CATEGORYNAME as 'Categorias', " +
         "COALESCE(PD.PRIORITYNAME, '6-Não Definido') as 'Prioridade Urgencia', " +
         "CONCAT(B.STATUSID,'-',D.STATUSNAME) as 'Status', " +
         "'Justificativa' = '', " +
         "dbo.RetornaData(A.CREATEDTIME) as 'Data/Hora abertura', " +
         "dbo.RetornaData(B.asSIGNEDTIME) as 'Data/Hora Seq', " +
        "(CASE WHEN a.COMPLETEDTIME = -1 THEN NULL ELSE dbo.retornadata(a.COMPLETEDTIME )end) as 'Data/Hora encerramento', " +
         "'Tag' = 'Migracao', " +
         "'Sequencia' = A.WORKORDERID, " +
         "(CASE WHEN M.UDF_LONG1 = 0 then null else M.UDF_LONG1 end) as 'WorkItem', " + 
         "M.UDF_CHAR3 as 'Observações', " +
         "K.ORG_ID as 'ID Empresa', " +
         "K.NAME as 'Empresa' " +

                        "FROM WorkOrder as A INNER JOIN " +

                         "WorkOrderStates as B ON A.WORKORDERID = B.WORKORDERID INNER JOIN " +
                         "StatusDefinition as D ON B.STATUSID = D.STATUSID LEFT OUTER JOIN " +
                         "WorkOrder_Account as I ON A.WORKORDERID = I.WORKORDERID LEFT OUTER JOIN " +
                         "AaaOrganization as K ON I.ACCOUNTID = K.ORG_ID LEFT OUTER JOIN " +
                         "AaaOrganization as Ks ON I.SUBACCOUNTID = Ks.ORG_ID LEFT OUTER JOIN " +
                         "AaaUser as H ON B.OWNERID = H.USER_ID LEFT OUTER JOIN " +
                        // "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID LEFT OUTER JOIN " +
                         "SubCategoryDefinition as SC ON B.SUBCATEGORYID = SC.SUBCATEGORYID LEFT OUTER JOIN " +
                         "CategoryDefinition as CAT ON B.CATEGORYID = CAT.CATEGORYID LEFT OUTER JOIN " +
                         "PriorityDefinition as PD ON B.PRIORITYID = PD.PRIORITYID LEFT OUTER JOIN " +
                         "AaaUser as iau ON A.REQUESTERID = iau.USER_ID LEFT OUTER JOIN " +
                         "AaaUser ON AaaUser.USER_ID = iau.USER_ID LEFT OUTER JOIN " +
                         "SDUser ON SDUser.USERID = AaaUser.USER_ID LEFT OUTER JOIN " +
                         "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID " +

                        "WHERE A.WORKORDERID BETWEEN('" + numTicketStart + "') AND " +
                        "('" + numTicketEnd + "') ORDER BY 'Ticket'", 
                        
                        conn.Conectar());

            try
            {       
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(table);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
            {
                conn.Desconectar();
            }
            return table;
        }

        public DataTable SelectWorkOrderDate(DateTime dateStart, DateTime dateEnd)
        {
            SqlCommand command = new SqlCommand

       ("SELECT A.WORKORDERID as 'Ticket', " +
        "'Tipo de Ticket' = '2', " +
         "A.TITLE as 'Assunto', " +
         "AaaUser.USER_ID as 'ID Solicitante', " +
         "AaaUser.FIRST_NAME as 'Solicitante', " +
         "H.USER_ID as 'ID Responsavel', " +
         "H.FIRST_NAME as 'Responsavel', " +
        "'Equipe do Responsavel' = 'Suporte', " +
        "'Serviço' = 'Suporte de Software', " +
        //"CONCAT(M.UDF_CHAR9,'-',SC.NAME) as 'Serviço', " +
         "CAT.CATEGORYNAME as 'Categorias', " +
         "COALESCE(PD.PRIORITYNAME, '6-Não Definido') as 'Prioridade Urgencia', " +
         "CONCAT(B.STATUSID,'-',D.STATUSNAME) as 'Status', " +
         "'Justificativa' = '', " +
         "dbo.RetornaData(A.CREATEDTIME) as 'Data/Hora abertura', " +
         "dbo.RetornaData(B.asSIGNEDTIME) as 'Data/Hora Seq', " +
        "(CASE WHEN a.COMPLETEDTIME = -1 THEN NULL ELSE dbo.retornadata(a.COMPLETEDTIME )end) as 'Data/Hora encerramento', " +
         "'Tag' = 'Migracao', " +
         "'Sequencia' = A.WORKORDERID, " +
         "(case when  M.UDF_LONG1 =0 then null else M.UDF_LONG1 end) as 'WorkItem', " +
         "M.UDF_CHAR3 as 'Observações', " +
         "K.ORG_ID as 'ID Empresa', " +
         "K.NAME as 'Empresa' " +

                        "FROM WorkOrder as A INNER JOIN " +
                         "WorkOrderStates as B ON A.WORKORDERID = B.WORKORDERID INNER JOIN " +
                         "StatusDefinition as D ON B.STATUSID = D.STATUSID LEFT OUTER JOIN " +
                         "WorkOrder_Account as I ON A.WORKORDERID = I.WORKORDERID LEFT OUTER JOIN " +
                         "AaaOrganization as K ON I.ACCOUNTID = K.ORG_ID LEFT OUTER JOIN " +
                         "AaaOrganization as Ks ON I.SUBACCOUNTID = Ks.ORG_ID LEFT OUTER JOIN " +
                         "AaaUser as H ON B.OWNERID = H.USER_ID LEFT OUTER JOIN " +
                       //  "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID LEFT OUTER JOIN " +
                         "SubCategoryDefinition as SC ON B.SUBCATEGORYID = SC.SUBCATEGORYID LEFT OUTER JOIN " +
                         "CategoryDefinition as CAT ON B.CATEGORYID = CAT.CATEGORYID LEFT OUTER JOIN " +
                         "PriorityDefinition as PD ON B.PRIORITYID = PD.PRIORITYID LEFT OUTER JOIN " +
                         "AaaUser as iau ON A.REQUESTERID = iau.USER_ID LEFT OUTER JOIN " +
                         "AaaUser ON AaaUser.USER_ID = iau.USER_ID LEFT OUTER JOIN " +
                         "SDUser ON SDUser.USERID = AaaUser.USER_ID LEFT OUTER JOIN " +
                         "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID " +

                        "WHERE dbo.RetornaData(A.CREATEDTIME) BETWEEN('" + dateStart + "') AND ('" + dateEnd + "') " +
                        "ORDER BY 'Ticket'",

                        conn.Conectar());

            try
            {
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(table);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
            {
                conn.Desconectar();
            }
            return table;
        }

        public DataTable SelectWorkOrderNumDateStatus(int numTicketStart, int numTicketEnd, DateTime dateStart, DateTime dateEnd, string statusID)
        {
            SqlCommand command = new SqlCommand

       ("SELECT A.WORKORDERID as 'Ticket', " +
        "'Tipo de Ticket' = '2', " +
         "A.TITLE as 'Assunto', " +
         "AaaUser.USER_ID as 'ID Solicitante', " +
         "AaaUser.FIRST_NAME as 'Solicitante', " +
         "H.USER_ID as 'ID Responsavel', " +
         "H.FIRST_NAME as 'Responsavel', " +
         "'Equipe do Responsavel' = 'Suporte', " +
         "'Servico' = 'Suporte de Software', " +
        //"CONCAT(M.UDF_CHAR9,'-',SC.NAME) as Serviço, " +
         "CAT.CATEGORYNAME as 'Categorias', " +
         "COALESCE(PD.PRIORITYNAME, '6-Não Definido') as 'Prioridade Urgencia', " +
         "CONCAT(B.STATUSID,'-',D.STATUSNAME) as 'Status', " +
         "'Justificativa' = '', " +
         "dbo.RetornaData(A.CREATEDTIME) as 'Data/Hora abertura', " +
         "dbo.RetornaData(B.asSIGNEDTIME) as 'Data/Hora Seq', " +
        "(CASE WHEN a.COMPLETEDTIME = -1 THEN NULL ELSE dbo.retornadata(a.COMPLETEDTIME )end) as 'Data/Hora encerramento', " +
         "'Tag' = 'Migracao', " +
         "'Sequencia' = A.WORKORDERID, " +
         "(case when  M.UDF_LONG1 =0 then null else M.UDF_LONG1 end) as 'WorkItem', " +
         "M.UDF_CHAR3 as 'Observações', " +
         "K.ORG_ID as 'ID Empresa', " +
         "K.NAME as 'Empresa' " +

                        "FROM WorkOrder as A INNER JOIN " +
                         "WorkOrderStates as B ON A.WORKORDERID = B.WORKORDERID INNER JOIN " +
                         "StatusDefinition as D ON B.STATUSID = D.STATUSID LEFT OUTER JOIN " +
                         "WorkOrder_Account as I ON A.WORKORDERID = I.WORKORDERID LEFT OUTER JOIN " +
                         "AaaOrganization as K ON I.ACCOUNTID = K.ORG_ID LEFT OUTER JOIN " +
                         "AaaOrganization as Ks ON I.SUBACCOUNTID = Ks.ORG_ID LEFT OUTER JOIN " +
                         "AaaUser as H ON B.OWNERID = H.USER_ID LEFT OUTER JOIN " +
                       //  "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID LEFT OUTER JOIN " +
                         "SubCategoryDefinition as SC ON B.SUBCATEGORYID = SC.SUBCATEGORYID LEFT OUTER JOIN " +
                         "CategoryDefinition as CAT ON B.CATEGORYID = CAT.CATEGORYID LEFT OUTER JOIN " +
                         "PriorityDefinition as PD ON B.PRIORITYID = PD.PRIORITYID LEFT OUTER JOIN " +
                         "AaaUser as iau ON A.REQUESTERID = iau.USER_ID LEFT OUTER JOIN " +
                         "AaaUser ON AaaUser.USER_ID = iau.USER_ID LEFT OUTER JOIN " +
                         "SDUser ON SDUser.USERID = AaaUser.USER_ID LEFT OUTER JOIN " +
                         "WorkOrder_Fields as M ON A.WORKORDERID = M.WORKORDERID " +

                        "WHERE A.WORKORDERID BETWEEN('" + numTicketStart + "') AND ('" + numTicketEnd + "') " +
                        "AND dbo.RetornaData(A.CREATEDTIME) BETWEEN('" + dateStart + "') AND ('" + dateEnd + "') " +
                        "AND D.STATUSID in(" + statusID + ") " +
                        "ORDER BY 'Ticket'",

                        conn.Conectar());

            try
            {
                command.CommandType = CommandType.Text;
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(table);
            }
            catch (SqlException erro)
            {
                throw erro;
            }
            {
                conn.Desconectar();
            }
            return table;
        }
    }
}