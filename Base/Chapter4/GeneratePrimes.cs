using System;
using System.Collections.Generic;

namespace Base.Chapter4
{
    public class GeneratePrimes
    {
        public static List<int> Until(int limit)
        {
            var primes = new List<int>();
            for (var i = 2; i <= limit; i++)
            {
                if (!IsNumberDivisibleByPrime(i, primes))
                {
                    primes.Add(i);
                }
            }

            return primes; 
        }

        public static bool IsNumberDivisibleByPrime(int number, List<int> primes)
        {
            foreach (var prime in primes)
            {
                if (number % prime == 0)
                {
                    return true;
                }

                // smallest division possible on integer is by 2.
                // if number / prime is less than 2 that means
                // there isn't any another valid candidate
                if (number / prime < 2) break;
            }

            return false;
        }
    }
}