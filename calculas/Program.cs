using System;
using System.Text;
using System.Data;
using System.Linq;
using static calculas.Calculator;
using static System.Console;
using static System.Math;
namespace calculas
{
    //复化求积公式编程
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            WriteLine("复化梯形公式结果="+trapezoid(x=>Exp(-x),0,1,41));
            WriteLine("复化Simpson公式结果="+simpson(x=>Exp(-x),0,1,4));
            Read();
        }
    }
    public static class Calculator
    {
        public static double trapezoid(Func<double,double> f ,double a,double b,int n)
        {
            double h=(b-a)/n;
            double result = 0;
            for(int i =0;i<=n;i++)
            {
                result = result + (f(a+i*h)+f(a+(i+1)*h))*h/2;   
            }
            return result;
        }
        public static double simpson(Func<double,double> f,double a ,double b,int n)
        {
            double h=(b-a)/n;
            int m =n/2;
            double result=0;
            for(int k=1;k<=m;k++)
            {
                result=result + (
                                f(a+(2*k-2)*h)
                                +4*f(a+(2*k-1)*h)
                                +f(a+(2*k)*h))*h/3;
            }
            return result ;
        }
    }

}
