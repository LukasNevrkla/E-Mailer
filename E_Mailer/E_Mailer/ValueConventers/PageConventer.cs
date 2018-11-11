using System;
using System.Diagnostics;
using System.Globalization;

namespace E_Mailer
{
    /// <summary>
    /// Converts the <see cref="ApplicationPage"/> to an actual view/page
    /// </summary>
    public class PageConverter : BaseValueConverter<PageConverter>
    {
        public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Find the appropriate page
            switch ((ApplicationPages)value)
            {
                case ApplicationPages.Login:
                    return new LoginPage();

                case ApplicationPages.Register:
                    return new RegisterPage();

                case ApplicationPages.Settings:
                    return new SettingsPage();

                default:
                    Debugger.Break();
                    return null;
            }
        }

        public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}