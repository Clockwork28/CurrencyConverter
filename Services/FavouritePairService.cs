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
        }

        public async Task InitAsync()
        {
            try
            {

                var path = Path.Combine(FileSystem.AppDataDirectory, "favourites.json");
                if (!File.Exists(path))
                {
                    using var stream = await FileSystem.OpenAppPackageFileAsync("favourites.json");
                    using FileStream outputStream = File.OpenWrite(path);
                    await stream.CopyToAsync(outputStream);
                    await outputStream.FlushAsync();
                }
                var favourites = await File.ReadAllTextAsync(path);
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
            var path = Path.Combine(FileSystem.AppDataDirectory, "favourites.json");
            File.WriteAllText(path, json);
        }
    }
}
