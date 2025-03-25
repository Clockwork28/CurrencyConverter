using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Currency_Converter.Models;
using Microsoft.Extensions.Logging;

namespace Currency_Converter.Services
{
    public class FavouritePairService
    {
        private FavouritePair? _favPair;
        private readonly ILogger<FavouritePairService> _logger;
        private List<FavouritePair> _favPairs = new();


        public FavouritePairService(ILogger<FavouritePairService> logger)
        {
            _logger = logger;

            try
            {
                var favouritesPath = Path.Combine(Directory.GetCurrentDirectory(), "favourites.json");
                if (File.Exists(favouritesPath))
                {
                    var favourites = File.ReadAllText(favouritesPath);
                    if (!string.IsNullOrEmpty(favourites))
                    {
                        _favPairs = JsonSerializer.Deserialize<List<FavouritePair>>(favourites) ?? new();
                        Console.WriteLine(_favPairs.FirstOrDefault());
                    }
                    
                }

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error reading favourites.json: {ex.Message}");
                throw;
            }
        }

        public async Task AddFavPair(FavouritePair pair)
        {

        }

        public async Task RemoveFavPair(FavouritePair pair)
        {

        }
    }
}
