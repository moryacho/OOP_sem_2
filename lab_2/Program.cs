namespace lab_2;

internal class Program
{
    public static int res = 30;
    public static Func<int, int, int, int, int> f = (a, b, c, d) => a + 2 * b + 3 * c + 4 * d;
    public static Random random = new Random();

    static void Main(string[] args)
    {
        List<Generation> gens = new List<Generation>();

        for (int i = 0; i < 5; i++)
        {
            gens.Add(new Generation(f, random.Next(1, 30), random.Next(1, 30), random.Next(1, 30), random.Next(1, 30), res));
        }

        for (int i = 0; ; i++)
        {
            Console.WriteLine($"Iteration {i + 1}: ");

            foreach (Generation g in gens)
            {
                Console.Write($"a = {g.a}  b = {g.b}  c = {g.c}  d = {g.d}\n");
            }
            Console.WriteLine("------------------------");

            double koef1 = Generation.SrKoef(gens);
            var best = gens.OrderBy(g => g.GetAc()).ToList();

            if (best.Any(g => g.RealResult == res))
            {
                Solution(best[0]);
                break;
            }

            gens.Clear();
            gens.Add(Generation.NewGen(best[0], best[1]));
            gens.Add(Generation.NewGen(best[1], best[0]));
            gens.Add(Generation.NewGen(best[0], best[2]));
            gens.Add(Generation.NewGen(best[2], best[0]));
            gens.Add(Generation.NewGen(best[1], best[2]));

            double koef2 = Generation.SrKoef(gens);

            if (koef2 <= koef1)
            {
                Random r = new Random();
                int x = random.Next(1, 5);

                for (int j = 0; j < x; j++)
                {
                    gens[r.Next(0, 5)].Change();
                }
            }

        }
    }

    public static void Solution(Generation g)
    {
        Console.WriteLine($"Solution: a = {g.a}  b = {g.b}  c = {g.c}  d = {g.d}");
    }
}
