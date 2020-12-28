using System;
using System.Windows;
using System.Windows.Input;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services.TransactionServices;
using SimpleTrader.WPF.State.Accounts;
using SimpleTrader.WPF.ViewModels;

namespace SimpleTrader.WPF.Commands
{
    public class BuyStockCommand : ICommand
    {
        #region Fields

        private readonly BuyViewModel _buyViewModel;
        private readonly IBuyStockService _buyStockService;
        private readonly IAccountStore _accountStore;

        #endregion


        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Constructors

        public BuyStockCommand(BuyViewModel buyViewModel, IBuyStockService buyStockService, IAccountStore accountStore)
        {
            _buyViewModel = buyViewModel;
            _buyStockService = buyStockService;
            _accountStore = accountStore;
        }

        #endregion

        #region Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Account account = await _buyStockService.BuyStock(_accountStore.CurrentAccount,
                    _buyViewModel.Symbol,
                    _buyViewModel.SharesToBuy);

                _accountStore.CurrentAccount = account;

                MessageBox.Show($"You purchased {_buyViewModel.SharesToBuy} shares of {_buyViewModel.Symbol}");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        #endregion



    }
}
