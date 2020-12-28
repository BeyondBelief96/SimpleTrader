using System;
using System.Collections.Generic;
using SimpleTrader.Domain.Models;
using SimpleTrader.WPF.State.Accounts;

namespace SimpleTrader.WPF.State.Assets
{
    public class AssetStore
    {
        #region Events

        public event Action StateChanged;

        #endregion

        #region Fields

        private readonly IAccountStore _accountStore;

        #endregion

        #region Constructors

        public AssetStore(IAccountStore accountStore)
        {
            _accountStore = accountStore;
            _accountStore.StateChanged += AccountStoreOnStateChanged;
        }

        private void AccountStoreOnStateChanged()
        {
            StateChanged?.Invoke();
        }

        #endregion

        #region Properties

        public double AccountBalance => _accountStore.CurrentAccount?.Balance ?? 0;

        public IEnumerable<AssetTransaction> AssetTransactions =>
            _accountStore.CurrentAccount?.AssetTransactions ?? new List<AssetTransaction>();

        #endregion

    }
}
