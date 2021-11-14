using System;
using System.Linq;
using Base.Chapter4;

namespace Base
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Join(", ", GeneratePrimes.Until(1000)));
            Console.WriteLine(GeneratePrimes.Until(1000).Count());
        }
    }
}
