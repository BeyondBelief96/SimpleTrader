namespace SimpleTrader.WPF.ViewModels
{
    public class AssetViewModel
    {
        #region Constructors

        public AssetViewModel(string symbol, int shares)
        {
            Symbol = symbol;
            Shares = shares;
        }

        #endregion

        #region Properties

        public string Symbol { get; }
        public int Shares { get; }

        #endregion
    }
}
