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
            

            Admin adminBob = new Admin("Bob", 23);
            User en = new User("En", 18);
            en.PrintUs(arrayForecast[9]);
            adminBob.SetHumidityAd(60, arrayForecast[9]);
            adminBob.PrintAd(arrayForecast[9]);
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
        LightRain,
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
        public void SetTemperature (int tMax, int tMin)
        {
            if (tMax >= -267 && tMax <= 50)
                this.temperatureMax = tMax;
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
        public void SetPressure (int setPressure)
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
    class Person
    {
        private string name;
        private int age = 18;

        public Person(string name, int age)
        {
            this.name = name;
            if (age >= 0)
                this.age = age;
            else
                Console.WriteLine("The age cannot be less than 0. Age is set 18.");
        }
        public void PrintForecast (Forecast n)
        {
            n.GetForecast();
        }
    }

    class User : Person
    {
        public User (string name, int age) : base (name, age)
        { }
        public void PrintUs(Forecast n)
        {
            Console.WriteLine("The user looks at it.");
            base.PrintForecast(n);
        }
    }

    class Admin : Person
    {
        public Admin (string name, int age) : base (name, age)
        {

        }
        public void PrintAd(Forecast n)
        {
            Console.WriteLine("The admin looks at it.");
            base.PrintForecast(n);
        }


        public void SetTemperatureAd(int tMaxAd, int tMinAd, Forecast forecast)
        {
            forecast.SetTemperature(tMaxAd, tMinAd);
        }
        public void SetPressureAd (int pressureAd, Forecast forecast)
        {
            forecast.SetPressure(pressureAd);
        }
        public void SetHumidityAd (int humidityAd, Forecast forecast)
        {
            forecast.SetHumidity(humidityAd);
        }
        public void SetWindAd(int strengthAd, EDirection directionAd, Forecast forecast)
        {
            forecast.SetWind(strengthAd, directionAd);
        }
        public void SetPrecipitationAd(EVariantsPrecipitation precipitationAd, Forecast forecast)
        {
            forecast.SetPrecipitation(precipitationAd);
        }
    }
}