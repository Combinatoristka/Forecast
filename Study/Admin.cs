using System.Collections.Generic;
using System;
namespace Study
{
    public class Admin : Person
    {
        public static List<Admin> listAdmin = new List<Admin>();
        public static int countAdmin = 0;
        private string login;
        private string password;

        public Admin(string name, int age, string login, string password) : base(name, age)
        {
            if (countAdmin != 0)
            {
                SetLogin(login);
            }
            else
                this.login = login;
            SetPassword(password);
            countAdmin += 1;
            listAdmin.Add(this);
        }

        public static int GetCountAdmin()
        {
            return countAdmin;
        }
        public static List<Admin> GetListAdmin()
        {
            return listAdmin;
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

        public void SetLogin(string login)
        {
            login.Trim();
            if (login != "")
            {
                for (int i = 0; i < countAdmin; i++)
                {
                    if (i == countAdmin - 1 && login != listAdmin[i].login)
                        this.login = login;
                    else if (login == listAdmin[i].login)
                    {
                        Console.WriteLine("This username already exists. Write another one.");
                        SetLogin(Console.ReadLine());
                        break;
                    }
                }
            }
            else
            {
                Console.WriteLine("The login field is empty. Write a new username.");
                SetLogin(Console.ReadLine());
            }
        }
        public void SetPassword(string password)
        {
            password.Trim();
            while (true)
            {
                if (String.IsNullOrEmpty(password))
                {
                    Console.WriteLine("The password was entered incorrectly. Try again.");
                    password = Console.ReadLine().Trim();
                }
                else
                {
                    this.password = password;
                    break;
                }
            }
        }

        public void PrintForecastAd(Forecast n)
        {
            Console.WriteLine("The admin looks at it.");
            base.PrintForecast(n);
        }


        public void SetTemperatureAd(int tMax, int tMin, Forecast forecast)
        {
            forecast.SetTemperature(tMax, tMin);
        }
        public void SetPressureAd(int pressure, Forecast forecast)
        {
            forecast.SetPressure(pressure);
        }
        public void SetHumidityAd(int humidity, Forecast forecast)
        {
            forecast.SetHumidity(humidity);
        }
        public void SetWindAd(int strengthAd, EDirection direction, Forecast forecast)
        {
            forecast.SetWind(strengthAd, direction);
        }
        public void SetPrecipitationAd(EVariantsPrecipitation precipitation, Forecast forecast)
        {
            forecast.SetPrecipitation(precipitation);
        }

    }
}
