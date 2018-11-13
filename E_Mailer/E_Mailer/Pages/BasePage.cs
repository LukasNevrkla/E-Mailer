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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using E_Mailer.Animations;
using Prism.Mvvm;

namespace E_Mailer
{
    public class BasePage : Page
    {
        #region Public properties

        public PageAnimation StartAnimation { get; set; } = PageAnimation.SlideAndFade;
        public PageAnimation EndAnimation { get; set; } = PageAnimation.SlideAndFade;

        public SlidePositions StartFromAnimation { get; set; } = SlidePositions.Bottom;
        public SlidePositions StartToAnimation { get; set; } = SlidePositions.Center;
        public SlidePositions EndFromAnimation { get; set; } = SlidePositions.Center;
        public SlidePositions EndToAnimation { get; set; } = SlidePositions.Right;

        public double StartDistance { get; set; } = 0;
        public double EndDistance { get; set; } = 0;

        public float AnimationTime { get; set; } = 1;

        public bool ShouldAnimateOut { get; set; }

        #endregion

        #region Constructor

        public BasePage()
        {
            if (StartAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += PageLoaded;
        }

        #endregion

        #region Page loaded/unloaded

        private async void PageLoaded(object sender, RoutedEventArgs r)
        {
            // If is setup to animate out
            if (ShouldAnimateOut)
                await RunEndAnimationAsync();
            else
                await RunStartAnimationAsync();
        }

        public async Task RunStartAnimationAsync()
        {
            if (StartAnimation == PageAnimation.None)
                return;

            switch (StartAnimation)
            {
                case PageAnimation.SlideAndFade:
                    {
                        if (StartDistance == 0)
                            StartDistance = this.WindowHeight;

                        await this.PageBasicsAnimation(AnimationTime, StartFromAnimation, StartToAnimation, true, StartDistance);
                        break;
                    }
            }
        }

        public async Task RunEndAnimationAsync()
        {
            if (EndAnimation == PageAnimation.None)
                return;

            switch (StartAnimation)
            {
                case PageAnimation.SlideAndFade:
                    {
                        if (EndDistance == 0)
                            EndDistance = this.WindowWidth;

                        await this.PageBasicsAnimation(AnimationTime, EndFromAnimation, EndToAnimation, false, EndDistance);
                        break;
                    }
            }
        }

        #endregion
    }

    /// <summary>
    /// A base page with added ViewModel support
    /// </summary>
    public class BasePage<VM> : BasePage
        where VM : BindableBase, new()
    {
        #region Private Properties

        private VM viewModel;

        #endregion

        #region Public Properties

        /// <summary>
        /// The view model associated with this page
        /// </summary>
        public VM ViewModel
        {
            get { return viewModel; }
            set
            {
                if (viewModel == value)
                    return;

                viewModel = value;

                this.DataContext = viewModel;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public BasePage() : base()
        {
            this.DataContext = new VM();
        }

        #endregion
    }
}
