﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
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
    /// Interakční logika pro LoginPage.xaml
    /// </summary>
    public partial class LoginPage : BasePage<LoginViewModel>, IHavePassword
    {
        public LoginPage()
        {
            InitializeComponent();
            SetButton();
        }

        #region ButtonHelpers

        //To enable login button only if are there necessary datas
        private void password_PasswordChanged(object sender, RoutedEventArgs e) => SetButton();
        private void email_TextChanged(object sender, TextChangedEventArgs e) => SetButton();

        void SetButton()
        {
            if (PasswordBoxText == null)
                return;

            bool enable = email.Text.Length > 0 && PasswordBoxText.Password.Length > 0;
            SignButton.IsEnabled = enable;
        }

        #endregion

        public SecureString SecurePassword => PasswordBoxText.SecurePassword;
    }
}
