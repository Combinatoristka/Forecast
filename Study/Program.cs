using System;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {

            Forecast[] arrayForecast = new Forecast[10];
            for (int i = 0; i < 10; i++)
            {
                arrayForecast[i] = CreatingAForecast(i);
            }
            for (int i = 0; i < 10; i++)
                arrayForecast[i].GetForecast();
            Console.ReadLine();
        }
        static Forecast CreatingAForecast(int n)
        {
            var day = DateTime.Today.AddDays(n);
            Random rand = new Random();
            int temperatureMax = rand.Next(40);
            int temperatureMin = temperatureMax - rand.Next(9);
            int pressure = rand.Next(740, 745);
            int humidity = rand.Next(50, 90);
            int windS = rand.Next(20);
            EDirection direction = (EDirection)rand.Next(7);
            EVariantsPrecipitation precipitation = (EVariantsPrecipitation)rand.Next(4);

            return new Forecast (day, temperatureMax, temperatureMin, pressure, humidity, windS, direction, precipitation);
        }
    }

    enum EVariantsPrecipitation
    {
        Sunny,
        Cloudy,
        LightRain, //shower
        HeavyRain,
        Thunderstorm
    }
     enum EDirection
    {
        North,
        NW,
        West,
        SW,
        South,
        SE,
        East,
        NE
    }

    class Forecast
    {
        private DateTime date;
        private int temperatureMax;
        private int temperatureMin;
        private int pressure;
        private int humidity;
        private int windStrength;
        private EDirection windDirection;
        private EVariantsPrecipitation precipitation;

        public Forecast(DateTime date, int temperatureMax, int temperatureMin, int pressure, int humidity, int windStrength, EDirection windDirection, EVariantsPrecipitation precipitation)
        {
            this.date = date;
            this.temperatureMax = temperatureMax;
            if (temperatureMax >= temperatureMin)
                this.temperatureMin = temperatureMin;
            this.pressure = pressure;
            this.humidity = humidity;
            this.windStrength = windStrength;
            this.windDirection = windDirection;
            this.precipitation = precipitation;
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