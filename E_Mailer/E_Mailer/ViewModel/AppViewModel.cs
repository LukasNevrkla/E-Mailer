using E_Mailer.Properties;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using E_Mailer.Helpers;

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

        #endregion

        #region Commands

        public RelayCommand UserCommand { get; set; }
        public RelayCommand UnopenedCommand { get; set; }
        public RelayCommand OpenedCommand { get; set; }
        public RelayCommand StarCommand { get; set; }
        public RelayCommand UnfinishedCommand { get; set; }
        public RelayCommand SendedCommand { get; set; }
        public RelayCommand UnsendedCommand { get; set; }
        public RelayCommand TrashCommand { get; set; }
        public RelayCommand SpamCommand { get; set; }
        public RelayCommand FolderCommand { get; set; }
        public RelayCommand SettingCommand { get; set; }

        #endregion

        #region Constructor

        public AppViewModel()
        {
            UserCommand = new RelayCommand( () =>  ReloadDictionaries());
            UnopenedCommand = new RelayCommand(() => ReloadDictionaries());
            OpenedCommand = new RelayCommand(() => ReloadDictionaries());
            StarCommand = new RelayCommand(() => ReloadDictionaries());
            UnfinishedCommand = new RelayCommand(() => ReloadDictionaries());
            SendedCommand = new RelayCommand(() => ReloadDictionaries());
            UnsendedCommand = new RelayCommand(() => ReloadDictionaries());
            TrashCommand = new RelayCommand(() => ReloadDictionaries());
            SpamCommand = new RelayCommand(() => ReloadDictionaries());
            FolderCommand = new RelayCommand(() => ReloadDictionaries());
            SettingCommand = new RelayCommand(() => CommandHelper.RunAsyncCommand(ref sideMenuFlag, async ()=> 
            {
                await Task.Delay(5);
                if (IoC.Get<AppViewModel>().CurrentPage == ApplicationPages.Settings)
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Login;
                else
                    IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Settings;
            }));
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
