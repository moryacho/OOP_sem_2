using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3;

internal class Tree
{
    public Tree Left; // левая ветка
    public Tree Right; // правая ветка
    public char Value; // значение
    public bool flag;
    public static List<char> list = new List<char>();
    public static Tree Node; // узел

    public Tree()
    {
        Node = null;
    }

    public Tree(Tree left, Tree right, char value)
    {
        Left = left;
        Right = right;
        Value = value;
    }

    public void Add(ref Tree node, char value)
    {
        if (node == null)
        {
            node = new Tree(null, null, value);
            flag = false;
        }
        else if (node.Value != '.' && flag == false)
        {
            if (node.Left != null)
            {
                Add(ref node.Left, value);
                if (flag == false)
                {
                    if (node.Right != null)
                    {
                        Add(ref node.Right, value);
                    }
                    else
                    {
                        node.Right = new Tree(null, null, value);
                        flag = true;
                    }
                }
            }
            else
            {
                node.Left = new Tree(null, null, value);
                flag = true;
            }
        }
    }

    public static List<char> TreeWalkStraight(Tree node) // прямой обход (корень левый правый)
    {
        if (node.Value == '.') return new List<char>();
        var result = new List<char>();
        result.Add(node.Value);
        result.AddRange(TreeWalkStraight(node.Left));
        result.AddRange(TreeWalkStraight(node.Right));
        return result;
    }

    public static List<char> TreeWalkReversed(Tree node) // обратный обход (левый правый корень)
    {
        if (node.Value == '.') return new List<char>();
        var result = TreeWalkReversed(node.Left);
        result.AddRange(TreeWalkReversed(node.Right));
        result.Add(node.Value);
        return result;
    }

    public static List<char> TreeWalkCenter(Tree node) // центрированный обход (левый корень правый)
    {
        if (node.Value == '.') return new List<char>();
        var result = TreeWalkReversed(node.Left);
        result.Add(node.Value);
        result.AddRange(TreeWalkReversed(node.Right));
        return result;

    }

    public void PrintTree(Tree node)
    {
        if (node == null) return;
        if (node.Value != '.')
        {
            Console.WriteLine($"Value: {node.Value} left: {node.Left.Value} right: {node.Right.Value}");
        }
        PrintTree(node.Left);
        PrintTree(node.Right);
    }

    public static int CalcTree(Tree node)
    {
        if (char.IsDigit(node.Value)) return node.Value;
        int num1, num2;
        num1 = CalcTree(node.Left);
        num2 = CalcTree(node.Right);
        switch (node.Value)
        {
            case '+': return num1 + num2;
            case '-': return num1 - num2;
            case '*': return num1 * num2;
            case '/': return num1 / num2;
            default: return 0;
        }
    }
}
