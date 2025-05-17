# Weather API (JSON Version)

This ASP.NET Core Web API project fetches current weather data from the OpenWeatherMap API and returns responses in **JSON format**.

## Features

- Deserializes JSON weather responses
- Uses custom models to represent weather data
- Supports query by city name
- Global exception handling middleware

## 🔐 Configuration

Create or update `appsettings.json`:

```json
{
  "OpenWeather": {
    "ApiKey": "your_openweather_api_key"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  }
}
