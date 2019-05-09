using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryTreeExample
{
    struct BTElement<K, V>
        where K : IComparable<K>
    {

        public K key;
        public V value;
    }

    class BinaryTree<K, V>
        where K : IComparable<K>
    {
        public BTElement<K, V> value;

        public BinaryTree<K, V> left = null;
        public BinaryTree<K, V> right = null;

        public void Add(BTElement<K, V> e)
        {
            if (e.key.CompareTo(value.key) < 0)
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
        public List<BTElement<K, V>> Flatten()
        {
            var l = new List<BTElement<K, V>>();

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
        public static BinaryTree<K, V> Singleton<K, V>(BTElement<K, V> e)
            where K : IComparable<K>
        {
            return new BinaryTree<K, V>() { value = e };
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Random r = new Random();

            var bt = Util.Singleton(new BTElement<int, string>() { key = 42, value = "cats" });

            Console.Write("42, ");

            for (int i = 0; i < 10; i++)
            {
                var nKey = r.Next(100);
                bt.Add(new BTElement<int, string>() { key = nKey, value = "" });

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
