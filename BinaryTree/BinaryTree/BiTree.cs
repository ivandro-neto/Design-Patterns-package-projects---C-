using System;
using System.Reflection.Metadata.Ecma335;
using System.Text.RegularExpressions;

class Node
{
    public int data;
    public Node left;
    public Node right;

    public Node(int data)
    {
        this.data = data;
        left = null;
        right = null;
    }
}

class BiTree
{
    private Node root;
    public Node Root { get { return root; } }
    public BiTree() => root = null;

    private Node AddNode(Node tree, Node data)
    {
        if (tree == null) return data;
        else
        {
            if (tree.data < data.data) tree.right = AddNode(tree.right, data);
            else tree.left = AddNode(tree.left, data);
        }
        return tree;
    }
    public void AddNode(int data)
    {
        Node newData = new(data);
        this.root = AddNode(this.root, newData);
    }
    
    public void PreOrderTraversal(Node tree)
    {
        if (tree != null)
        {
            Console.Write(tree.data + " ");
            PreOrderTraversal(tree.left);
            PreOrderTraversal(tree.right);
        }
    }

    public void InOrderTraversal(Node tree)
    {
        if (tree != null)
        {
            InOrderTraversal(tree.left);
            Console.Write(tree.data + " ");
            InOrderTraversal(tree.right);
        }
    }
    
    public void PostOrderTraversal(Node tree)
    {
        if (tree != null)
        {
            PostOrderTraversal(tree.left);
            PostOrderTraversal(tree.right);
            Console.Write(tree.data + " ");
        }
    }

    private int depth(Node root)
    {
        int d = 0;
        while (root != null)
        {
            d++;
            root = root.left;
        }
        return d;
    }

    public bool isFullBinaryTree(Node tree)
    {
        if (tree == null) return true;
        if (tree.left == null && tree.right == null) return true;
        else if((tree.left != null) && (tree.right != null)) return (isFullBinaryTree(tree.left) && isFullBinaryTree(tree.right));
        return false;
    }

    private bool isPerfect(Node tree, int d, int level)
    {
        Console.WriteLine(d + "      LEVL: " + level);
        if (tree == null) return true;
        else if (tree.left == null && tree.right == null) 
            return (d == level + 1);
        else if(tree.left == null || tree.right == null)
            return false;
        return isPerfect(tree.left, d, level + 1) && isPerfect(tree.right, d, level + 1);
    }
    
    public bool isPerfect(Node tree)
    {
        return isPerfect(tree, depth(tree), 0);
    }
}