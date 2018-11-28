using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.DataModel;
using E_Mailer.Security;
using OpenPop.Mime;
using OpenPop.Pop3;
using System.IO;

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
                                                  GetFullMessage(message),
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

        public string GetFullMessage(Message message)
        {/*
            string x=message.MessagePart.ContentType.MediaType;
            message.
            
            MessagePart part = message.FindFirstHtmlVersion();
            return new FileInfo("test.eml");
            //k.Save(new FileInfo("test.eml"));
            */

            StringBuilder builder = new StringBuilder();

                MessagePart plainText = message.FindFirstPlainTextVersion();
                if (plainText != null)
                {
                    // We found some plaintext!
                    builder.Append(plainText.GetBodyAsText());
                }
                else
                {
                    // Might include a part holding html instead
                    MessagePart html = message.FindFirstHtmlVersion();
                    if (html != null)
                    {
                        // We found some html!
                        builder.Append(html.GetBodyAsText());
                    }
                }
            //System.Windows.MessageBox.Show(builder.ToString());

            return builder.ToString();
        }
    }
}
