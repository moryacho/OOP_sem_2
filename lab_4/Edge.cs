using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4;

internal class Edge
{
    public int I { get; set; }
    public int J { get; set; }
    public int Weight { get; set; }
    static int n = 6;
    static Random rand = new Random();
    static int[][] g = new int[n][];
    public static List<Edge> reb = new List<Edge>();
    public static List<HashSet<int>> toplist = new List<HashSet<int>>();

    public Edge(int i, int j, int weight)
    {
        I = i;
        J = j;
        Weight = weight;
    }

    public static void Start()
    {
        for (int i = 0; i < n; i++)
        {
            g[i] = new int[n];
        }

        for (int i = 0; i < n; i++)
        {
            Console.Write("\n(" + i + ") вершина -->[");
            for (int j = i; j < n; j++)
            {
                {
                    g[i][j] = rand.Next(0, 2);
                    if (g[i][j] == 1)
                    {
                        g[i][j] = rand.Next(1, 21);
                        Edge edge = new Edge(i, j, g[i][j]);
                        Edge.reb.Add(edge);
                    }
                    g[j][i] = g[i][j];
                }
            }
            foreach (var item in g[i])
            {
                Console.Write(item + " ");
            }
            Console.Write("]\n");
        }

        Console.WriteLine("Отсортированный список ребер:");
        Edge.reb.Sort((a, b) => a.Weight.CompareTo(b.Weight));
        foreach (var item in Edge.reb)
        {
            Console.Write(item.Weight + " ");
        }

        foreach (var item in Edge.reb)
        {
            item.EdgeCheck();
        }
        Console.WriteLine();
        foreach (var item in Edge.reb)
        {
            if (item.Weight != -1)
            {
                Console.WriteLine("ребро между вершинами " + item.I + " и " + item.J + " вес " + item.Weight);
            }
        }
    }

    public void EdgeCheck()
    {
        bool flagI = false;
        bool flagJ = false;
        int nTop = -1;
        for (int n = 0; n < toplist.Count; n++)
        {
            if (toplist[n].Contains(this.I) && !toplist[n].Contains(this.J))
            {
                flagI = true;
                if (nTop != -1)
                {
                    toplist[n].UnionWith(toplist[nTop]);
                    toplist[nTop].Clear();
                }
                else
                {
                    nTop = n;
                }
            }
            else if(!toplist[n].Contains(this.I) && toplist[n].Contains(this.J))
            {
                flagJ = true;
                if (nTop != -1)
                {
                    toplist[n].UnionWith(toplist[nTop]);
                    toplist[nTop].Clear();
                    break;
                }
                else
                {
                    nTop = n;
                }
            }
            else if (toplist[n].Contains(this.I) && toplist[n].Contains(this.J))
            {
                flagI = true;
                flagJ = true;
                this.Weight = -1;
                break;
            }

            if (flagI == false && flagJ == false)
            {
                if (this.I != this.J)
                {
                    toplist.Add(new HashSet<int>() { this.I, this.J });
                }
                else
                {
                    this.Weight = -1;
                }
            }
            else if (flagI == true && flagJ == false)
            {
                toplist[nTop].Add(this.J);
            }
            else if (flagI == false && flagJ == true)
            {
                toplist[nTop].Add(this.I);
            }
        }
    }
}
