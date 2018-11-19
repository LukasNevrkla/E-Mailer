using E_Mailer.Properties;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using E_Mailer.Helpers;
using System.Collections.ObjectModel;

namespace E_Mailer
{
    public class AppViewModel : BindableBase
    {
        #region Private properties

        private ApplicationPages currentPage = ApplicationPages.Login;

        private AppTheme theme = AppTheme.Red;

        private AppLanguage language = AppLanguage.Cz;

        private bool sideMenuVisibility = false;

        private bool sideMenuFlag = false;

        #endregion

        #region Public properties

        public ApplicationPages CurrentPage { get { return currentPage; } set { SetProperty(ref currentPage, value); } }

        public AppTheme Theme { get { return theme; } set { SetProperty(ref theme, value); ReloadDictionaries(); } }

        public AppLanguage Language { get { return language; } set { SetProperty(ref language, value); ReloadDictionaries(); } }

        public bool SideMenuVisibility { get { return sideMenuVisibility; } set { SetProperty(ref sideMenuVisibility, value); } }

        public ObservableCollection<SideMenuButtonModel> SideMenuButtons { get; set; } = new ObservableCollection<SideMenuButtonModel>();

        //public OpenPop.Pop3.Pop3Client Client { get; set; }

        public MailClient MailClient { get; set; }

        #endregion

        #region Commands


        #endregion

        #region Constructor

        public AppViewModel()
        {
            MailClient = new MailClient();
            InitializeSideMenu();
        }

        #endregion

        #region Initialization

        private void InitializeSideMenu()
        {
            string prefix = "../Images/SideBar/";

            AddSideMenuButton(prefix+ "User_white.PNG", async () =>
            {
                await Task.Delay(5);
            });

            AddSideMenuButton(prefix + "Envelope_white.PNG", async () =>
            {
                await Task.Delay(5);
                if (IoC.Get<AppViewModel>().CurrentPage == ApplicationPages.Emails)
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Login;
                else
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Emails;
            });

            AddSideMenuButton(prefix + "OpenEnvelope_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Star_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Document_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Check_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Cross_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Trash_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Warning_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Folder_white.PNG", async () =>
            {
                await Task.Delay(5);
            });
            AddSideMenuButton(prefix + "Setting_white.PNG", async () =>
            {
                await Task.Delay(0);
                if (IoC.Get<AppViewModel>().CurrentPage == ApplicationPages.Settings)
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Login;
                else
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Settings;
            });
        }

        private void AddSideMenuButton(string ImageUri, Func<Task> action)
        {
            SideMenuButtons.Add(new SideMenuButtonModel(ImageUri,
               new RelayCommand(() => CommandHelper.RunAsyncCommand(ref sideMenuFlag, async () =>
               {
                   await action();
               })
               )));
        }

        #endregion

        public void ReloadDictionaries()
        {
            foreach (ResourceDictionary dict in App.Current.Resources.MergedDictionaries)
            {
                if (dict is ThemeResourcesDictionary themeDict)
                    themeDict.UpdateSource();

                else if (dict is LanguageResources lanDict)
                    lanDict.UpdateSource();

                else
                    dict.Source = dict.Source;
            }
        }
    }
}
