using System.Windows;
using System.Windows.Media;
using Prism.Mvvm;


namespace E_Mailer
{
    class WindowViewModel : BindableBase
    {
        #region Private properties

        /// <summary>
        /// Window controled by this view model.
        /// </summary>
        private Window window;

        private ApplicationPages currentPage = ApplicationPages.Login;

        //private Color backgroundColors

        #region Window Margin and Borers

        private int resizeBorder = 6;

        /// <summary>
        /// Outer margit to use shadows.
        /// </summary>
        private int outerMarginSize = 10;

        /// <summary>
        /// Inner margin.
        /// </summary>
        private int innerMarginSize = 5;

        /// <summary>
        /// Radius of edges of the window.
        /// </summary>
        private int windowRadius = 20;

        private int captionHeight = 42;

        #endregion

        #endregion

        #region Public properties

        public ApplicationPages CurrentPage { get { return currentPage; } set { SetProperty(ref currentPage, value); } }

        /// <summary>
        /// Border around the window.
        /// </summary>
        public int ResizeBorder
        {
            get { return resizeBorder; }
            set {SetProperty(ref resizeBorder, value); }
        }

        /// <summary>
        /// Margin around the window to enable drop shadow effect (when window is maximalized it is 0).
        /// </summary>
        public int OuterMarginSize
        {
            get
            {
                return outerMarginSize;//window.WindowState == WindowState.Maximized ? 0 : outerMarginSize;
            }

            set
            {
                SetProperty(ref outerMarginSize, value);
            }
        }

        public int InnerMarginSize
        {
            get
            {
                return innerMarginSize;
            }

            set
            {
                SetProperty(ref innerMarginSize, value);
            }
        }

        public Thickness ResizeBorderThickness { get { return new Thickness(ResizeBorder + outerMarginSize + InnerMarginSize); } }

        public Thickness OuterMarginThickness { get { return new Thickness( OuterMarginSize); } }

        /// <summary>
        /// Radius of edges of the window (when window is maximalized it is 0).
        /// </summary>
        public int WindowRadius
        {
            get
            {
                return windowRadius;// window.WindowState == WindowState.Maximized ? 0 : windowRadius;
            }

            set
            {
                SetProperty(ref windowRadius, value);
            }
        }

        public CornerRadius WindowCornerRadius { get { return new CornerRadius(WindowRadius); } }

        public int CaptionHeight
        {
            get { return captionHeight; }
            set { SetProperty(ref captionHeight, value); }
        }

        public GridLength TitleHeightGridLength { get { return new GridLength(CaptionHeight+ resizeBorder); } }

        #endregion

        #region Commands

        public RelayCommand MinimaliseCommand { get; set; }
        public RelayCommand MaximaliseCommand { get; set; }
        public RelayCommand CloseCommand { get; set; }
        public RelayCommand MenuCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor.
        /// </summary>
        /// <param name="_window"></param>
        public WindowViewModel(Window _window)
        {
            window = _window;

            window.StateChanged += (sender, e) =>
            {
                RaisePropertyChanged("ResizeBorderThickness");
                RaisePropertyChanged("OuterMarginSize");
                RaisePropertyChanged("OuterMarginThickness");
                RaisePropertyChanged("WindowRadius");
                RaisePropertyChanged("WindowCornerRadius");
            };

            MinimaliseCommand = new RelayCommand(() => window.WindowState = WindowState.Minimized);
            MaximaliseCommand = new RelayCommand(() =>
            {
                if (window.WindowState == WindowState.Maximized)
                    window.WindowState = WindowState.Normal;

                else
                    window.WindowState = WindowState.Maximized;
            });

            CloseCommand = new RelayCommand(() => window.Close());
            MenuCommand = new RelayCommand(() =>
            {
                //(App.Current as App).ChangeTheme(Theme.Black);
            });
        }

        #endregion
    }
} 