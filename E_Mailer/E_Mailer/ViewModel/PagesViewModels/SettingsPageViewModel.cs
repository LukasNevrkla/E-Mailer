using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.Security;
using System.Windows;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace E_Mailer
{
    public class SettingsPageViewModel : BindableBase
    {
        #region Private properties


        #endregion

        #region Public Properties

        public ObservableCollection<ThemeButtonModel> ThemeButtons { get; set; } = new ObservableCollection<ThemeButtonModel>();
        public ObservableCollection<LanguageButtonModel> LanguageButtons { get; set; } = new ObservableCollection<LanguageButtonModel>();

        #endregion

        #region Commands

        public ParameterizedRelayCommand ThemeSelectCommand { get; set; }
        public ParameterizedRelayCommand LanguageSelectCommand { get; set; }

        #endregion

        #region Constructor

        public SettingsPageViewModel()
        {
            ThemeSelectCommand = new ParameterizedRelayCommand((parameter) => ThemeChange(parameter));
            LanguageSelectCommand = new ParameterizedRelayCommand((parameter) => LanguageChange(parameter));

            /*ThemeResourcesDictionary dict = (ThemeResourcesDictionary)Application.Current.Resources.MergedDictionaries.Where(k 
                => k is ThemeResourcesDictionary).FirstOrDefault();*/

            foreach (AppTheme theme in (AppTheme[])Enum.GetValues(typeof(AppTheme)))
            {
                ThemeButtons.Add(new ThemeButtonModel(theme.ToString(), new SolidColorBrush(Color.FromRgb(100, 0, 0)), theme));
            }

            foreach (AppLanguage lang in (AppLanguage[])Enum.GetValues(typeof(AppLanguage)))
            {
                LanguageButtons.Add(new LanguageButtonModel(lang.ToString(), lang));
            }
        }

        #endregion

        private void ThemeChange(object theme)
        {
            IoC.Get<AppViewModel>().Theme = (AppTheme)theme;
        }

        private void LanguageChange(object lang)
        {
            IoC.Get<AppViewModel>().Language = (AppLanguage)lang;
        }
    }
}
