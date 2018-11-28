using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer.DataModel
{
    public class EmailModel: BindableBase
    {
        public bool IsSelected { get; set; } = false;
        public bool HasStar { get; set; }

        public string Sender { get; set; }
        public string Subject { get; set; }
        public string MessagePreview { get; set; }
        public string FullMessage { get; set; }
        public string Sended_prewiew { get; set; }
        public DateTime Sended { get; set; }

        private bool isOpened=false;
        public bool IsOpened
        {
            get { return isOpened; }
            set
            {
                SetProperty(ref isOpened, value);
                Height = (isOpened) ? 100 : 0;
            }
        }

        private int height = 0;
        public int Height
        {
            get { return height; }
            set
            {
                SetProperty(ref height, value);
            }
        }

        public EmailModel(string sender, string subject, string fullMessage, DateTime sended, bool hasStar = false)
        {
            Sender = sender;
            Subject = subject;
            //MessagePreview = fullMessage.Substring(0,50);
            FullMessage = fullMessage;
            Sended_prewiew = sended.ToShortDateString();
            Sended = sended;
        }
    }
}
