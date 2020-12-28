using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services.TransactionServices
{
    public interface IBuyStockService
    {
        #region Methods

        Task<Account> BuyStock(Account buyer, string stock, int shares);

        #endregion
    }
}
