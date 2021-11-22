using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
namespace HRMS
{
    public class Utility
    {
        public static string SMTP_CONFIG_SECTION_NAME = "Smtp";
        public static string EMAIL_FROM_CONFIG_KEY_NAME = "EmailFrom";
        public static string ADMIN_EMAIL_CONFIG_KEY_NAME = "AdminEmailAddress";

        public static void WriteErrorLog(ErrorLog errorLog)
        {
            var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
            try
            {
                if (errorLog.ErrorMessage.Length > 1023)
                {
                    errorLog.ErrorMessage = errorLog.ErrorMessage.Substring(0, 1022);
                }
                using (SIContext db = new SIContext())
                {
                    //errorLog.Id = Guid.NewGuid();
                    errorLog.UserId = userId;
                    errorLog.CreatedDate = DateTime.Now.Date;
                    errorLog.CreatedDateTime = DateTime.Now;
                    //errorLog.CreatedDateTime = DateTime.UtcNow;
                    db.ErrorLogs.Add(errorLog);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                using (var db = new SIContext())
                {
                    var log = new ErrorLog();
                    //log.Id = Guid.NewGuid();
                    log.CreatedDate = DateTime.Now.Date;
                    log.CreatedDateTime = DateTime.Now;
                    log.ErrorFor = "Exception to write error log";
                    log.ErrorFrom = "WriteErrorLog";
                    log.ErrorMessage = ex.Message.Length > 1023 ? ex.Message.Substring(0, 1022) : ex.Message;
                    db.ErrorLogs.Add(log);
                    db.SaveChanges();
                }
            }
        }


        public async static Task WriteAuditLog(AuditLog auditLog)
        {
            try
            {
                var userId = Convert.ToInt32(Env.GetUserInfo("userid"));
                using (SIContext db = new SIContext())
                {
                    //auditLog.Id = Guid.NewGuid();
                    auditLog.UserId = userId;
                    auditLog.CreatedDate = DateTime.Now.Date;
                    auditLog.CreatedDateTime = DateTime.Now;
                    db.AuditLogs.Add(auditLog);
                    await db.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Writing Audit Log",
                    ErrorFrom = "Utility.WriteAuditLog",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
        }
    }
}