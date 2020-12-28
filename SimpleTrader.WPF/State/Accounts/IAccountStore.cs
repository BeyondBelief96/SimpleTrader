using System;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.WPF.State.Accounts
{
    public interface IAccountStore
    {
        #region Properties

        Account CurrentAccount { get; set; }

        event Action StateChanged;

        #endregion
    }
}
