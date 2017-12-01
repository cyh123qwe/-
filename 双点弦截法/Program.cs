using System;
using static System.Math;
using System.Linq;
using System.Data;
using System.IO;
namespace temptest
{
    class Program
    {
        static void Main(string[] args)
        {
//Console.WriteLine("Hello World!");
            double x0,x1,delta;
            x0=0.4;
            x1=0.8;
            delta=x1-x0;
            double x=x1;
            double fold=f(x0);
            double fnew;
            double eps=1e-5;
            while(Abs(delta)>eps)
            {
                 fnew=f(x);
                delta=-fnew/(fnew-fold)*delta;
                x=x+delta;
                fold=fnew;

            }
            Console.WriteLine(x);
        }
        public static double f(double x)
        {
            return (Exp(-x)-x);
        }
    }
}
