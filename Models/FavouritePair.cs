using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Currency_Converter.Models
{
    public class FavouritePair
    {
        public required string From { get; set; }
        public required string To { get; set; }

        public override string ToString()
        {
            return $"{From} -> {To}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(From, To);
        }

        public override bool Equals(object? obj)
        {
            if (obj is FavouritePair other)
            {
                if (From == other.From && To == other.To)
                    return true;
            }
            return false;
        }
    }
}
