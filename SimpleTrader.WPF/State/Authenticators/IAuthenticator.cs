using System;
using System.Threading.Tasks;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.AuthenticationServices;

namespace SimpleTrader.WPF.State.Authenticators
{
    public interface IAuthenticator
    {
        #region Events

        event Action StateChanged;

        #endregion

        #region Properties

        Account CurrentAccount { get; }

        bool IsLoggedIn { get; }

        #endregion

        #region Methods

        Task<RegistrationResult> Register(string email, string username, string password, string confirmPassword);
        Task<bool> Login(string username, string password);
        void Logout();
        

        #endregion
    }
}
