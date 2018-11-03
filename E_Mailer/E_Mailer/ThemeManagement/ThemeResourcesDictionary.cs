﻿using System;
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
            Uri val= null;

            switch(App.Theme)
            {
                case Theme.Red:
                    val = RedSource;
                    break;

                case Theme.Black:
                    val = BlackSource;
                    break;
            }

            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
