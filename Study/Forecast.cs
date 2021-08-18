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
            if (tMax >= -267 && tMax <= 50)
                temperatureMax = tMax;
            else
                Console.WriteLine($"The maximum temperature value is out of range (-267) - 50C. Maximum temperature is set {temperatureMax}.");
            if (tMin <= this.temperatureMax)
                this.temperatureMin = tMin;
            else
            {
                this.temperatureMin = temperatureMax - 5;
                Console.WriteLine($"The minimum temperature exceeds the maximum. The minimum temperature is set {temperatureMin}.");
            }

        }
        public void SetPressure(int setPressure)
        {
            if (setPressure > 735 && setPressure < 750)
                this.pressure = setPressure;
            else
                Console.WriteLine($"The pressure value is out of range 735 - 750mmHg. Pressure is set = {this.pressure}mmHg.");
        }
        public void SetHumidity(int setHumidity)
        {
            if (setHumidity >= 0 && setHumidity <= 100)
                this.humidity = setHumidity;
            else
                Console.WriteLine($"The humidity value is out of range 0 - 100%. Humidity is set {this.humidity}%");
        }
        public void SetWind(int strength, EDirection setDirection)
        {
            if (strength >= 0 && strength <= 67)
                this.windStrength = strength;
            else
                Console.WriteLine($"The wind strength value is out of range 0 - 67 m/s. Wind strength {this.windStrength}m/s.");
            this.windDirection = setDirection;
        }
        public void SetPrecipitation(EVariantsPrecipitation setPrecipitat)
        {
            this.precipitation = setPrecipitat;
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
