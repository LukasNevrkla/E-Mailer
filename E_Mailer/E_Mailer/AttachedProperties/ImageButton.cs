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
    public class ImageButton : Button
    {
        public static readonly DependencyProperty NormalBackgroundImageProperty = DependencyProperty.Register(
            "NormalBackgroundImage", typeof(ImageSource), typeof(ImageButton));

        public ImageSource NormalBackgroundImage
        {
            get { return (ImageSource)GetValue(NormalBackgroundImageProperty); }
            set { SetValue(NormalBackgroundImageProperty, value); }
        }
    }
}
