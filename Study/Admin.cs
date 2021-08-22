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

        public void SetLogin(string setLogin)//га
        {

            while (true)
            {
                setLogin.Trim();
                if (setLogin != "")
                {
                    for (int i = 0; i < countAdmin; i++)
                    {
                        if (setLogin == listAdmin[i].login)
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

        public void PrintForecastAd(Forecast n)
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
