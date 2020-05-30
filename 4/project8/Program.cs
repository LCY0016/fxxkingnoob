using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project8

{    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        public void Foreach(Action<T> action)
        {
            for (Node<T> node = this.Head;node != null; node = node.Next)
            {
                action(node.Data);
            }
        }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            int max = 0;
            int min = 0;
            int total = 0;
            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            intlist.Foreach(s => Console.WriteLine(s));
            intlist.Foreach(s => { max = max > s ? max : s;});
            Console.WriteLine($"最大值是{max}");
            intlist.Foreach(s => { min = min < s ? min : s; });
            Console.WriteLine($"最小值是{min}");
            intlist.Foreach(s => total+=s);
            Console.WriteLine($"总数是{total}");
        }
    }
}