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

        public PageAnimation StartAnimation { get; set; } = PageAnimation.SlideAndFadeInFromBottom;
        public PageAnimation EndAnimation { get; set; } = PageAnimation.SlideAndFadeOutToBottom;

        public float AnimationTime { get; set; } = 1f;

        #endregion

        public BasePage()
        {
            if (StartAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += PageLoaded;
        }

        private async void PageLoaded(object sender, RoutedEventArgs r)
        {
            await AnimateInAsync();
        }

        public async Task AnimateInAsync()
        {
            // Make sure we have something to do
            if (StartAnimation == PageAnimation.None)
                return;

            switch (StartAnimation)
            {
                case PageAnimation.SlideAndFadeInFromBottom:
                    // Start the animation
                    await this.SlideAndFadeInFromBottomAsync(AnimationTime);

                    break;
            }
        }

        public async Task AnimateOutAsync()
        {
            // Make sure we have something to do
            if (EndAnimation == PageAnimation.None)
                return;

            switch (EndAnimation)
            {
                case PageAnimation.SlideAndFadeOutToBottom:

                    // Start the animation
                    await this.SlideAndFadeOutToBottomAsync(AnimationTime);

                    break;
            }
        }
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
