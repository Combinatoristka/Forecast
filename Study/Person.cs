using System;
namespace Study
{
    public class Person
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
        public void PrintForecast(Forecast n)
        {
            n.GetForecast();
        }
        public string GetName()
        {
            return name;
        }
    }
}
