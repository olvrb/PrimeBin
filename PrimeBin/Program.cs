using System;
using System.IO;
using System.Threading.Tasks;
using System.Numerics;

namespace PrimeBin {
    internal class Program {
        private static void Main(string[] args) {
            Console.WriteLine("starting");
            File.Delete("output.txt");
            BigInteger   i    = 3;
            StreamWriter file = new StreamWriter("output.txt", true);
            while (true) {
                CheckPrime(i, file);
                i += 2;
            }
        }

        public static async void CheckPrime(BigInteger number, StreamWriter file) {
            if (await IsPrime(number)) {
                Console.WriteLine(number);
                //file.WriteLine(number);
            }
        }

        public static async Task<bool> IsPrime(BigInteger number) {
            double boundary = Math.Floor(Math.Pow(Math.E, BigInteger.Log(number) / 2));

            for (int i = 3; i <= boundary; i += 2) {
                if (number % i == 0) {
                    return false;
                }
            }

            return true;
        }

        public static BigInteger sqrt(BigInteger number) {
            return BigInteger.Pow(number, 1 / 2);
        }
    }
}