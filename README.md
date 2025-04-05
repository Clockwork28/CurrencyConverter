# Currency Converter App 💱

Blazor Hybrid currency converter app built with .NET MAUI.  
Displays live exchange rates and allows users to convert between currencies with ease.  
Supports favourite currency pairs and works cross-platform.

---

## 🚀 Features

- 🌍 **Live currency exchange rates** using [Open Exchange Rates](https://openexchangerates.org/)
- 🔄 Real-time currency conversion
- ❤️ Add & remove favourite currency pairs
- 📱 Mobile-first UI layout (designed with mobile in mind)
- 📂 Categorized currency selection (Fiat / Crypto / Other)
- 🧠 Data caching and offline-safe initialization
- 🧭 Navigation with hamburger menu and About page
- ☁️ Configuration from `appSettings.json`

---

## 🛠️ Technologies Used

- [.NET 8](https://dotnet.microsoft.com/)
- [Blazor Hybrid](https://learn.microsoft.com/en-us/dotnet/maui/blazor/)
- .NET MAUI
- C#
- Bootstrap 5

---

## 📦 Setup

> ⚠️ Requires Visual Studio 2022+ with .NET MAUI workload installed.

1. Clone this repo
2. Place your `appSettings.json` in `Resources/Raw` or use the template:
```json
{
  "ApiKey": "your_open_exchange_rates_api_key"
}
```
3. Set platform target (Android recommended)
4. Run the app

---

## 📱 Deployment

To install on Android:

- Switch to `Release` mode in Visual Studio
- Build & deploy to connected device or emulator
- Or generate `.apk` via **Publish > Android App (APK)**

---

## 🔒 Security Note

The API key is currently read from a local JSON file.  
**Do not publish to production with the key exposed in client files.**  
In production, use a secure backend or proxy to protect API credentials.

---

## 🧪 Roadmap / Work in Progress

- [x] Currency conversion core
- [x] Favourites system
- [x] Currency grouping in dropdowns
- [x] Hamburger menu & navigation
- [ ] Pull-to-refresh support (WIP)
- [ ] Flag backgrounds in dropdowns
- [ ] Responsive layout polish
- [ ] Conversion history & offline mode
- [ ] Dark mode toggle

---

## ✍️ Author

Krzysztof Sumera  
[github.com/clockwork28](https://github.com/clockwork28)

---

## 📄 License

MIT – use freely, but at your own risk 😉
