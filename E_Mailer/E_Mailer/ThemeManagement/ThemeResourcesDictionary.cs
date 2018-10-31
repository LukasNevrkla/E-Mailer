using System;
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

        public void UpdateSource()
        {
            var val = App.Theme == Theme.Red ? RedSource : blackSource;

            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
