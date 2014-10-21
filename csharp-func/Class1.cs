using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace csharp_func {
    public class Timekeeper {
        public TimeSpan Measure(Action action) {
            var watch = new Stopwatch();
            watch.Start();
            action();
            return watch.Elapsed;
        }
    }

    internal static class Program2 {
        private static void Main(string[] args) {
            var timekeeper = new Timekeeper();
            // Passing in a function to Measure
            var elapsed = timekeeper.Measure(() => {
                foreach (var prime in GetRandomNumbers().Find(IsPrime).Take(2)) {
                    Console.WriteLine(prime);
                }
            });
            Console.WriteLine(elapsed);
        }

        static IEnumerable<int> GetRandomNumbers() {
            Random rand = new Random();
            // Infinite loop
            while (true) {
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
                if (test(number)) {
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
