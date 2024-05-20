using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1;

internal class Ex1
{
    static internal void Start()
    {
        // n - stringArray.Length
        // m - max length of word in stringArray

        Console.Write("input array length: ");
        int n = int.Parse(Console.ReadLine());

        Console.Write("input max word length: ");
        int m = int.Parse(Console.ReadLine());

        string[] strings = GetStrings(n, m);
        // key - index, value - hash
        Dictionary<int, int> dict = HashFunctions.PolinomHash(strings, n);

        foreach (KeyValuePair<int, int> entry in dict)
        {
            Console.WriteLine($"word: {strings[entry.Key]} index: {entry.Key} hash: {entry.Value}");
        }

        int nGroups = 0;
        var previousHash = dict.First();

        foreach (KeyValuePair<int, int> entry in dict)
        {
            if (entry.Equals(dict.First()) || entry.Value != previousHash.Value)
            {
                nGroups++;
                Console.WriteLine();
                Console.Write($"group {nGroups}: ");
            }

            Console.Write(entry.Key + " ");
            previousHash = entry;
        }
    }

    static public string[] GetStrings(int n, int m)
    {
        string[] stringArray = new string[n];

        for (int i = 0; i < n; i++)
        {
            Console.Write("input string: ");
            string? word = Console.ReadLine();

            while (word.Length > m)
            {
                Console.WriteLine("Unfortunately, this word is too long\n" +
                    "Try again");
                Console.Write("input string: ");
                word = Console.ReadLine();
            }

            stringArray[i] = word;
        }

        return stringArray;
    }
}
