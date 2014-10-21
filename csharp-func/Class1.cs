using System;
using System.Collections.Generic;

namespace csharp_func {
    internal static class Program2 {
        private static void Main(string[] args) {
            var numbers = new[] { 3, 5, 7, 9, 11, 13, 15 };
            // Passing in the IsPrime function into Find
            foreach (var prime in numbers.Find(IsPrime)) {
                Console.WriteLine(prime);
            }
        }

        // Find is a higher order function, as it takes another function as a parameter
        // composable with other functions
        private static IEnumerable<int> Find(this IEnumerable<int> values, Func<int, bool> test) {
            //iterate
            //test if prime
            //return a difference sequence of ints
            var result = new List<int>();
            foreach (var number in values) {
                //if (IsPrime(number)) {
                if (test(number)) {
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
