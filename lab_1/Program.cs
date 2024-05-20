namespace lab_1;

internal class Program
{
    static void Main(string[] args)
    {
        bool flag = true;
        while (flag)
        {
            Console.Write("choose an exercise (1 or 2) or exit (0): ");
            string choise = Console.ReadLine();
            switch (choise)
            {
                case "0":
                    flag = false;
                    break;
                case "1":
                    Ex1.Start();
                    break;
                case "2":
                    Ex2.Start();
                    break;
            }
            Console.WriteLine();
        }
    }
}