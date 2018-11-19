using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.DataModel;
using E_Mailer.Security;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace E_Mailer.Helpers
{
    public class MailClient
    {
        public Pop3Client Client { get; set; }

        public Task<bool> ConnectAsync(string server, string mail, IHavePassword password)
        {
            return Task.Run(() =>
            {
                bool success = true;
                Client = new Pop3Client();

                try
                {
                    Client.Connect(server, 995, true);
                    Client.Authenticate(mail, password.SecurePassword.Unsecure());
                }
                catch
                {
                    success = false;
                }
                return success;
            });
        }

        public Task<List<EmailModel>> GetLastEmailsAsync(int cnt)
        {
            List<EmailModel> emails = new List<EmailModel>();

            return Task.Run(() =>
            {
                if (Client == null)
                    return null;
 
                var count = Client.GetMessageCount();

                try
                {
                    for (int i = 0; i < cnt; i++)
                    {
                        Message message = Client.GetMessage(count - i);
                        emails.Add(new EmailModel(message.Headers.From.DisplayName.ToString(),
                                                  message.Headers.Subject.ToString(),
                                                  message.ToString(),
                                                  message.Headers.DateSent));
                    }
                }
                catch
                {
                    //success = false;
                }
                return emails;
            });
        }
    }
}
