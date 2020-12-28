using System;

namespace SimpleTrader.Domain.Exceptions
{
    public class InvalidSymbolException : Exception
    {
        #region Properties

        public string Symbol { get; set; }

        #endregion

        #region Constructors

        public InvalidSymbolException(string symbol)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message) : base(message)
        {
            Symbol = symbol;
        }

        public InvalidSymbolException(string symbol, string message, Exception innerException) : base(message,
            innerException)
        {
            Symbol = symbol;
        }

        #endregion

    }
}
