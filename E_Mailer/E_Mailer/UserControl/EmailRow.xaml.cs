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
    /// Interakční logika pro EmailRow.xaml
    /// </summary>
    public partial class EmailRow : UserControl
    {
        public EmailRow()
        {
            InitializeComponent();

            MessagePreview.SizeChanged += SizeChanged;
        }


        private void SizeChanged(object sender, SizeChangedEventArgs e)
        {
             //new TransparentWebBrowserWindow(bTarget);
        }
    }
}
