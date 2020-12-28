namespace SimpleTrader.WPF.ViewModels
{
    public class HomeViewModel : ViewModelBase
    {

        #region Constructor

        public HomeViewModel(MajorIndexListingViewModel majorIndexListingViewModel, AssetSummaryViewModel assetSummaryViewModel)
        {
            MajorIndexListingViewModel = majorIndexListingViewModel;
            AssetSummaryViewModel = assetSummaryViewModel;
        }

        #endregion

        #region Properties

        public MajorIndexListingViewModel MajorIndexListingViewModel { get; }

        public AssetSummaryViewModel AssetSummaryViewModel { get; }

        #endregion


    }
}
