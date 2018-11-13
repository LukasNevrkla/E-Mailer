using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using E_Mailer.Security;
using System.Windows;

namespace E_Mailer
{
    public class LoginViewModel : BindableBase
    {
        #region Private properties

        private string email;
        private bool loginIsRunning = false;

        #endregion

        #region Public Properties

        /// <summary>
        /// The email of the user
        /// </summary>
        public string Email { get { return email; } set { SetProperty(ref email, value); } }

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool LoginIsRunning { get { return loginIsRunning; } set { SetProperty(ref loginIsRunning, value); } }

        #endregion

        #region Commands

        /// <summary>
        /// The command to login
        /// </summary>
        public ParameterizedRelayCommand LoginCommand { get; set; }

        /// <summary>
        /// The command to register for a new account
        /// </summary>
        public RelayCommand RegisterCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoginViewModel()
        {
            // Create commands
            LoginCommand = new ParameterizedRelayCommand(async (parameter) => await LoginAsync(parameter));
            RegisterCommand = new RelayCommand(async () => await RegisterAsync());
        }

        #endregion

        /// <summary>
        /// Attempts to log the user in
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task LoginAsync(object parameter)
        {/*
            await RunCommandAsync.RunCommand(() => this.LoginIsRunning, async () =>
            {
                await Task.Delay(2000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            });*/
            
            if (LoginIsRunning)
                return;
            try
            {
                LoginIsRunning = true;
                await Task.Delay(3000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
            }
            catch { }
            finally { LoginIsRunning = false; }
        }

        /// <summary>
        /// Takes the user to the register page
        /// </summary>
        /// <returns></returns>
        public async Task RegisterAsync()
        {
            IoC.Get<AppViewModel>().SideMenuVisibility = true;
            IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Register;

            await Task.Delay(100);
        }
    }
}
