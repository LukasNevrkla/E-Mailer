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

namespace E_Mailer
{
    /// <summary>
    /// Interakční logika pro MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public AppViewModel appViewModel => new AppViewModel();

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = new WindowViewModel(this);
        }

        #region Window movement

        private bool x = false;
        private void Button_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            if(x==true)
            {
                try
                { DragMove(); }
                catch { }

                x = false;
            }
        }

        private void Grid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            x = true;
        }

        #endregion
    }
}
