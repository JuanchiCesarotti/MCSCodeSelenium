using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testing
{
    class EmailService
    {
        
            public static async Task Execute(string mailTo, string subject, string body, string mailFrom, string mailName, Dictionary<string, string> args = null)
            {

                try
                {
                    if (string.IsNullOrEmpty(mailTo)) return;



                    var settings = ConfigurationManager.AppSettings;
                    List<EmailAddress> addresses = new List<EmailAddress>();

                    var mailAddressList = mailTo.Split(';').ToList();
                    foreach (string address in mailAddressList)
                        addresses.Add(new EmailAddress(address));

                    var sendGridMail = mailFrom;
                    var sendGridMailName = mailName;
                    var smtpPassword = settings["SmtpPassword"];

                    var apiKey = smtpPassword;
                    var client = new SendGridClient(apiKey);
                    var msg = new SendGridMessage()
                    {
                        From = new EmailAddress(sendGridMail, sendGridMailName),
                        Subject = subject,
                        HtmlContent = $@"{body}"
                    };

                    msg.AddTos(addresses);



                    var response = await client.SendEmailAsync(msg);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        
    }
}
