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

        public EmailModel selectedItem;

        #endregion

        #region Public Properties

        public ObservableCollection<EmailModel> Emails { get; set; } = new ObservableCollection<EmailModel>();

        public EmailModel SelectedItem
        {
            get { return selectedItem; }
            set { selectedItem = value; ItemIsSelected(value); }
        }

        #endregion

        #region Commands

        public RelayCommand SelectedChangedCommand { get; set; }

        #endregion

        #region Constructor

        public EmailsViewModel()
        {
            SelectedChangedCommand = new RelayCommand(() => ItemSelectedChanged());
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

        private void ItemIsSelected(object email)
        {
            if (email == null)
                return;
            EmailModel e = (EmailModel)email;

            IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.SelectedEmail;
            IoC.Get<AppViewModel>().SelectedEmail = e;
        }

        private void ItemSelectedChanged()
        {
            if (SelectedItem.IsOpened)
                SelectedItem.IsOpened = false;
            else
                SelectedItem.IsOpened = true;
        }
    }
}
