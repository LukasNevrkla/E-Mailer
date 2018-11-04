using E_Mailer.Properties;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace E_Mailer
{
    public class AppViewModel : BindableBase
    {
        #region Private properties

        private ApplicationPages currentPage = ApplicationPages.Login;

        private AppTheme theme = AppTheme.Red;

        private AppLanguage language = AppLanguage.En;

        private bool sideMenuVisibility = false;

        #endregion

        #region Public properties

        public ApplicationPages CurrentPage { get { return currentPage; } set { SetProperty(ref currentPage, value); } }

        public AppTheme Theme { get { return theme; } set { SetProperty(ref theme, value); ReloadDictionaries(); } }

        public AppLanguage Language { get { return language; } set { SetProperty(ref language, value); ReloadDictionaries(); } }

        public bool SideMenuVisibility { get { return sideMenuVisibility; } set { SetProperty(ref sideMenuVisibility, value); } }

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
