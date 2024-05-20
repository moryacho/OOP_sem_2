using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4;

internal class DeepthSearch
{
    static Random rand = new Random();
    static int n = 6;
    static List<int> used = new List<int>();
    static int[][] g = new int[n][];

    public static void MatrixConnection()
    {
        for (int i = 0; i < n; i++)
        {
            g[i] = new int[n];
        }

        for (int i = 0;i < n; i++)
        {
            Console.Write($"\n ({i}) вершина -->[");
            for (int j = 0; j < n; j++)
            {
                g[i][j] = rand.Next(0, 2);
                g[j][i] = g[i][j];
            }

            foreach (var item in g[i])
            {
                Console.Write(item);
            }
            Console.Write("]\n");
        }

        Method(0);
        Console.WriteLine("Вершины были пройдены в следующем порядке:");
        foreach (var item in used)
        {
            Console.Write(item + " ");
        }
    }

    public static void Method(int i)
    {
        used.Add(i);
        for (int j = 0;j < n; j++)
        {
            if (g[i][j] == 1 && !used.Contains(j))
            {
                Method(j);
            }
        }
    }
}
