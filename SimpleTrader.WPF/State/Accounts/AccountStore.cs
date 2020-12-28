using System;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.State.Accounts
{
    public class AccountStore : IAccountStore
    {
        #region Events

        public event Action StateChanged;

        #endregion

        #region Fields

        private Account _currentAccount;

        #endregion

        #region Properties

        public Account CurrentAccount
        {
            get
            {
                return _currentAccount;
            }
            set
            {
                _currentAccount = value;
                if (_currentAccount != value)
                {
                    StateChanged?.Invoke();
                }
                
            }
        }

        #endregion

    }
}
