using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace E_Mailer
{
    public class NormalButton : Button
    {
        public static readonly DependencyProperty NormalBackgroundProperty = DependencyProperty.Register(
                "NormalBackground", typeof(SolidColorBrush), typeof(NormalButton));

        public SolidColorBrush NormalBackground
        {
            get { return (SolidColorBrush)GetValue(NormalBackgroundProperty); }
            set { SetValue(NormalBackgroundProperty, value); }
        }
    }
}
