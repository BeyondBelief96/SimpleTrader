using System;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.State.Navigators
{
    public enum ViewType
    {
        Home,
        Portfolio,
        Buy,
        Sell,
        Login
    }

    public class Navigator : INavigator
    {
        #region Events

        public event Action StateChanged;

        #endregion

        #region Fields

        private ViewModelBase _currentViewModel;

        #endregion

        #region Constrcutors

        public Navigator()
        {
        }

        #endregion

        #region Properties

        public ViewModelBase CurrentViewModel
        {
            get
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                StateChanged?.Invoke();
            }
        }

        #endregion
    }
}
