using System;
using UserDefaults;

namespace TestUserDefaults
{
    class Program
    {
        static void Main(string[] args)
        {
            UserDefault.standard.Store("Boolean", true);
            UserDefault.standard.Store("Integer", 100);
            UserDefault.standard.Store("String", "Hello");

            Console.WriteLine(UserDefault.standard.GetBoolean("Boolean"));
            Console.WriteLine(UserDefault.standard.GetInteger("Integer"));
            Console.WriteLine(UserDefault.standard.GetString("String"));

            Console.ReadKey();
        }
    }
}
