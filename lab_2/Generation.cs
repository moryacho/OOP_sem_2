using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_2;

internal class Generation
{
    public int a;
    public int b;
    public int c;
    public int d;
    public static Random random = new Random();
    public int ex_res;
    public Func<int, int, int, int, int> f;
    private int? real_res;

    public int RealResult
    {
        get
        {
            if (real_res == null)
            {
                real_res = f(a, b, c, d);
            }
            return (int)real_res;
        }
    }

    public Generation(Func<int,  int, int, int, int> f, int a, int b, int c, int d, int ex_res)
    {
        this.f = f;
        this.a = a;
        this.b = b;
        this.c = c;
        this.d = d;
        this.ex_res = ex_res;
    }

    public static Generation NewGen(Generation p1,  Generation p2) // новое поколение от двух родителей
    {
        int x = random.Next(1, 4);
        switch (x)
        {
            case 1: return new Generation(p1.f, p1.a, p1.b, p2.c, p2.d, p2.ex_res);
            case 2: return new Generation(p1.f, p1.a, p2.b, p2.c, p2.d, p2.ex_res);
            case 3: return new Generation(p1.f, p1.a, p1.b, p1.c, p2.d, p2.ex_res);
            default: return null;
        }
    }

    public void Change() // мутация
    {
        int imposter = random.Next(1, 5);
        switch (imposter)
        {
            case 1:
                a = random.Next(1, 30);
                break;
            case 2:
                b = random.Next(1, 30);
                break;
            case 3:
                c = random.Next(1, 30);
                break;
            case 4:
                d = random.Next(1, 30);
                break;
            default:
                break;
        }
    }

    public int GetAc() //насколько реальный рез отличается от ожидаемого
    {
        return Math.Abs((int)(ex_res - RealResult));
    }

    public static double SrKoef(List<Generation> gens) // средник коэф выживания поколения
    {
        double sum = 0;
        foreach(Generation item in gens)
        {
            sum += item.GetAc();
        }

        return sum / gens.Count;
    }
}
