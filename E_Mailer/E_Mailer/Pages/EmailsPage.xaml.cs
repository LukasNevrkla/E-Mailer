﻿using System;
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
    public partial class EmailsPage : BasePage <EmailsViewModel>
    {
        public EmailsPage()
        {
            InitializeComponent();
        }

        private void ListViewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            EmailsViewModel vm = this.DataContext as EmailsViewModel;
            vm.SelectedChangedCommand.Execute(null);
        }
    }
}
