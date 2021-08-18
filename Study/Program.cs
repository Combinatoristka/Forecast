using System.Collections.Generic;
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
            //for (int i = 0; i < 10; i++)
            //arrayForecast[i].GetForecast();

            Admin bob = new Admin("Bob", 27, "bob2.0", "nyam" );
            Admin en = new Admin( "En", 34, "En34", "En374" );
            
            Console.WriteLine("Hello, you are registered. (YES/NO)");
            if (CntrAnswer() == "YES")
            {
                Console.WriteLine("Write login.");
                string login = Console.ReadLine().Trim();
                for (int enumerationL = 0; enumerationL < Admin.GetCountAdmin(); enumerationL++)
                {
                    if (enumerationL == Admin.GetCountAdmin() - 1 && login != Admin.GetListAdmin()[enumerationL].GetLoginAd())
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

                    else if (login == Admin.GetListAdmin()[enumerationL].GetLoginAd())
                    {
                        CntrPassword(Admin.GetListAdmin()[enumerationL]);
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
        public static void CntrPassword(Admin admin)
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
    public enum EVariantsPrecipitation
    {
        Sunny,
        Cloudy,
        LightRain,
        HeavyRain,
        Thunderstorm
    }
    public enum EDirection
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
}