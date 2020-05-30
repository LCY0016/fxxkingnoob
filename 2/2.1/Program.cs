using System;

namespace homework
{
    class Program
    {
        private static void primesFactor(int n)
        {
            int n2 = (int)Math.Sqrt(n);
            int primeFactor = 2;
            
           while(n!=1)
            {
                if(n % primeFactor==0)
                {
                    n /= primeFactor;
                    Console.WriteLine(primeFactor + " ");
                }
                else
                {
                    primeFactor++;
                }
            }


        }
        static void Main(string[] args)
        {
            Console.WriteLine("Input a number:");
            string s = Console.ReadLine();
            int num = Convert.ToInt32(s);
            if (num <= 0)
                Console.WriteLine("error");
            else
            {
                Console.WriteLine("primeFactors are:");
                primesFactor(num);
            }
        }
    }
}
