using System;
using System.Collections;
using System.Collections.Generic;
using Base.Chapter4;
using Xunit;

namespace Tests.Chapter4
{
    /**
        Test-drive some code that will generate a list of prime
        numbers that are less than 1,000
    */
    public class GeneratePrimesTest
    {
        [Theory, MemberData(nameof(all_numbers_until_3_are_primes_data))]
        public void all_numbers_until_3_are_primes(int until, List<int> expected)
        {
            var primes = GeneratePrimes.Until(until);

            Assert.Equal(expected, primes);
        }

        public static IEnumerable<object[]> all_numbers_until_3_are_primes_data
        {
            get
            {
                return new[]
                {
                    new object[] { 2 , new List<int> {  2 } },
                    new object[] { 3 , new List<int> {  2, 3 } },
                };
            }
        }


        [Theory, MemberData(nameof(multiple_of_two_bigger_than_two_are_not_primes_data))]
        public void multiple_of_two_bigger_than_two_are_not_primes(int until, List<int> expected)
        {
            var primes = GeneratePrimes.Until(until);

            Assert.Equal(expected, primes);
        }

        public static IEnumerable<object[]> multiple_of_two_bigger_than_two_are_not_primes_data
        {
            get
            {
                return new[]
                {
                    new object[] { 4, new List<int> {  2, 3 } },
                    new object[] { 6, new List<int> {  2, 3, 5 } },
                    new object[] { 8, new List<int> {  2, 3, 5, 7 } },
                };
            }
        }

        [Theory, MemberData(nameof(all_odd_numbers_are_prime_data))]
        public void all_odd_numbers_are_prime(int until, List<int> expected)
        {
            var primes = GeneratePrimes.Until(until);

            Assert.Equal(expected, primes);
        }

        public static IEnumerable<object[]> all_odd_numbers_are_prime_data
        {
            get
            {
                return new[]
                {
                    new object[] { 3, new List<int> {  2, 3 } },
                    new object[] { 5, new List<int> {  2, 3, 5 } },
                    new object[] { 7, new List<int> {  2, 3, 5, 7 } },
                };
            }
        }

        [Theory, MemberData(nameof(all_numbers_divisible_by_primes_are_not_primes_data))]
        public void all_numbers_divisible_by_primes_are_not_primes(int until, List<int> expected)
        {
            var primes = GeneratePrimes.Until(until);

            Assert.Equal(expected, primes);
        }
        public static IEnumerable<object[]> all_numbers_divisible_by_primes_are_not_primes_data
        {
            get
            {
                return new[]
                {
                    new object[] { 9, new List<int> {  2, 3, 5, 7 } },
                    new object[] { 15, new List<int> {  2, 3, 5, 7, 11, 13 } },
                    new object[] { 19, new List<int> {  2, 3, 5, 7, 11, 13, 17, 19 } },
                };
            }
        }
    }
}
