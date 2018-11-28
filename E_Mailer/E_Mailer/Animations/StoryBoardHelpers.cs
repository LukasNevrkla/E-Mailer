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
    public static class StoryBoardHelpers
    {
        #region Slide effect

        public static void AddSlide(this Storyboard storyboard, SlidePositions start, SlidePositions end, float seconds, double start_offset, double end_offset)
        {
            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = SlidePosToThickness(start, start_offset),
                To = SlidePosToThickness(end, end_offset),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        public static Thickness SlidePosToThickness (SlidePositions position, double offset)
        {
            Thickness result;

            switch(position)
            {
                case SlidePositions.Left:
                    result = new Thickness(-offset, 0, offset, 0);
                    break;

                case SlidePositions.Top:
                    result = new Thickness(0,-offset, 0, offset);
                    break;

                case SlidePositions.Right:
                    // result = new Thickness(0, 0, -offset, 0);
                    result = new Thickness(offset, 0, -offset, 0);
                    break;

                case SlidePositions.Bottom:
                    result = new Thickness(0, offset, 0, -offset);
                    break;

                case SlidePositions.Center:
                default:
                    result = new Thickness(0, 0, 0, 0);
                    break;
            }

            return result;
        }

        /*
        /// <summary>
        /// Add verticaly slide. 
        /// If slideIn = true, it will slide to middle. Else it slide out.
        /// If bottomDirection = true, it will slide (to/ from) bottom. Else from top.
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="slideIn"></param>
        /// <param name="bottomDirection"></param>
        public static void AddSlideVerticaly(this Storyboard storyboard, float seconds, double offset, bool slideIn, bool bottomDirection)
        {
            double o = bottomDirection ? -offset : offset;

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(0, 0, 0, slideIn ? o : 0),
                To = new Thickness(0, 0, 0, slideIn ? 0 : o),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }

        /// <summary>
        /// Add horizontaly slide. 
        /// If slideIn = true, it will slide to middle. Else it slide out.
        /// If leftDirection = true, it will slide (to/ from) left. Else from right.
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="seconds"></param>
        /// <param name="offset"></param>
        /// <param name="slideIn"></param>
        /// <param name="bottomDirection"></param>
        public static void AddSlideHorizontaly(this Storyboard storyboard, float seconds, double offset, bool slideIn, bool leftDirection)
        {
            double o = leftDirection ? offset : -offset;

            var animation = new ThicknessAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                From = new Thickness(slideIn ? o : 0, 0, 0, 0),
                To = new Thickness(slideIn ? 0 : o, 0, 0, 0),
                DecelerationRatio = 0.9f
            };

            Storyboard.SetTargetProperty(animation, new PropertyPath("Margin"));
            storyboard.Children.Add(animation);
        }
        */
        #endregion

        #region Fade effects

        /// <summary>
        /// Add fade effect to the storyboard (fade in - appear - true/ fade out - disappear - false)
        /// </summary>
        /// <param name="storyboard"></param>
        /// <param name="FadeIn"></param>
        /// <param name="seconds"></param>
        public static void AddFadeEffect(this Storyboard storyboard, bool FadeIn, float seconds)
        {
            var animation = new DoubleAnimation
            {
                Duration = new Duration(TimeSpan.FromSeconds(seconds)),
                To = FadeIn ? 1 :0,
            };

            if (FadeIn)
                animation.From = 0;

            Storyboard.SetTargetProperty(animation, new PropertyPath("Opacity"));
            storyboard.Children.Add(animation);
        }

        #endregion
    }
}
