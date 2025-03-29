using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class CurrencyCategories
    {
            public static List<string> TopFiatCurrencies = new List<string>
        {
            "USD", // Dolar amerykański
            "EUR", // Euro
            "JPY", // Jen japoński
            "GBP", // Funt szterling
            "AUD", // Dolar australijski
            "CAD", // Dolar kanadyjski
            "CHF", // Frank szwajcarski
            "CNY", // Juan chiński
            "HKD", // Dolar hongkoński
            "NZD", // Dolar nowozelandzki
            "SEK", // Korona szwedzka
            "KRW", // Won południowokoreański
            "SGD", // Dolar singapurski
            "NOK", // Korona norweska
            "MXN", // Peso meksykańskie
            "INR", // Rupia indyjska
            "RUB", // Rubel rosyjski
            "ZAR", // Rand południowoafrykański
            "TRY", // Lira turecka
            "BRL", // Real brazylijski
            "TWD", // Nowy dolar tajwański
            "DKK", // Korona duńska
            "PLN", // Polski złoty
            "THB", // Baht tajski
            "IDR", // Rupia indonezyjska
            "HUF", // Forint węgierski
            "CZK", // Korona czeska
            "ILS", // Nowy szekel izraelski
            "CLP", // Peso chilijskie
            "PHP", // Peso filipińskie
            "AED", // Dirham Zjednoczonych Emiratów Arabskich
            "COP", // Peso kolumbijskie
            "SAR", // Rial saudyjski
            "MYR", // Ringgit malezyjski
            "RON"  // Lej rumuński
        };
            public static List<string> TopCryptocurrencies = new List<string>
        {
            "BTC",  // Bitcoin
            "ETH",  // Ethereum
            "BNB",  // Binance Coin
            "XRP",  // XRP (Ripple)
            "ADA",  // Cardano
            "SOL",  // Solana
            "DOGE", // Dogecoin
            "DOT",  // Polkadot
            "MATIC",// Polygon
            "LTC"   // Litecoin
        };
    }
}
