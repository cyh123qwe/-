using System;
using System.Data;
using System.Collections;
using System.Linq;
using static System.Math;
using static System.Console;

namespace 二分法
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            double eps=10e-2;
            double a=1;double b=1.5;
            while(true)
            {
                double x=(a+b)/2;
                if(f(a)*f(b)<0)
                {
                    b=x;
                }
                else
                a=x;
                if(Abs(b-a)<eps)
                {
                    WriteLine(x);
                    break;
                }
                continue;
            }
        }
        public static double f(double x)
        {
            return Pow(x,3)-x-1;
        }
    }
}
