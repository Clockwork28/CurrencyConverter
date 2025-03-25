using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class ExchangeRatesResponse
    {
        public required long  Timestamp { get; set; }
        public required string Base {  get; set; }
        public required Dictionary<string, decimal> Rates { get; set; }
    }
}
