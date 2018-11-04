using System;
using System.Windows;


namespace E_Mailer
{
    public class LanguageResources : ResourceDictionary
    {
        private Uri en;
        private Uri cz;

        public Uri En
        {
            get { return en; }
            set
            {
                en = value;
                UpdateSource();
            }
        }
        public Uri Cz
        {
            get { return cz; }
            set
            {
                cz = value;
                UpdateSource();
            }
        }

        public void UpdateSource()
        {
            Uri val = null;

            switch (IoC.Get<AppViewModel>().Language)
            {
                case AppLanguage.En:
                    val = En;
                    break;

                case AppLanguage.Cz:
                    val = Cz;
                    break;
            }

            if (val != null && base.Source != val)
                base.Source = val;
        }
    }
}
