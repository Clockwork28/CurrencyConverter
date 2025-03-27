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
        private readonly ILogger<FavouritePairService> _logger;
        public List<FavouritePair> _favPairs = new();


        public FavouritePairService(ILogger<FavouritePairService> logger)
        {
            _logger = logger;

            try
            {
                var favouritesPath = Path.Combine(Directory.GetCurrentDirectory(), "favourites.json");
                if (File.Exists(favouritesPath))
                {
                    var favourites = File.ReadAllText(favouritesPath);
                    _logger.LogInformation($"Zawartość favourites.json: {favourites}");
                    if (!string.IsNullOrEmpty(favourites))
                    {
                        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                        _favPairs = JsonSerializer.Deserialize<List<FavouritePair>>(favourites, options) ?? new();
                        _logger.LogInformation($"Wczytano {_favPairs.Count} par:");
                        foreach (var pair in _favPairs)
                        {
                            _logger.LogInformation($" - {pair}");
                        }
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
            await Task.Yield();
            if (!_favPairs.Contains(pair))
            {
                _favPairs.Add(pair);
                SaveJson();
            }
            
            _logger.LogInformation("Dodano 1 parę");
            _logger.LogInformation($"Wczytano {_favPairs.Count} par:");
            foreach (var p in _favPairs)
            {
                _logger.LogInformation($" - {p}");
            }
        }

        public async Task RemoveFavPair(FavouritePair pair)
        {
            await Task.Yield();
            _favPairs.Remove(pair);
            SaveJson();
            _logger.LogInformation("Usunięto 1 parę");
            _logger.LogInformation($"Wczytano {_favPairs.Count} par:");
            foreach (var p in _favPairs)
            {
                _logger.LogInformation($" - {p}");
            }
        }

        private void SaveJson()
        {
            var json = JsonSerializer.Serialize(_favPairs, new JsonSerializerOptions { WriteIndented = true });
            var favouritesPath = Path.Combine(Directory.GetCurrentDirectory(), "favourites.json");
            File.WriteAllText(favouritesPath, json);
        }
    }
}
