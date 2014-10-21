using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace csharp_func {
    internal static class Program2 {
        private static void Main(string[] args) {
            var numbers = new[] { 3, 5, 7, 9, 11, 13, 15 };
            foreach (var prime in numbers.FindPrimes()) {
                Console.WriteLine(prime);
            }
        }

        private static IEnumerable<int> FindPrimes(this IEnumerable<int> values) {
            //iterate
            //test if prime
            //return a difference sequence of ints
            var result = new List<int>();
            foreach (var number in values) {
                if (IsPrime(number)) {
                    result.Add(number);
                }
            }
            return result;
        }

        private static bool IsPrime(int number) {
            bool isPrime = true;
            for (long i = 2; i < number - 1; i++) {
                if (number % i == 0) isPrime = false;
            }
            return isPrime;
        }
    }
}
