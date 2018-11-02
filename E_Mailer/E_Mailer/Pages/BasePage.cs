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

        public float AnimationTime { get; set; } = 5;

        #endregion

        #region Constructor

        public BasePage()
        {
            if (StartAnimation != PageAnimation.None)
                this.Visibility = Visibility.Collapsed;

            this.Loaded += PageLoaded;
        }

        #endregion

        private async void PageLoaded(object sender, RoutedEventArgs r)
        {
            if (StartAnimation != PageAnimation.None)
                await AnimateInAsync();
        }

        public async Task RunStartAnimation()
        {
            await this.SlideAndFadeInFromBottomAsync(AnimationTime);
        }

        public async Task AnimateInAsync()
        {
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
