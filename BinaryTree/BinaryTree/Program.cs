
namespace BinaryTree
{
    internal class Program
    {
        public static void swap(ref int x, ref int y)
        {
            int aux = x;
            x = y;
            y = aux;
        }
        public static void heapify(int[] arr, int n, int i)
        {

            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (left < n && arr[left] > arr[largest])
                largest = left;

            if (right < n && arr[right] > arr[largest])
                largest = right;

            if (largest != i)
            {
                swap(ref arr[i], ref arr[largest]);
                heapify(arr, n, largest);
            }
        }
        public static void heapSort(int[] arr)
        {
            //Building max Heap
            for (int i = arr.Length / 2 - 1; i >= 0; i--)
                heapify(arr, arr.Length, i);
            //Heap Sort
            for (int i = arr.Length - 1; i >= 0; i--)
            {
                swap(ref arr[0], ref arr[i]);

                //Heapify root element to get highest element at root again
                heapify(arr, i, 0);
            }



        }
        static void Main(string[] args)
        {
            /*
            BiTree tree= new BiTree();

            tree.AddNode(7);
            tree.AddNode(5);
            tree.AddNode(9);
            tree.AddNode(6);
            tree.AddNode(10);

            Console.WriteLine("Pre-order Traversal");
            tree.PreOrderTraversal(tree.Root);
            Console.WriteLine();
            Console.WriteLine("In-order Traversal");
            tree.InOrderTraversal(tree.Root);
            Console.WriteLine();
            Console.WriteLine("Post-order Traversal");
            tree.PostOrderTraversal(tree.Root);
            Console.WriteLine();
            if (tree.isFullBinaryTree(tree.Root)) Console.WriteLine("The tree is a full binary tree");
            else Console.WriteLine("The tree is a full binary tree");
            if (tree.isPerfect(tree.Root)) Console.WriteLine("The tree is a perfect binary tree");
            else Console.WriteLine("The tree is a perfect binary tree");
            */

            // Heap Sort

            int[] arr = { 1, 12, 9, 5, 6, 10, 20 };

            heapSort(arr);
            foreach (var item in arr)
            {
                Console.Write(item + " ");
            }

        }
    }
}