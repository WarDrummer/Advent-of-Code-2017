using System.Collections.Generic;
using AdventOfCode2017.Solutions.Problem;

namespace AdventOfCode2017.Solutions.Day23
{
    internal class Day23B : IProblem
    {
        public string Solve()
        {
            // NOTES because I won't remember how I got here months from now

            // converted code to c# and kept reducing the code until it was understandable

            // original algorithm looking for any numbers (d,e) >1, multiplied by the other
            // that equals b
            // if there exists numbers d and e that meet this criteria, h is incremented
            // b is set to some number and incremented by 17 1,000 times, each value of b
            // checking for the criteria above
            // the definition of a prime number is a number that has only two positive factors
            // (1 and itself), and we're apparently looking for non-primes (called composites)

            // solution: sieve of eratosthenes to compute all primes in range, count all non-prime
            // values of b and store the count in h.

            var primeSet = CreatePrimeSet(109300 + 17000);
            var h = 0;
            for (var b = 109300; b <= (109300 + 17000); b += 17)
                if (!primeSet.Contains(b))
                    h++;

            return h.ToString();
        }

        private static HashSet<long> CreatePrimeSet(int maxNumber)
        {
            var sieve = new bool[maxNumber + 1];
            for (var i = 2; i < maxNumber; i++)
                sieve[i] = true;

            for (var j = 2; j <= maxNumber; j++)
                if (sieve[j])
                    for (long p = 2; (p * j) < maxNumber; p++)
                        sieve[p * j] = false;

            var primeSet = new HashSet<long>();
            for (var number = 0; number <= maxNumber; number++)
                if (sieve[number])
                    primeSet.Add(number);

            return primeSet;
        }
    }
}
