using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using HRMS.Models;

namespace HRMS
{
    public class NotificationService
    {
        #region  Private members

        private static SmtpConfig GetSmtpConfiguration()
        {
            SmtpConfig smtp = ConfigurationService.GetConfigurationValue<SmtpConfig>(Utility.SMTP_CONFIG_SECTION_NAME);
            return smtp;
        }

        private static bool SendEmail(MailAddress fromAddress, List<MailAddress> toAddresses, string subject, string body, bool isBodyHtml)
        {
            bool result = false;
            try
            {
                SmtpConfig smtpConfig = GetSmtpConfiguration();
                MailMessage mail = new MailMessage();
                SmtpClient client = new SmtpClient(smtpConfig.HostName, smtpConfig.Port);

                toAddresses.ForEach(emailAddress =>
                {
                    mail.To.Add(emailAddress);
                });
                mail.From = fromAddress;
                mail.Subject = subject;
                mail.IsBodyHtml = isBodyHtml;
                mail.Body = body;
                client.EnableSsl = smtpConfig.SSLProtocol;
                client.Credentials = new NetworkCredential(smtpConfig.UserId, smtpConfig.Password);
                client.Send(mail);
                result = true;
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Sending Email",
                    ErrorFrom = "NotificationService.SendEmail",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return result;
        }

        #endregion

        public static bool SendContactUsEmail(EmailContact emailContact)
        {
            string emailFrom = ConfigurationService.GetConfigurationValue(Utility.EMAIL_FROM_CONFIG_KEY_NAME);
            string emailFromName = emailFrom.Split('<')[0];
            string emailFromEmailPart = emailFrom.Split('<')[1];
            MailAddress fromAddress = new MailAddress(emailFromEmailPart.Substring(0, emailFromEmailPart.Length - 1), emailFromName);
            List<MailAddress> toAddresses = new List<MailAddress>();
            toAddresses.Add(new MailAddress(ConfigurationService.GetConfigurationValue(Utility.ADMIN_EMAIL_CONFIG_KEY_NAME)));
            //toAddresses.Add(new MailAddress(emailContact.ApplicantEmail));
            if (emailContact.ApplicantEmail != null)
            {
                toAddresses.Add(new MailAddress(emailContact.ApplicantEmail));
            }
            string subject = "Contact Us Email";
            string body = "<html><body>";
            body += "This is system generated email from contact page. <br>" +
                 "<br>The message from - <br>" +
                 "<b>Name:</b> " + emailContact.ApplicantName + "<br>" +
                 "<b>Contact No:</b> " + emailContact.ApplicantContactNo + "<br>" +
                 "<b>Email:</b> " + emailContact.ApplicantEmail + "<br><br>" +
                 "<b>Message:</b> <br> " + emailContact.Description;

            body += "</body></html>";
            bool isBodyHtml = true;
            return SendEmail(fromAddress, toAddresses, subject, body, isBodyHtml);
        }
    }
}