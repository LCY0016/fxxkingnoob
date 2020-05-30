using System;

namespace homework
{
    class Program
    {
        static void Main(string[] args)
        {
            double a, c = 0;
            Console.WriteLine("简易计算器");
            Console.WriteLine("请输入第一个操作数：");

            while (true) {
                try
                {
                    a = Double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("出现错误，请重新输入第一个操作数：");
                    continue;
                }
                break;
            }
            

            Console.WriteLine("请输入操作符：");
            String b = Console.ReadLine();
            Console.WriteLine("请输入第二个操作数：");
            while (true)
            {
                try
                {
                    c = Double.Parse(Console.ReadLine());
                }
                catch (Exception)
                {
                    Console.WriteLine("出现错误，请重新输入第二个操作数：");
                    continue;
                }
                break;
            }
            switch (b)
            {
                case "+": 
                    Console.WriteLine("结果为:{0}",a+c); 
                    break;
                case "-": 
                    Console.WriteLine("结果为：{0}",a-c); 
                    break;
                case "*": 
                    Console.WriteLine("结果为：{0}",a*c); 
                    break;
                case "/":
                    if (c == 0)
                    {
                        Console.WriteLine("除数不能为0");
                    }
                    else {
                        Console.WriteLine("结果为：{0}", a/c);
                    }
                    break;
                default:
                    Console.WriteLine("请输入正确的操作符");
                    break;
            }
        }
    }
}
