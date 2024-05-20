namespace lab_3;

internal class Program
{
    static void Main(string[] args)
    {
        Tree t = new Tree();

        List<char> chars = new List<char>()  { '/', '*', '+', '2', '.', '.', '3', '.', '.', '-', '7', '.', '.', '4', '.', '.', '3', '.', '.'};
        for (int i = 0; i < chars.Count; i++)
        {
            t.flag = false;
            t.Add(ref Tree.Node, chars[i]);
        }

        t.PrintTree(Tree.Node);
        Console.WriteLine("Reversed order");
        Tree.list = Tree.TreeWalkReversed(Tree.Node);
        foreach (var item in Tree.list)
        {
            Console.Write(item + " ");
        }
        Tree.list.Clear();
        Console.WriteLine($"Result is {Tree.CalcTree(Tree.Node)}");

        //List<char> chars = new List<char>() {'a', 'b', 'd', '.', '.', 'e', '.', '.', 'c', '.', 'f', '.', '.' };
        // for (int i = 0; i < chars.Count; i++)
        //{
        //    t.flag = false;
        //    t.Add(ref Tree.Node, chars[i]);
        //}

        //t.PrintTree(Tree.Node);
        //Console.WriteLine("Straight order");
        //Tree.list = Tree.TreeWalkStraight(Tree.Node);
        //foreach (var item in Tree.list)
        //{
        //    Console.Write(item + " ");
        //}
        //Tree.list.Clear();
        //Console.WriteLine();

        //Console.WriteLine("Reversed order");
        //Tree.list = Tree.TreeWalkReversed(Tree.Node);
        //foreach (var item in Tree.list)
        //{
        //    Console.Write(item + " ");
        //}
        //Tree.list.Clear();
        //Console.WriteLine();

        //Console.WriteLine("Center order");
        //Tree.list = Tree.TreeWalkCenter(Tree.Node);
        //foreach (var item in Tree.list)
        //{
        //    Console.Write(item + " ");
        //}
        //Tree.list.Clear();

    }




}
