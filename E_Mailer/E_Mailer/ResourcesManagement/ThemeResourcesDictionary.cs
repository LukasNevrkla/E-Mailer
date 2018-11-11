using System;
using System.Collections.Generic;
using System.Windows;


namespace E_Mailer
{
    public class ThemeResourcesDictionary : ResourceDictionary
    {
        private Uri redSource;
        private Uri blackSource;

        public Uri RedSource
        {
            get { return redSource; }
            set
            {
                redSource = value;
                UpdateSource();
            }
        }
        public Uri BlackSource
        {
            get { return blackSource; }
            set
            {
                blackSource = value;
                UpdateSource();
            }
        }
        /*
        public List<Uri> Themes= new List<Uri>();

        public ThemeResourcesDictionary()
        {
            Themes.Add(RedSource);
            Themes.Add(BlackSource);
        }*/

        public void UpdateSource()
        {
            Uri val = null;

            switch (IoC.Get<AppViewModel>().Theme)
            {
                case AppTheme.Red:
                    val = RedSource;
                    break;

                case AppTheme.Black:
                    val = BlackSource;
                    break;
            }

            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
