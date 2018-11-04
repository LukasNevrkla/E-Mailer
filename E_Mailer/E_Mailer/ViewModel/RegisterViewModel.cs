using E_Mailer.Security;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Mailer
{
    public class RegisterViewModel : BindableBase
    {
        #region Private properties

        private string email;
        private int dateOfBirth;

        private bool registerIsRunning = false;

        #endregion

        #region Public Properties

        public string Email { get { return email; } set { SetProperty(ref email, value); } }

        public int DateOfBirth { get { return dateOfBirth; } set { SetProperty(ref dateOfBirth, value); } }

        public string WaitText { get; set; } = "Vydržte prosím";

        /// <summary>
        /// A flag indicating if the login command is running
        /// </summary>
        public bool RegisterIsRunning { get { return registerIsRunning; } set { SetProperty(ref registerIsRunning, value); } }

        #endregion

        #region Commands

        public ParameterizedRelayCommand RegisterCommand { get; set; }

        public RelayCommand ToLoginCommand { get; set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public RegisterViewModel()
        {
            // Create commands
            RegisterCommand = new ParameterizedRelayCommand(async (parameter) => await RegisterAsync(parameter));
            ToLoginCommand = new RelayCommand(async () => await ToLoginAsync());
        }

        #endregion

        /// <summary>
        /// Register a new user
        /// </summary>
        /// <param name="parameter">The <see cref="SecureString"/> passed in from the view for the users password</param>
        /// <returns></returns>
        public async Task RegisterAsync(object parameter)
        {
            if (RegisterIsRunning)
                return;
            try
            {
                RegisterIsRunning = true;
                await Task.Delay(3000);

                var email = this.Email;
                var pass = (parameter as IHavePassword).SecurePassword.Unsecure();
                var dateOfBirth = this.DateOfBirth;
            }
            catch { }
            finally { RegisterIsRunning = false; }
        }

        /// <summary>
        /// Takes the user to the login page
        /// </summary>
        /// <returns></returns>
        public async Task ToLoginAsync()
        {
            IoC.Get<AppViewModel>().SideMenuVisibility = true;
            IoC.Get<AppViewModel>().CurrentPage = ApplicationPages.Login;

            await Task.Delay(100);
        }
    }
}
