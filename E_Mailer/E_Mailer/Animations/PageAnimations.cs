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
    {/*
        /// <summary>
        /// Basics page slide in / out animation.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="seconds"></param>
        /// <param name="slideIn"></param>
        /// <returns></returns>
        public static async Task PageBasicsStartEndAnimation(this Page page, float seconds, bool slideIn, bool verticaly)
        {
            var sb = new Storyboard();

            if (verticaly)
                sb.AddSlideVerticaly(seconds, page.WindowHeight, slideIn, true);
            else
                sb.AddSlideHorizontaly(seconds, page.WindowHeight, slideIn, true);

            sb.AddFadeEffect(slideIn, slideIn ? seconds : seconds/2);

            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }*/

        public static async Task PageBasicsAnimation(this Page page, float seconds, SlidePositions start, SlidePositions end, bool fadeIn, double distance)
        {
            var sb = new Storyboard();

            sb.AddSlide(start, end, seconds, OffsetGenerator(start, distance), OffsetGenerator(end, distance));

            sb.AddFadeEffect(fadeIn, seconds);

            sb.Begin(page);
            page.Visibility = Visibility.Visible;

            await Task.Delay((int)(seconds * 1000));
        }

        private static double OffsetGenerator(SlidePositions pos, double offset)
        {
            if (pos == SlidePositions.Center)
                return 0;
            else
                return offset;
        }
    }   
}
