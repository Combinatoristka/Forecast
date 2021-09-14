using System;
namespace Study
{
    public class Forecast
    {
        private DateTime date;
        private int temperatureMax = 20;
        private int temperatureMin;
        private int pressure = 740;
        private int humidity = 50;
        private int windStrength = 2;
        private EDirection windDirection = EDirection.North;
        private EVariantsPrecipitation precipitation;

        public Forecast(DateTime date, int temperatureMax, int temperatureMin, int pressure, int humidity, int windStrength, EDirection windDirection, EVariantsPrecipitation precipitation)
        {
            this.date = date;
            SetTemperature(temperatureMax, temperatureMin);
            SetPressure(pressure);
            SetHumidity(humidity);
            SetWind(windStrength, windDirection);
            SetPrecipitation(precipitation);
        }
        public void SetTemperature(int tMax, int tMin)
        {
            if (50 >= tMax && tMax >= -267)
                temperatureMax = tMax;
            else
                Console.WriteLine($"The maximum temperature value is out of range (-267) - 50C. Maximum temperature is set {temperatureMax}.");
            if (tMin <= this.temperatureMax) //min thunt
                this.temperatureMin = tMin;
            else
            {
                this.temperatureMin = temperatureMax - 5;
                Console.WriteLine($"The minimum temperature exceeds the maximum. The minimum temperature is set {temperatureMin}.");
            }

        }
        public void SetPressure(int pressure)
        {
            if (750 > pressure && pressure > 735)
                this.pressure = pressure;
            else
                Console.WriteLine($"The pressure value is out of range 735 - 750mmHg. Pressure is set = {this.pressure}mmHg.");
        }
        public void SetHumidity(int humidity)
        {
            if (100 >= humidity && humidity >= 0)
                this.humidity = humidity;
            else
                Console.WriteLine($"The humidity value is out of range 0 - 100%. Humidity is set {this.humidity}%");
        }
        public void SetWind(int strength, EDirection direction)
        {
            if (67 >= strength && strength >= 0)
                this.windStrength = strength;
            else
                Console.WriteLine($"The wind strength value is out of range 0 - 67 m/s. Wind strength {this.windStrength}m/s.");
            this.windDirection = direction;
        }
        public void SetPrecipitation(EVariantsPrecipitation precipitat)
        {
            this.precipitation = precipitat;
        }


        public void GetForecast()
        {
            Console.WriteLine($"Date: {date.ToLongDateString()}");
            Console.WriteLine($"Temperature: max = {temperatureMax} Degrees Celsius, min = {temperatureMin} Degrees Celsius");
            Console.WriteLine($"Pressure: {pressure} mmHg");
            Console.WriteLine($"Humidity: {humidity}%");
            Console.WriteLine($"Wind: {windStrength} m/s, {windDirection}");
            Console.WriteLine($"Precipitation: {precipitation}\n");
        }
    }
}
