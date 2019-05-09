using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExample
{
    struct BTElement
    {
        public int key;
        public string value;
    }

    class BinaryTree
    {
        public BTElement value;

        public BinaryTree left = null;
        public BinaryTree right = null;

        public void Add(BTElement e)
        {
            if (e.key < value.key)
            {
                if (left == null)
                {
                    left = Util.Singleton(e);
                }
                else
                {
                    left.Add(e);
                }
            }
            else
            {
                if (right == null)
                {
                    right = Util.Singleton(e);
                }
                else
                {
                    right.Add(e);
                }
            }
        }
        public List<BTElement> Flatten()
        {
            var l = new List<BTElement>();

            if (left != null)
            {
                l.AddRange(left.Flatten());
            }

            l.Add(value);

            if (right != null)
            {
                l.AddRange(right.Flatten());
            }
            return l;
        }
    }

    static class Util
    {
        public static BinaryTree Singleton(BTElement e)
        {
            return new BinaryTree() { value = e };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            var bt = Util.Singleton(new BTElement() { key = 42, value = "cats" });

            Console.WriteLine("42, ");

            for (int i = 0; i < 10; i++)
            {
                var nKey = r.Next(100);
                bt.Add(new BTElement() { key = nKey, value = "" });

                Console.WriteLine($"{nKey}, ");
            }
            Console.WriteLine();

            foreach (var e in bt.Flatten())
            {
                Console.WriteLine($"{e.key}, ");
            }
            Console.WriteLine();
        }
    }
}
