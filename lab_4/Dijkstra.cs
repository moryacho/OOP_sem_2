using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4;

internal class Dijkstra
{
    static int n = 6;
    static int[] a = new int[n];
    static int[] b = new int[n];
    static int[] c = new int[n];
    static int[][] W = new int[n][];
    static Random rand = new Random();

    public static void Start()
    {
        for (int i = 0; i < n; i++)
        {
            a[i] = 0;
            c[i] = 0;
            b[i] = 10000;
            W[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write("\n(" + i + ") вершина --> [");
            for (int j = 0; j < n; j++)
            {
                W[i][j] = rand.Next(0, 2);
                W[j][i] = W[i][j];
            }
            foreach (var item in W[i])
            {
                Console.Write(item);
            }
            Console.Write("]\n");
        }

        b[0] = 0;
        Method(0);
        for (int i = 1; i < n; i++)
        {
            Console.WriteLine("Путь до вершины " + i + " от вершины 0:");
            Console.Write(i);
            int z = i;

            do
            {
                Console.Write(" <- " + c[z]);
                z = c[z];
            } while (z != 0);

            Console.WriteLine();
        }
    }


    public static void Method(int i)
    {
        int min = 1000000;
        int min_j = 0;

        for (int j = 0; j < n; j++)
        {
            if (a[j] == 0 && W[i][j] != 0)
            {
                if (b[j] > (b[i] + W[i][j]))
                {
                    c[j] = i;
                    b[j] = b[i] + W[i][j];
                }

                if (b[j] < min)
                {
                    min = b[j];
                    min_j = j;
                }
            }
        }

        a[i] = 1;
        if (min_j != 0)
        {
            Method(min_j);
        }
    }
}
