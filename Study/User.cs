using System;
namespace Study
{
    public class User : Person
    {
        public User(string name, int age) : base(name, age)
        { }
        public void UsPrintFOneDay(Forecast n)
        {
            Console.WriteLine("The user looks at it.");
            base.PrintForecast(n);
        }
    }
}
