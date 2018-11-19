using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.DataModel;

using System.Net;
using System.Net.Mail;
using OpenPop.Pop3;
using OpenPop.Mime;

namespace E_Mailer
{
    public class EmailsViewModel : BindableBase
    {
        #region Private properties



        #endregion

        #region Public Properties

        public ObservableCollection<EmailModel> Emails { get; set; } = new ObservableCollection<EmailModel>();

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public EmailsViewModel()
        {
            App.Current.Dispatcher.Invoke(() => LoadLastEmailsAsync(10));
        }

        #endregion

        public async void LoadLastEmailsAsync(int cnt)
        {
            List<EmailModel> emails = await IoC.Get<AppViewModel>().MailClient.GetLastEmailsAsync(cnt);

            foreach (EmailModel email in emails)
            {
                Emails.Add(email);
            }
        }
    }
}
