using System.Windows.Input;
using SimpleTrader.WPF.Commands;
using SimpleTrader.WPF.State.Authenticators;
using SimpleTrader.WPF.State.Navigators;
using SimpleTrader.WPF.ViewModels.Factories;

namespace SimpleTrader.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields


        private readonly ISimpleTraderViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;
        private readonly IAuthenticator _authenticator;

        #endregion

        #region Constructor

        public MainViewModel(INavigator navigator, ISimpleTraderViewModelFactory viewModelFactory , IAuthenticator authenticator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
            _authenticator = authenticator;

            _navigator.StateChanged += NavigatorOnStateChanged;
            _authenticator.StateChanged += AuthenticatorOnStateChanged;


            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(navigator, _viewModelFactory);
            UpdateCurrentViewModelCommand.Execute(ViewType.Login);
        }

        #endregion

        #region Properties

        public bool IsLoggedIn => _authenticator.IsLoggedIn;
        public ViewModelBase CurrentViewModel => _navigator.CurrentViewModel;
        public ICommand UpdateCurrentViewModelCommand { get;  }

        #endregion

        #region Event Handlers

        private void AuthenticatorOnStateChanged()
        {
            OnPropertyChanged(nameof(IsLoggedIn));
        }

        private void NavigatorOnStateChanged()
        {
            OnPropertyChanged(nameof(CurrentViewModel));
        }

        #endregion
    }
}
