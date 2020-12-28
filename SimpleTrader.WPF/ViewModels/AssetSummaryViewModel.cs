using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using SimpleTrader.WPF.State.Assets;

namespace SimpleTrader.WPF.ViewModels
{
    public class AssetSummaryViewModel : ViewModelBase
    {
        #region Fields

        private readonly AssetStore _assetStore;
        private readonly ObservableCollection<AssetViewModel> _assets;

        #endregion

        #region Constructors

        public AssetSummaryViewModel(AssetStore assetStore)
        {
            _assetStore = assetStore;
            _assets = new ObservableCollection<AssetViewModel>();
            _assetStore.StateChanged += AssetStoreOnStateChanged;
        }

        private void AssetStoreOnStateChanged()
        {
            OnPropertyChanged(nameof(AccountBalance));
            ResetAssets();
        }



        #endregion

        #region Properties

        public double AccountBalance => _assetStore.AccountBalance;

        public IEnumerable<AssetViewModel> Assets => _assets;

        #endregion

        #region Methods

        private void ResetAssets()
        {
            IEnumerable<AssetViewModel> assetViewModels = _assetStore.AssetTransactions
                .GroupBy(t => t.Asset.Symbol)
                .Select(g => new AssetViewModel(g.Key, g.Sum(a => a.IsPurchase ? a.Shares : -a.Shares)))
                .Where(a => a.Shares > 0);

            _assets.Clear();

            foreach (var asset in assetViewModels)
            {
                _assets.Add(asset);
            }
        }

        #endregion
    }
}
