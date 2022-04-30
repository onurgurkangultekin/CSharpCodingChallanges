// See https://aka.ms/new-console-template for more information

/*

https://leetcode.com/problems/balanced-binary-tree/

Given a binary tree, determine if it is height-balanced.

For this problem, a height-balanced binary tree is defined as:

a binary tree in which the left and right subtrees of every node differ in height by no more than 1.

Input: root = [3,9,20,null,null,15,7]
Output: true

Input: root = [1,2,2,3,3,null,null,4,4]
Output: false

*/

class Program
{
    static void Main(string[] args)
    {
        int?[] arr = new int?[] { 3, 9, 20, null, null, 15, 7 };
        var tree = new Tree(arr);
        tree.Print();
        Console.WriteLine(tree.IsBalanced(tree.Root));
        arr = new int?[] { 1, 2, 2, 3, 3, null, null, 4, 4 };
        tree = new Tree(arr);
        Console.WriteLine(tree.IsBalanced(tree.Root));
        arr = new int?[] { 1, 2, 2, 3, null, null, 3, 4, null, null, 4 };
        tree = new Tree(arr);
        Console.WriteLine(tree.IsBalanced(tree.Root));
        arr = new int?[] { 1, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 4, 4, null, null, 5, 5 };
        tree = new Tree(arr);
        Console.WriteLine(tree.IsBalanced(tree.Root));

    }
}


public class Node
{
    public int? Data { get; set; }
    public Node Left { get; set; }
    public Node Right { get; set; }

    public override string ToString()
    {
        string res = string.Empty;
        if (Left != null)
        {
            res += $"{Left.Data}<-";
        }
        res += $"{Data}";
        if (Right != null)
        {
            res += $"->{Right.Data}";
        }

        return res;
    }
}

public class Tree
{
    public Node Root { get; set; }

    public Tree(int?[] arr)
    {
        var items = new Queue<int?>(arr);
        var nodes = new Queue<Node>();

        Root = new Node { Data = items.Dequeue() };
        nodes.Enqueue(Root);
        while (nodes.Count > 0)
        {
            var parent = nodes.Dequeue();
            if (items.Count > 0)
            {
                var item = items.Dequeue();
                if (item != null)
                {
                    parent.Left = new Node { Data = item.Value };
                    nodes.Enqueue(parent.Left);
                }
            }
            if (items.Count > 0)
            {
                var item = items.Dequeue();
                if (item != null)
                {
                    parent.Right = new Node { Data = item.Value };
                    nodes.Enqueue(parent.Right);
                }
            }
        }
    }

    public bool IsBalanced(Node root)
    {
        if (root == null)
        {
            return true;
        }

        var leftHeight = FindHeight(root.Left);
        var rightHeight = FindHeight(root.Right);
        var balanced = Math.Abs(leftHeight - rightHeight) < 2;

        if (!balanced)
        {
            return false;
        }

        if (!IsBalanced(root.Left))
        {
            return false;
        }
        if (!IsBalanced(root.Right))
        {
            return false;
        }
        return true;
    }

    private int FindHeight(Node root)
    {
        if (root == null)
        {
            return 0;
        }
        var leftHeight = FindHeight(root.Left);
        var rightHeight = FindHeight(root.Right);
        return Math.Max(leftHeight, rightHeight) + 1;
    }

    public void Print()
    {
        var q = new Queue<Node>();
        q.Enqueue(Root);
        while (q.Count > 0)
        {
            var current = q.Dequeue();
            if (current.Left != null)
            {
                q.Enqueue(current.Left);
            }
            Console.WriteLine(current);
            if (current.Right != null)
            {
                q.Enqueue(current.Right);
            }
        }
    }
}

