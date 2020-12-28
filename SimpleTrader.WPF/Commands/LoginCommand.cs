using System;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class LoginCommand : ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fields

        private readonly IAuthenticator _authenticator;
        private readonly LoginViewModel _loginViewModel;
        private readonly IRenavigator _renavigator;

        #endregion

        #region Constructors

        public LoginCommand(IAuthenticator authenticator, LoginViewModel loginViewModel, IRenavigator renavigator)
        {
            _authenticator = authenticator;
            _loginViewModel = loginViewModel;
            _renavigator = renavigator;
        }

        #endregion

        #region Methods

        public async void Execute(object parameter)
        {
            if (parameter != null)
            {
                bool success = await _authenticator.Login(_loginViewModel.Username, parameter.ToString());

                if (success)
                {
                    _renavigator.Renavigate();
                }
            }
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        #endregion

        
    }
}
