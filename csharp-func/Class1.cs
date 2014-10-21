using System;
using System.Collections.Generic;
using System.Linq;

namespace csharp_func {
    internal static class Program2 {
        private static void Main(string[] args) {
            var numbers = new[] { 3, 5, 7, 9, 11, 13, 15 };
            // Passing in the IsPrime function into Find
            //foreach (var prime in numbers.Find(IsPrime).Take(2)) {
            foreach (var prime in GetRandomNumbers().Find(IsPrime).Take(2)) {
                Console.WriteLine(prime);
            }
        }

        static IEnumerable<int> GetRandomNumbers(){
            Random rand= new Random();
            // Infinite loop
            while (true){
                yield return rand.Next(1000);
            }
        }

        // Interesting this function stops when 2 primes are found (as Take(2) above)
        //static IEnumerable<int> GetRandomNumbers(){
        //    yield return 3;
        //    yield return 6;
        //    yield return 8;
        //    yield return 9;
        //    yield return 11;
        //    yield return 13;
        //}

        // Find is a higher order function, as it takes another function as a parameter
        // composable with other functions
        private static IEnumerable<int> Find(this IEnumerable<int> values, Func<int, bool> test) {
            foreach (var number in values) {
                Console.WriteLine("Testing {0}", number);
                if (test(number)){
                    yield return number;
                }
            }
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
