using System;

class Program
{
    static void Main(string[] args)
    {
        Tree<char> tree = new Tree<char>();
        tree.AddChild(-1, 'A');
        tree.AddChild(0, 'B');
        tree.AddSibling(1, 'C');
        tree.AddSibling(2, 'D');
        tree.AddChild(1, 'E');
        tree.AddSibling(2, 'F');
        tree.AddSibling(3, 'G');
        tree.AddSibling(4, 'Y');
        tree.AddChild(4, 'X');

        tree.Remove(1);

        for(int i=0; i<tree.GetLength(); i++)
        {
            Console.WriteLine(tree.Get(i));
        }
    }
}