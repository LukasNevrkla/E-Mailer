using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace E_Mailer
{
    public enum Theme { Red, Black }

    /// <summary>
    /// Interakční logika pro App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static Theme Theme { get; set; } = Theme.Red;

        public void ChangeTheme(Theme newTheme)
        {
            Theme = newTheme;

            foreach (ResourceDictionary dict in Resources.MergedDictionaries)
            {
                if (dict is ThemeResourcesDictionary themeDict)
                    themeDict.UpdateSource();
                else
                    dict.Source = dict.Source;
            }
        }
    }
}
