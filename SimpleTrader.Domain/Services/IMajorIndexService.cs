using System.Threading.Tasks;
using SimpleTrader.Domain.Models;

namespace SimpleTrader.Domain.Services
{
    public interface IMajorIndexService
    {
        #region Methods

        Task<MajorIndex> GetMajorIndex(MajorIndexType indexType);

        #endregion
    }
}
