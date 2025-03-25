using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class FavouritePair
    {
        public required string In { get; set; }
        public required string Out { get; set; }

        public override string ToString()
        {
            return $"{In} -> {Out}";
        }
    }
}
