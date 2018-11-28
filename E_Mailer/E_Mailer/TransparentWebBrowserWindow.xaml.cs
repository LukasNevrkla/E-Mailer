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
using System.Windows.Shapes;

namespace E_Mailer
{
    /// <summary>
    /// Interakční logika pro TransparentWebBrowserWindow.xaml
    /// </summary>
    public partial class TransparentWebBrowserWindow : Window
    {
        FrameworkElement t;

        public TransparentWebBrowserWindow(FrameworkElement target)//, Control child)
        {
            InitializeComponent();

            t = target;
            //wfh.Child = child;

            //Owner =  //Window.GetWindow(t);
            Owner = IoC.Get<AppViewModel>().MainWindow;

            Owner.LocationChanged += new EventHandler(PositionAndResize);
            t.LayoutUpdated += new EventHandler(PositionAndResize);
            //PositionAndResize(null, null);

            if (Owner.IsVisible)
                Show();
            else
                Owner.IsVisibleChanged += delegate
                {
                    if (Owner.IsVisible)
                        Show();
                };
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            Owner.LocationChanged -= new EventHandler(PositionAndResize);
            t.LayoutUpdated -= new EventHandler(PositionAndResize);
        }

        void PositionAndResize(object sender, EventArgs e)
        {
            Point p = t.PointToScreen(new Point());
            Left = p.X;
            Top = p.Y;

            Height = t.ActualHeight;
            Width = t.ActualWidth;
        }
    }
}
