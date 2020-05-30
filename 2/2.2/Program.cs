using System;

namespace week2._02
{
    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0, max = 0, min = 0, average = 0;
            Console.WriteLine("输入数组总数：");
            string s1 = Console.ReadLine();
            int num = int.Parse(s1);
            int[] array= new int[num];
            Console.WriteLine("输入数组：");
            for (int i = 0; i < num; i++)
            {
                string s = Console.ReadLine();
                int x = int.Parse(s);
                array[i] = x;
            }
            sum = Sum1(array, num);
            max = Max1(array, num);
            min = Min1(array, num);
            average = Average1(array, num);
            Console.WriteLine("Max:" + max.ToString());
            Console.WriteLine("Min:" + min.ToString());
            Console.WriteLine("Sum:" + sum.ToString());
            Console.WriteLine("Average:" + average.ToString());
        }
        private static int Max1(int[] a,int num)
        {
            int max = a[0];
            for(int i=0;i<num;i++)
            {
                if(a[i]>=a[i++])
                {
                    max = a[i];
                }
            }
            return max;
        }

        private static int Min1(int[] a, int num)
        {
            int min = a[0];
            for (int i = 0; i < num; i++)
            {
                if (a[i] <= a[i++])
                {
                    min = a[i];
                }
            }
            return min;
        }

        private static int Sum1(int[] a, int num)
        {
            int sum = 0;
            for (int i = 0; i < num; i++)
            {
                sum += a[i];
            }
            return sum;
        }
        private static int Average1(int[] a, int num)
        {
            int ave = Sum1(a, num) / num;
            return ave;
        }
    }
}
