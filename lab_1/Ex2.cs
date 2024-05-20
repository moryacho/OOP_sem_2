using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1;

internal class Ex2
{
    private static int MOD = HashFunctions.GetNearBigPrimeNumber(256);
    private static Random rnd = new Random();
    private static int X = rnd.Next(1, MOD);
    static internal void Start()
    {
        Console.Write("input string: ");
        string text = Console.ReadLine();

        Console.Write("input pattern: ");
        string pattern = Console.ReadLine();
        int lnPattern = pattern.Length;
        int hashPattern = HashFunctions.GetKeyPolinomHash(pattern, MOD, X);

        string substring;
        int hashSubstring;

        for (int i = 0; i < text.Length - lnPattern + 1; i++)
        {
            substring = text.Substring(i, lnPattern);
            hashSubstring = HashFunctions.GetKeyPolinomHash(substring, MOD, X);

            if (hashSubstring == hashPattern)
            {
                Console.WriteLine($"index: {i}  substring: {substring}");
            }
        }
    }
}
