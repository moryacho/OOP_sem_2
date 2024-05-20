using System.Xml.Serialization;

namespace lab_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Choose:" +
                "\n1. Поиск в глубину" +
                "\n2. Поиск в ширину" +
                "\n3. Алгоритм Дейкстры" +
                "\n4. АЛгоритм Крускала" +
                "\ninput: ");
            string choice = Console.ReadLine();

            if (choice == "1") DeepthSearch.MatrixConnection();
            if (choice == "2") WidthSearch.MatrixConnection();
            if (choice == "3") Dijkstra.Start();
            if (choice == "4") Edge.Start();
        }
    }
}
