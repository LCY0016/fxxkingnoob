using System;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {

            bool[] w = ai(100);
            for(int i=2;i<=100;i++)
            {
                if(w[i])
                {
                    Console.WriteLine(i + " ");
                }
                else
                {
                    continue;
                }
            }
        }
        private static  bool[] ai(int num)
        {
            bool[] prime = new bool[num+1];
            for(int i=2;i<=num;i++)
            {
                prime[i] = true;
            }
            for(int i=2;i<=num;i++)
            {
                if(prime[i])
                {
                    for(int j=i*2;j<=num;j+=i)
                    {
                        prime[j] = false;
                    }
                }
            }
            return prime;
        }
    }
}
