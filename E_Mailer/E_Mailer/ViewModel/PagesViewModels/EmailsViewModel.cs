using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.DataModel;

namespace E_Mailer
{
    public class EmailsViewModel : BindableBase
    {
        #region Private properties



        #endregion

        #region Public Properties

        public string E { get; set; } = "LDSD";
        public ObservableCollection<EmailModel> Emails { get; set; } = new ObservableCollection<EmailModel>();

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public EmailsViewModel()
        {
            Emails.Add(new EmailModel("sender", "subject", "fullmessage", new DateTime(2018, 11, 13, 19, 55, 00)));
            Emails.Add(new EmailModel("sender", "subject", "fullmessage", new DateTime(2018, 11, 13, 19, 55, 00)));
        }

        #endregion
    }
}
