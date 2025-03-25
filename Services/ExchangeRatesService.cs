using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Currency_Converter.Models;
using Microsoft.Extensions.Logging;

namespace Currency_Converter.Services
{
    /// <summary>
    /// Service responsible for fetching currency rates and converting currencies.
    /// </summary>
    public class ExchangeRatesService
    {
        private readonly string? _apiKey;
        private readonly ILogger<ExchangeRatesService> _logger;
        private ExchangeRatesResponse? _rates;
        
        public ExchangeRatesService(ILogger<ExchangeRatesService> logger)
        {
            _logger = logger;

            // API requires a key from appSettings.json
            try
            {
                var appSettingsPath = Path.Combine(Directory.GetCurrentDirectory(), "appSettings.json");
                if (File.Exists(appSettingsPath))
                {
                    var appSettings = File.ReadAllText(appSettingsPath);
                    if (!string.IsNullOrEmpty(appSettings))
                    {
                        _apiKey = JsonSerializer.Deserialize<AppSettings>(appSettings)?.ApiKey;

                    }
                }

                if (string.IsNullOrEmpty(_apiKey))
                {
                    throw new InvalidOperationException("API key is missing or null.");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error reading API Key: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Fetches latest currency exchange rates from the API.
        /// </summary>
        public async Task<ExchangeRatesResponse?> GetRates()
        {
            using var client = new HttpClient();
            try
            {
                var response = await client.GetAsync($"https://openexchangerates.org/api/latest.json?app_id={_apiKey}");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                _rates = JsonSerializer.Deserialize<ExchangeRatesResponse>(content, options);
                return _rates;
         


            }
            catch (HttpRequestException httpEx)
            {
                _logger.LogError($"HTTP Error: {httpEx.Message}");
                return null;
            }
            catch (JsonException jsonEx)
            {
                _logger.LogError($"JSON Error: {jsonEx.Message}");
                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                return null;
            }
        }


        /// <summary>
        /// Converts an amount from one currency to another.
        /// </summary>
        public decimal Convert(decimal amount, string inCode, string outCode)
        {
            if (_rates == null)
            {
                throw new InvalidOperationException("Rates have not been downloaded. Call 'GetRates()' first.");
            }
            var invalidCurrencies = new List<string>();
            if (!_rates.Rates.ContainsKey(inCode))
            {
                invalidCurrencies.Add(outCode);
            }

            if (!_rates.Rates.ContainsKey(outCode))
            {
                invalidCurrencies.Add(outCode);
            }

            if (invalidCurrencies.Count > 0)
            {
                throw new ArgumentException($"Invalid currency codes: {string.Join(", ", invalidCurrencies)}.");
            }
            try
            {
                // Convert first to USD because the API always uses USD as the base currency
                if (inCode != "USD")
                {
                    amount /= _rates.Rates[inCode];
                }

                return Math.Round(amount * _rates.Rates[outCode], 2, MidpointRounding.AwayFromZero);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Unexpected error: {ex.Message}");
                throw;
            }
        }
    }
}
