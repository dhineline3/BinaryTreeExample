using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExample
{
    struct BTElement<V>
    {
        public int key;
        public V value;
    }

    class BinaryTree<V>
    {
        public BTElement<V> value;

        public BinaryTree<V> left = null;
        public BinaryTree<V> right = null;

        public void Add(BTElement<V> e)
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
        public List<BTElement<V>> Flatten()
        {
            var l = new List<BTElement<V>>();

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
        public static BinaryTree<V> Singleton<V>(BTElement<V> e)
        {
            return new BinaryTree<V>() { value = e };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            var bt = Util.Singleton(new BTElement<string>() { key = 42, value = "cats" });

            Console.Write("42, ");

            for (int i = 0; i < 10; i++)
            {
                var nKey = r.Next(100);
                bt.Add(new BTElement<string>() { key = nKey, value = "" });

                Console.Write($"{nKey}, ");
            }
            Console.WriteLine();

            foreach (var e in bt.Flatten())
            {
                Console.Write($"{e.key}, ");
            }
            Console.WriteLine();
        }
    }
}
