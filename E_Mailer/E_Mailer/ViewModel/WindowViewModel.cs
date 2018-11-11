using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;


namespace E_Mailer
{
    class WindowViewModel : BindableBase
    {
        #region Private properties

        private Window window;

        //private ApplicationPages currentPage = ApplicationPages.Login;

        #region Window properties

        private int windowCornerRadius = 30;

        #endregion

        #endregion

        #region Public properties

       // public ApplicationPages CurrentPage { get { return currentPage; } set { SetProperty(ref currentPage, value); } }

        #region Window properties

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(windowCornerRadius); } }

        public CornerRadius MaskCornerRadius { get { return new CornerRadius( windowCornerRadius); } } //CornerRadius(0, windowCornerRadius, 0,0);

        #endregion

        #endregion

        #region Commands

        public RelayCommand MinimaliseCommand { get; set; }
        public RelayCommand MaximaliseCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="_window"></param>
        public WindowViewModel(Window _window)
        {
            window = _window;

            //RaisePropertyChanged("WindowCornerRadius");

            MinimaliseCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximaliseCommand = new RelayCommand(() =>
            {
                if (window.WindowState == WindowState.Maximized)
                    window.WindowState = WindowState.Normal;

                else
                    window.WindowState = WindowState.Maximized;
            });
            CloseCommand = new RelayCommand(() => window.Close());
        }

        #endregion
    }
} 