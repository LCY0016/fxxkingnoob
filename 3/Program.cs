using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace homework
{
    interface Shape
    {
        int Calculation();
    }

    class ShapeFactory
    {
        //静态工厂方法  
        public static Shape GetShape(String type)
        {
            Shape shape = null;
            if (type.Equals("Rectangle"))
            {
                shape=new Rectangle();
            }
            else if(type.Equals("Square"))
            {
                shape = new Square();
            }
            else if (type.Equals("Triangle"))
            {
                shape=new Triangle();
            }

            return shape;
        }
    }

    class Rectangle :Shape
    {
        private int length1=1;
        private int length2=1;

        public int Length1
        {
            get=> length1;
            set
            {
                if (value > 0)
                {
                    length1 = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public int Length2
        {
            get => length2;
            set
            {
                if (value > 0)
                {
                    length2 = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public int Calculation()
        {
            return length1 * length2;
        }
    }

    class Square : Shape
    {
        private int length = 1;

        public int Length
        {
            get => length;
            set
            {
                if (value > 0)
                {
                    length = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public int Calculation()
        {
            return length * length;
        }
    }

    class Triangle : Shape
    {
        private int bottomLength = 1;
        private int height = 1;

        public int BottomLength
        {
            get => bottomLength;
            set
            {
                if (value > 0)
                {
                    bottomLength = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }
        public int Height
        {
            get => height;
            set
            {
                if (value > 0)
                {
                    height = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        public int Calculation()
        {
            return bottomLength*height/2;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int sum = 0;
            try
            {
                List<Shape> shapsList=new List<Shape>();

                Random rd = new Random();

                for (int i=0;i<3;i++)
                {
                    Shape shape = ShapeFactory.GetShape("Triangle");
                    ((dynamic)shape).BottomLength =rd.Next(10,20);
                    ((dynamic)shape).Height = rd.Next(10,20);
                    shapsList.Add(shape);
                }

                for (int i = 0; i < 3; i++)
                {
                    Shape shape = ShapeFactory.GetShape("Square");
                    ((dynamic)shape).Length = rd.Next(10, 20);
                    shapsList.Add(shape);
                }

                for (int i = 0; i < 4; i++)
                {
                    Shape shape = ShapeFactory.GetShape("Rectangle");
                    ((dynamic)shape).Length1 = rd.Next(10,20);
                    ((dynamic)shape).Length2 = rd.Next(10,20);
                    shapsList.Add(shape);
                }

                foreach (var shape in shapsList)
                {
                    sum += shape.Calculation();
                }

                Console.WriteLine(sum);
            }
            catch (Exception e)
            {
                Console.WriteLine("数据错误");
            }

            Console.ReadKey();
        }
    }
}
