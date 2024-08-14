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
    public class Migration_ConversationNotification_WorkOrder
    {
        ConnectDB conn = new ConnectDB();
        DataTable table = new DataTable();

        public DataTable SelectActionsWorkOrderNumber(int numTicketStart, int numTicketEnd, string statusID)
        {
            SqlCommand command = new SqlCommand

                  ("SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                     //ATRIBUTOS INTERAÇÕES CLIENTE
                                     "Conversation.WORKORDERID as 'Ticket' , " +
                                     "dbo.RetornaData(Conversation.CREATEDTIME) as 'Data/Hora', " +
                                     "CONCAT(WorkOrderStates.STATUSID,'-',StatusDefinition.STATUSNAME) as 'Status', " +
                                     "'Ação Publica/Interna' = 'Publica', " +
                                     "Conversation.REQUESTERID as 'Gerador', " +
                                     "AaaUser.FIRST_NAME as 'Usuário', " +
                                     "CAST(ConversationDescription.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                     "Conversation.CONVERSATIONID as 'ID Conversa', " +
                                     "Conversation.CREATEDTIME as 'Data Sequencia', " +
                                     "ConversationAttachment.ATTACHMENTID as 'ID Anexo', " +
                                     "SDeskAttachment.ATTACHMENTPATH as 'Diretório', " +
                                     "'Nome Arquivo' as 'Nome Arquivo', " +
                                     "'Content Type' as 'Content Type' " +

                                     "FROM WorkOrder " +

                                    "INNER JOIN WorkOrderStates ON WorkOrderStates.WORKORDERID = WorkOrder.WORKORDERID " +
                                    "INNER JOIN StatusDefinition ON StatusDefinition.STATUSID = WorkOrderStates.STATUSID " +
                                    "LEFT OUTER JOIN Conversation ON Conversation.WORKORDERID = WorkOrder.WORKORDERID " +
                                    "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Conversation.REQUESTERID " +
                                    "LEFT OUTER JOIN ConversationDescription ON ConversationDescription.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                    "LEFT OUTER JOIN ConversationAttachment ON ConversationAttachment.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                    "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = ConversationAttachment.ATTACHMENTID " +

                                    "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') AND " +
                                    "WorkOrderStates.STATUSID in(" + statusID + ") " +
                                    "AND Conversation.CONVERSATIONID IS NOT NULL " +


                                   //-----------------------------------------------------------------------------------------------	
                                   "UNION ALL " +
                                    "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                    //ATRIBUTOS INTERAÇÕES SUPORTE
                                    "Notify_WorkOrder.WORKORDERID as 'Ticket' , " +
                                    "dbo.RetornaData(Notification.NOTIFICATIONDATE) as 'Data/Hora', " +
                                    "CONCAT(WorkOrderStates.STATUSID,'-',StatusDefinition.STATUSNAME) as 'Status', " +
                                    "'Ação Publica/Interna' = 'Publica', " +
                                    "Notification.SENDERID as 'Gerador', " +
                                    "AaaUser.FIRST_NAME as 'Usuário', " +
                                    "CAST(NotificationToDescription.NOTIFICATIONDESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                    "Notify_WorkOrder.NOTIFICATIONID as 'ID Conversa', " +
                                    "Notification.NOTIFICATIONDATE as 'Data Sequencia', " +
                                    "Notify_Attachments.ATTACHMENTID as 'ID Anexo', " +
                                    "SDeskAttachment.ATTACHMENTPATH as 'Diretório', " +
                                     "'Nome Arquivo' as 'Nome Arquivo', " +
                                     "'Content Type' as 'Content Type' " +

                                    "FROM WorkOrder " +

                                   "INNER JOIN WorkOrderStates ON WorkOrderStates.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "INNER JOIN StatusDefinition ON StatusDefinition.STATUSID = WorkOrderStates.STATUSID " +
                                   "LEFT OUTER JOIN Notify_WorkOrder ON Notify_WorkOrder.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN Notification ON Notification.NOTIFICATIONID = Notify_WorkOrder.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Notification.SENDERID " +
                                   "LEFT OUTER JOIN NotificationToDescription ON NotificationToDescription.NOTIFICATIONID = Notification.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN Notify_Attachments ON Notify_Attachments.NOTIFICATIONID =  Notify_WorkOrder.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = Notify_Attachments.ATTACHMENTID " +

                                   "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') AND " +
                                   "WorkOrderStates.STATUSID in(" + statusID + ") " +
                                   "AND Notification.SENDERID != '1' " + //SENDERID 1 = System 
                                   "AND Notification.NOTIFICATIONID IS NOT NULL " +


                                   //-----------------------------------------------------------------------------------------------		   

                                   "UNION ALL " +
                                   "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                    //ATRIBUTOS RESOLUCAO TICKET
                                    "RequestResolver.REQUESTID as 'Ticket', " +
                                    "dbo.RetornaData(RequestResolution.LASTUPDATEDTIME) as 'Data/Hora', " +
                                    "CONCAT(WorkOrderStates.STATUSID,'-',StatusDefinition.STATUSNAME) as 'Status', " +
                                    "'Ação Publica/Interna' = 'Publica', " +
                                    "RequestResolver.TECHNICIANID as 'Gerador', " +
                                    "AaaUser.FIRST_NAME as 'Usuário', " +
                                    "CAST(RequestResolution.RESOLUTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                    "RequestResolution.REQUESTID  as 'ID Conversa', " +
                                    "RequestResolution.LASTUPDATEDTIME as 'Data Sequencia', " +
                                    "SolutionsAttachment.ATTACHMENTID as 'ID Anexo', " +
                                    "SDeskAttachment.ATTACHMENTPATH as 'Diretório', " +
                                     "'Nome Arquivo' as 'Nome Arquivo', " +
                                     "'Content Type' as 'Content Type' " +

                                   "FROM WorkOrder " +

                                   "INNER JOIN WorkOrderStates ON WorkOrderStates.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "INNER JOIN StatusDefinition ON StatusDefinition.STATUSID = WorkOrderStates.STATUSID " +
                                   "LEFT OUTER JOIN RequestResolution ON RequestResolution.REQUESTID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN RequestResolver ON RequestResolver.REQUESTID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.RESOLVEDBY " +
                                   "LEFT OUTER JOIN SolutionsAttachment ON SolutionsAttachment.SOLUTIONID = RequestResolution.REQUESTID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = SolutionsAttachment.ATTACHMENTID " +

                                   "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') AND " +
                                   "WorkOrderStates.STATUSID in(" + statusID + ") " +
                                   "AND RequestResolution.REQUESTID IS NOT NULL " +

                                   //--------------------------------------------------------------------------------------------------	

                                   "UNION ALL " +
                                   "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                   //ATRIBUTOS TICKET
                                   "WorkOrder.WORKORDERID as 'Ticket', " +
                                   "dbo.RetornaData(WorkOrder.CREATEDTIME) as 'Data/Hora', " +
                                   "CONCAT(WorkOrderStates.STATUSID,'-',StatusDefinition.STATUSNAME) as 'Status', " +
                                   "'Ação Publica/Interna' = 'Publica', " +
                                   "WorkOrder.REQUESTERID as 'Gerador', " +
                                   "AaaUser.FIRST_NAME as 'Usuário', " +
                                   "CAST(WorkOrder.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                   "WorkOrder.WORKORDERID as 'ID Conversa', " +
                                   "WorkOrder.CREATEDTIME as 'Data Sequencia', " +
                                   "WorkOrderAttachment.ATTACHMENTID as 'ID Anexo', " +
                                   "SDeskAttachment.ATTACHMENTPATH as 'Diretório', " +
                                     "'Nome Arquivo' as 'Nome Arquivo', " +
                                     "'Content Type' as 'Content Type' " +

                                   "FROM WorkOrder " +

                                   "INNER JOIN WorkOrderStates ON WorkOrderStates.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "INNER JOIN StatusDefinition ON StatusDefinition.STATUSID = WorkOrderStates.STATUSID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.CREATEDBYID " +
                                   "LEFT OUTER JOIN WorkOrderAttachment ON WorkOrderAttachment.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = WorkOrderAttachment.ATTACHMENTID " +

                                   "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') AND " +
                                   "WorkOrderStates.STATUSID in(" + statusID + ") " +
                                   "AND WorkOrder.WORKORDERID IS NOT NULL " +

                                   "ORDER BY WorkOrder.WORKORDERID ASC, 'Data Sequencia' ASC;",

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

        public DataTable SelectActionsWorkOrderDate(DateTime dateTicketStart, DateTime dateTicketEnd)
        {
            SqlCommand command = new SqlCommand

                  ("SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                     //ATRIBUTOS INTERAÇÕES CLIENTE
                                     "Conversation.WORKORDERID as 'Ticket' , " +
                                     "dbo.RetornaData(Conversation.CREATEDTIME) as 'Data/Hora', " +
                                     "'Ação Publica/Interna' = 'Publica', " +
                                     "Conversation.REQUESTERID as 'Gerador', " +
                                     "AaaUser.FIRST_NAME as 'Usuário', " +
                                     "CAST(ConversationDescription.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                     "Conversation.CONVERSATIONID as 'ID Conversa', " +
                                     "Conversation.CREATEDTIME as 'Data Sequencia', " +
                                     "ConversationAttachment.ATTACHMENTID as 'ID Anexo', " +
                                     "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                     "FROM WorkOrder " +

                                    "LEFT OUTER JOIN Conversation ON Conversation.WORKORDERID = WorkOrder.WORKORDERID " +
                                    "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Conversation.REQUESTERID " +
                                    "LEFT OUTER JOIN ConversationDescription ON ConversationDescription.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                    "LEFT OUTER JOIN ConversationAttachment ON ConversationAttachment.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                    "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = ConversationAttachment.ATTACHMENTID " +

                                    "WHERE dbo.RetornaData(Conversation.CREATEDTIME) BETWEEN ('" + dateTicketStart + "') AND ('" + dateTicketEnd + "') " +
                                    "AND Conversation.CONVERSATIONID IS NOT NULL " +


                                   //-----------------------------------------------------------------------------------------------	
                                   "UNION ALL " +
                                    "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                    //ATRIBUTOS INTERAÇÕES SUPORTE
                                    "Notify_WorkOrder.WORKORDERID as 'Ticket' , " +
                                    "dbo.RetornaData(Notification.NOTIFICATIONDATE) as 'Data/Hora' , " +
                                    "'Ação Publica/Interna' = 'Publica', " +
                                    "Notification.SENDERID as 'Gerador', " +
                                    "AaaUser.FIRST_NAME as 'Usuário', " +
                                    "CAST(NotificationToDescription.NOTIFICATIONDESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                    "Notify_WorkOrder.NOTIFICATIONID as 'ID Conversa', " +
                                    "Notification.NOTIFICATIONDATE as 'Data Sequencia', " +
                                    "Notify_Attachments.ATTACHMENTID as 'ID Anexo', " +
                                    "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                    "FROM WorkOrder " +

                                   "LEFT OUTER JOIN Notify_WorkOrder ON Notify_WorkOrder.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN Notification ON Notification.NOTIFICATIONID = Notify_WorkOrder.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Notification.SENDERID " +
                                   "LEFT OUTER JOIN NotificationToDescription ON NotificationToDescription.NOTIFICATIONID = Notification.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN Notify_Attachments ON Notify_Attachments.NOTIFICATIONID =  Notify_WorkOrder.NOTIFICATIONID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = Notify_Attachments.ATTACHMENTID " +

                                   "WHERE dbo.RetornaData(Notification.NOTIFICATIONDATE) BETWEEN ('" + dateTicketStart + "') AND ('" + dateTicketEnd + "') AND Notification.SENDERID != '1' " + //SENDERID 1 = System 
                                   "AND Notification.NOTIFICATIONID IS NOT NULL " +


                                   //-----------------------------------------------------------------------------------------------		   

                                   "UNION ALL " +
                                   "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                    //ATRIBUTOS RESOLUCAO TICKET
                                    "RequestResolver.REQUESTID as 'Ticket', " +
                                    "dbo.RetornaData(RequestResolution.LASTUPDATEDTIME) as 'Data/Hora', " +
                                    "'Ação Publica/Interna' = 'Publica', " +
                                    "RequestResolver.TECHNICIANID as 'Gerador', " +
                                    "AaaUser.FIRST_NAME as 'Usuário', " +
                                    "CAST(RequestResolution.RESOLUTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                    "RequestResolution.REQUESTID  as 'ID Conversa', " +
                                    "RequestResolution.LASTUPDATEDTIME as 'Data Sequencia', " +
                                    "SolutionsAttachment.ATTACHMENTID as 'ID Anexo', " +
                                    "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                   "FROM WorkOrder " +

                                   "LEFT OUTER JOIN RequestResolution ON RequestResolution.REQUESTID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN RequestResolver ON RequestResolver.REQUESTID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.RESOLVEDBY " +
                                   "LEFT OUTER JOIN SolutionsAttachment ON SolutionsAttachment.SOLUTIONID = RequestResolution.REQUESTID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = SolutionsAttachment.ATTACHMENTID " +

                                   "WHERE dbo.RetornaData(RequestResolution.LASTUPDATEDTIME) BETWEEN ('" + dateTicketStart + "') AND ('" + dateTicketEnd + "') " +
                                   "AND RequestResolution.REQUESTID IS NOT NULL " +

                                   //--------------------------------------------------------------------------------------------------	

                                   "UNION ALL " +
                                   "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                   //ATRIBUTOS TICKET
                                   "WorkOrder.WORKORDERID as 'Ticket', " +
                                   "dbo.RetornaData(WorkOrder.CREATEDTIME) as 'Data/Hora', " +
                                   "'Ação Publica/Interna' = 'Publica', " +
                                   "WorkOrder.REQUESTERID as 'Gerador', " +
                                   "AaaUser.FIRST_NAME as 'Usuário', " +
                                   "CAST(WorkOrder.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                   "WorkOrder.WORKORDERID as 'ID Conversa', " +
                                   "WorkOrder.CREATEDTIME as 'Data Sequencia', " +
                                   "WorkOrderAttachment.ATTACHMENTID as 'ID Anexo', " +
                                   "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                   "FROM WorkOrder " +

                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.CREATEDBYID " +
                                   "LEFT OUTER JOIN WorkOrderAttachment ON WorkOrderAttachment.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = WorkOrderAttachment.ATTACHMENTID " +

                                   "WHERE dbo.RetornaData(WorkOrder.CREATEDTIME) BETWEEN ('" + dateTicketStart + "') AND ('" + dateTicketEnd + "') " +
                                   "AND WorkOrder.WORKORDERID IS NOT NULL " +

                                   "ORDER BY WorkOrder.WORKORDERID ASC, 'Data Sequencia' ASC;",

                                   conn.Conectar());
            try
            {
                Convert.ToDateTime(dateTicketStart).ToString();
                Convert.ToDateTime(dateTicketEnd).ToString();

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


        public DataTable SelectActionsAttachWorkOrder(int numTicketStart, int numTicketEnd)
        {
            SqlCommand command = new SqlCommand

                 ("SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                    //ATRIBUTOS INTERAÇÕES CLIENTE
                                    "Conversation.WORKORDERID as 'Ticket' , " +
                                    "dbo.RetornaData(Conversation.CREATEDTIME) as 'Data/Hora', " +
                                    "'Ação Publica/Interna' = 'Publica', " +
                                    "Conversation.REQUESTERID as 'Gerador', " +
                                    "AaaUser.FIRST_NAME as 'Usuário', " +
                                    "CAST(ConversationDescription.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                    "Conversation.CONVERSATIONID as 'ID Conversa', " +
                                    "Conversation.CREATEDTIME as 'Data Sequencia', " +
                                    "ConversationAttachment.ATTACHMENTID as 'ID Anexo', " +
                                    "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                    "FROM WorkOrder " +

                                   "LEFT OUTER JOIN Conversation ON Conversation.WORKORDERID = WorkOrder.WORKORDERID " +
                                   "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Conversation.REQUESTERID " +
                                   "LEFT OUTER JOIN ConversationDescription ON ConversationDescription.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                   "LEFT OUTER JOIN ConversationAttachment ON ConversationAttachment.CONVERSATIONID = Conversation.CONVERSATIONID " +
                                   "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = ConversationAttachment.ATTACHMENTID " +

                                   "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') " +
                                   "AND Conversation.CONVERSATIONID IS NOT NULL AND SDeskAttachment.ATTACHMENTPATH IS NOT NULL " +


                                  //-----------------------------------------------------------------------------------------------	
                                  "UNION ALL " +
                                   "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                   //ATRIBUTOS INTERAÇÕES SUPORTE
                                   "Notify_WorkOrder.WORKORDERID as 'Ticket' , " +
                                   "dbo.RetornaData(Notification.NOTIFICATIONDATE) as 'Data/Hora' , " +
                                   "'Ação Publica/Interna' = 'Publica', " +
                                   "Notification.SENDERID as 'Gerador', " +
                                   "AaaUser.FIRST_NAME as 'Usuário', " +
                                   "CAST(NotificationToDescription.NOTIFICATIONDESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                   "Notify_WorkOrder.NOTIFICATIONID as 'ID Conversa', " +
                                   "Notification.NOTIFICATIONDATE as 'Data Sequencia', " +
                                   "Notify_Attachments.ATTACHMENTID as 'ID Anexo', " +
                                   "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                   "FROM WorkOrder " +

                                  "LEFT OUTER JOIN Notify_WorkOrder ON Notify_WorkOrder.WORKORDERID = WorkOrder.WORKORDERID " +
                                  "LEFT OUTER JOIN Notification ON Notification.NOTIFICATIONID = Notify_WorkOrder.NOTIFICATIONID " +
                                  "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = Notification.SENDERID " +
                                  "LEFT OUTER JOIN NotificationToDescription ON NotificationToDescription.NOTIFICATIONID = Notification.NOTIFICATIONID " +
                                  "LEFT OUTER JOIN Notify_Attachments ON Notify_Attachments.NOTIFICATIONID =  Notify_WorkOrder.NOTIFICATIONID " +
                                  "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = Notify_Attachments.ATTACHMENTID " +

                                  "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') AND Notification.SENDERID != '1' " + //SENDERID 1 = System 
                                  "AND Notification.NOTIFICATIONID IS NOT NULL AND SDeskAttachment.ATTACHMENTPATH IS NOT NULL " +


                                  //-----------------------------------------------------------------------------------------------		   

                                  "UNION ALL " +
                                  "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                   //ATRIBUTOS RESOLUCAO TICKET
                                   "RequestResolver.REQUESTID as 'Ticket', " +
                                   "dbo.RetornaData(RequestResolution.LASTUPDATEDTIME) as 'Data/Hora', " +
                                   "'Ação Publica/Interna' = 'Publica', " +
                                   "RequestResolver.TECHNICIANID as 'Gerador', " +
                                   "AaaUser.FIRST_NAME as 'Usuário', " +
                                   "CAST(RequestResolution.RESOLUTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                   "RequestResolution.REQUESTID  as 'ID Conversa', " +
                                   "RequestResolution.LASTUPDATEDTIME as 'Data Sequencia', " +
                                   "SolutionsAttachment.ATTACHMENTID as 'ID Anexo', " +
                                   "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                  "FROM WorkOrder " +

                                  "LEFT OUTER JOIN RequestResolution ON RequestResolution.REQUESTID = WorkOrder.WORKORDERID " +
                                  "LEFT OUTER JOIN RequestResolver ON RequestResolver.REQUESTID = WorkOrder.WORKORDERID " +
                                  "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.RESOLVEDBY " +
                                  "LEFT OUTER JOIN SolutionsAttachment ON SolutionsAttachment.SOLUTIONID = RequestResolution.REQUESTID " +
                                  "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = SolutionsAttachment.ATTACHMENTID " +

                                  "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') " +
                                  "AND RequestResolution.REQUESTID IS NOT NULL AND SDeskAttachment.ATTACHMENTPATH IS NOT NULL " +

                                  //--------------------------------------------------------------------------------------------------	

                                  "UNION ALL " +
                                  "SELECT WorkOrder.WORKORDERID as 'WOTicket', " +

                                  //ATRIBUTOS TICKET
                                  "WorkOrder.WORKORDERID as 'Ticket', " +
                                  "dbo.RetornaData(WorkOrder.CREATEDTIME) as 'Data/Hora', " +
                                  "'Ação Publica/Interna' = 'Publica', " +
                                  "WorkOrder.REQUESTERID as 'Gerador', " +
                                  "AaaUser.FIRST_NAME as 'Usuário', " +
                                  "CAST(WorkOrder.DESCRIPTION as varchar(7000)) COLLATE Latin1_General_CI_AS as 'Texto Conversa', " +
                                  "WorkOrder.WORKORDERID as 'ID Conversa', " +
                                  "WorkOrder.CREATEDTIME as 'Data Sequencia', " +
                                  "WorkOrderAttachment.ATTACHMENTID as 'ID Anexo', " +
                                  "SDeskAttachment.ATTACHMENTPATH as 'Diretório' " +

                                  "FROM WorkOrder " +

                                  "LEFT OUTER JOIN AaaUser ON AaaUser.USER_ID = WorkOrder.CREATEDBYID " +
                                  "LEFT OUTER JOIN WorkOrderAttachment ON WorkOrderAttachment.WORKORDERID = WorkOrder.WORKORDERID " +
                                  "LEFT OUTER JOIN SDeskAttachment ON SDeskAttachment.ATTACHMENTID = WorkOrderAttachment.ATTACHMENTID " +

                                  "WHERE WorkOrder.WORKORDERID BETWEEN ('" + numTicketStart + "') AND ('" + numTicketEnd + "') " +
                                  "AND WorkOrder.WORKORDERID IS NOT NULL AND SDeskAttachment.ATTACHMENTPATH IS NOT NULL " +

                                  "ORDER BY WorkOrder.WORKORDERID ASC, 'Data Sequencia' ASC;",

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