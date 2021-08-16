using System.Collections.Generic;
using System;

namespace Study
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("New test");
            Admins listAdmins = new Admins();
            Console.WriteLine("OK");

            Forecast[] arrayForecast = new Forecast[10];
            for (int i = 0; i < 10; i++)
            {
                arrayForecast[i] = CreatingAForecast(i);
            }
            //for (int i = 0; i < 10; i++)
            //arrayForecast[i].GetForecast();

            listAdmins.MadeAdmins("Bob", 27, "bob2.0", "nyam");
            listAdmins.MadeAdmins("En", 34, "En34", "En374");
            
            Console.WriteLine("Hello, you are registered. (YES/NO)");
            if (CntrAnswer() == "YES")
            {
                Console.WriteLine("Write login.");
                string login = Console.ReadLine().Trim();
                for (int enumerationL = 0; enumerationL < listAdmins.GetCountAdmins(); enumerationL++)
                {
                    if (enumerationL == listAdmins.GetCountAdmins() - 1 && login != listAdmins.GetOneAdmin(enumerationL).GetLoginAd())
                    {
                        Console.WriteLine("Login is not correct. Do you enter again? (YES/NO)");

                        if (CntrAnswer() == "YES")
                        {
                            Console.WriteLine("Write login.");
                            login = Console.ReadLine().Trim();
                            enumerationL = 0;
                        }
                        else
                            break;
                    }

                    else if (login == listAdmins.GetOneAdmin(enumerationL).GetLoginAd())
                    {
                        CntrPassword(listAdmins.GetOneAdmin(enumerationL));
                        break;
                    }
                }
            }
            else
            {
                /*
                Console.WriteLine("Write your name.");
                string userName = Console.ReadLine();
                Console.WriteLine("Write your age.");
                int userAge = int.Parse(Console.ReadLine());
                User user = new User(userName, userAge);
                */
                Console.WriteLine("Weather forecast for the next 10 days.\n");
                foreach (Forecast day in arrayForecast)
                {
                    day.GetForecast();
                }

            }
            Console.ReadLine();
        }
        public static string CntrAnswer()
        {
            string reply = Console.ReadLine().ToUpper().Trim();
            while(true)
            {
                if (reply == "YES" || reply == "NO")
                    return reply;
                Console.WriteLine("The answer is incorrect, try again.");
                reply = Console.ReadLine().ToUpper().Trim();
            }
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
        public static void CntrPassword(OneAdmin admin)
        {
            while (true)
            {
                Console.WriteLine("Write password.");
                string password = Console.ReadLine().Trim();

                if (password == admin.GetPasswordAd())
                {
                    Console.WriteLine($"Hello, {admin.GetNameAd()}.");
                    break;
                }
                else
                {
                    Console.WriteLine("Password is not correct. Do you enter again? (YES/NO)");
                    if (CntrAnswer() == "NO")
                        break;
                }
            }
        }
    }

    //
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
        public string GetName()
        {
            return name;
        }
    }

    class User : Person
    { 
        public User (string name, int age) : base (name, age)
        { }
        public void UsPrintFOneDay(Forecast n)
        {
            Console.WriteLine("The user looks at it.");
            base.PrintForecast(n);
        }
    }

    
    class Admins //I can made so that the admin can create another admin
    {
        public static List<OneAdmin> listAdmin = new List<OneAdmin>();

        public Admins() { }

        public void MadeAdmins(string name, int age, string login, string password)
        {
            OneAdmin ad = new OneAdmin(name, age, login, password);
            listAdmin.Add(ad);

        }
        public void PrintAdmins ()
        {
            int position = 0;
            foreach (var i in listAdmin)
            {
                Console.WriteLine($"Position in the list {position}.\n{i}\n");
                position += 1;
            }
        }
        public void DeletAdmin (int position)
        {
            if (position >= 0 && position <= listAdmin.Count)
            {
                Console.WriteLine($"Do you really want to delete: \n{listAdmin[position]}\n\nYES/NO.\n");
                string answer = Console.ReadLine();
                answer.ToUpper();
                if (answer == "YES")
                {
                    OneAdmin.countAdmin -= 1;
                    listAdmin.RemoveAt(position); 
                    Console.WriteLine($"Admin {listAdmin[position].GetNameAd()} is delet.");
                }
                else if (answer == "NO")
                    Console.WriteLine("Admin is not delet.");
            }
            else
            {
                Console.WriteLine("Number out of range of the list.");
            }

        }

        public int GetCountAdmins ()
        {
            return OneAdmin.countAdmin;
        }
        public OneAdmin GetOneAdmin(int i)
        {
            return listAdmin[i];
        }
    }

    class OneAdmin : Person
    {
        public static int countAdmin = 0;
        private string login;
        private string password;

        public OneAdmin(string name, int age, string login, string password) : base(name, age)
        {
            if (countAdmin != 0)
            {
                SetLogin(login);
            }
            else
                this.login = login;
            SetPassword(password);
            countAdmin += 1;
        }

        public string GetNameAd()
        {
            return base.GetName();
        }
        public string GetLoginAd()
        {
            return login;
        }
        public string GetPasswordAd()
        {
            return password;
        }

        public void SetLogin(string setLogin)
        {
            
            while (true)
            {
                setLogin.Trim();
                if (setLogin != "")
                {
                    for (int i = 0; i < countAdmin; i++)
                    {
                        if (setLogin == Admins.listAdmin[i].login)
                        {
                            Console.WriteLine("This username already exists. Write another one.");
                            Console.ReadLine();
                        }
                    }
                    this.login = setLogin;
                    break;
                }
                else
                {
                    Console.WriteLine("The login field is empty. Write a new username.");
                    Console.ReadLine();
                }
            }
        }
        public void SetPassword(string setPassword)
        {
            setPassword.Trim();
            while (true)
            {
                if (String.IsNullOrEmpty(setPassword))
                {
                    Console.WriteLine("The password was entered incorrectly. Try again.");
                    setPassword = Console.ReadLine().Trim();
                }
                else
                {
                    this.password = setPassword;
                    break;
                }
            }
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
        public void SetPressureAd(int pressureAd, Forecast forecast)
        {
            forecast.SetPressure(pressureAd);
        }
        public void SetHumidityAd(int humidityAd, Forecast forecast)
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