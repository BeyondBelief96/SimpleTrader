using System;
using System.Threading.Tasks;
using System.Windows;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;
using SimpleTrader.WPF.State.Accounts;

namespace SimpleTrader.WPF.State.Authenticators
{
    public class Authenticator : IAuthenticator
    {
        #region Events

        public event Action StateChanged;

        #endregion

        #region Fields

        private readonly IAuthenticationService _authenticationService;
        private readonly IAccountStore _accountStore;

        #endregion

        #region Constructors

        public Authenticator(IAuthenticationService authenticationService, IAccountStore accountStore)
        {
            _authenticationService = authenticationService;
            _accountStore = accountStore;
        }

        #endregion

        #region Properties

        public Account CurrentAccount
        {
            get
            {
                return _accountStore.CurrentAccount;
            }
            private set
            {
                _accountStore.CurrentAccount = value;
                StateChanged?.Invoke();

            }
        }
        public bool IsLoggedIn => CurrentAccount != null;

        #endregion

        #region Methods

        public async Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword)
        {
            return await _authenticationService.Register(email, username, password, confirmPassword);
        }

        public async Task<bool> Login(string username, string password)
        {
            bool loginSuccess = true;

            try
            {
                CurrentAccount = await _authenticationService.Login(username, password);
            }
            catch (Exception e)
            {
                loginSuccess = false;
                MessageBox.Show(e.Message);
            }

            return loginSuccess;
        }

        public void Logout()
        {
            CurrentAccount = null;
        }

        #endregion

    }
}
