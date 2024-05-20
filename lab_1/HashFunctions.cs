using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_1;

internal static class HashFunctions
{
    const int MAX_LEN_KEY_MID_SQUARE = 5;

    static private bool IsPrime(int n)
    {
        for(int i = 2; i <= (int)(Math.Pow(n, 0.5)); i++)
        {
            if (n % i == 0)
            {
                return false;
            }
        }

        return true;
    }

    static internal int GetNearBigPrimeNumber(int number)
    {
        if (number < 20)
        {
            return GetNearBigPrimeNumber(20);
        }

        int res = number + 1;

        while (true)
        {
            if (IsPrime(res))
            {
                return res;
            }

            res++;
        }
    }

    static private int GetSumOrdString(string word)
    {
        int sum = 0;

        foreach (char c in word)
        {
            sum += (int)c;
        }

        return sum;
    }

    static internal Dictionary<int, string> ReminderOfTheDivision(string[] strings)
    {
        var dict = new Dictionary<int, string>();
        int[] keys = new int[strings.Length];


        for (int i = 0; i < strings.Length; i++)
        {
            keys[i] = GetSumOrdString(strings[i]);
        }


        int hashTableSize = keys.Length;
        int nearPrimeNumber = GetNearBigPrimeNumber(hashTableSize);

        for (int i = 0; i < hashTableSize; i++)
        {
            dict.Add((int)(keys[i] % nearPrimeNumber), strings[i]);
        }

        return dict;
    }

    static private int GetKeyToMidSquare(string word)
    {
        int sum = GetSumOrdString(word);
        string square = (sum * sum).ToString();

        switch (square.Length)
        {
            case 0:
                return 0;

            case < MAX_LEN_KEY_MID_SQUARE:
                return int.Parse(square);

            default:
                int toDelete = (square.Length - MAX_LEN_KEY_MID_SQUARE) / 2;
                string res = square.Substring(toDelete, MAX_LEN_KEY_MID_SQUARE);
                return int.Parse(res);
        }
    }

    static internal Dictionary<int, string> MidSquare(string[] strings)
    {
        var dict = new Dictionary<int, string>();

        foreach (string word in strings)
        {
            dict.Add(GetKeyToMidSquare(word), word);
        }

        return dict;
    }

    //static private int[] GetPows(int p, int maxLenWord)
    //{
    //    int[] pPows = new int[maxLenWord];
    //    pPows[0] = 1;

    //    for (int i = 1; i < maxLenWord; i++)
    //    {
    //        pPows[i] = pPows[i - 1] * p;
    //    }

    //    return pPows;
    //}

    static internal int GetKeyPolinomHash(string word, int p, int x)
    {
        int hash = 0;
        for (int i = 0; i < word.Length; i++)
        {
            hash = hash * x + (int)word[i];
            hash = (int)(hash % p);
        }

        return hash;
    }

    static internal Dictionary<int, int> PolinomHash(string[] strings, int arrayLength)
    {
        int p = GetNearBigPrimeNumber(arrayLength);
        Random rnd = new Random();
        int x = rnd.Next(1, p);

        var dict = new Dictionary<int, int>();

        for (int i = 0; i < arrayLength; i++)
        {
            string word = strings[i];
            int value = GetKeyPolinomHash(word, p, x);
            dict[i] = value;
            //Console.WriteLine($"{key} {word}");
        }

        dict = dict.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

        return dict;
    }
}
