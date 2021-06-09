using System;
using System.Configuration;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(ConfigurationManager.ConnectionStrings["DriverContext"].ConnectionString);
            Console.ReadLine();
        }
    }
}
