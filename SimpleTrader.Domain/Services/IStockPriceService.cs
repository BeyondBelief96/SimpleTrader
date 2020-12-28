using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IStockPriceService
    {
        #region Methods

        Task<double> GetPrice(string symbol);

        #endregion
    }
}
