using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace E_Mailer.Animations
{
    public static class PageAnimations
    {
        /// <summary>
        /// Basics page slide in / out animation.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="slideIn"></param>
        /// <returns></returns>
        public static async Task PageBasicsStartEndAnimation(this Page page, float seconds, bool slideIn)
        {
            var sb = new Storyboard();

            sb.AddSlideVerticaly(seconds, page.WindowHeight, slideIn, true);
            sb.AddFadeEffect(slideIn, slideIn ? seconds : seconds/2);

            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }
    }   
}
