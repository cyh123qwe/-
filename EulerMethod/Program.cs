using System;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections.Generic;
using static System.Math;
using static System.Console;
using static EulerMethod.EulerMethod;
namespace EulerMethod
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");
           Dictionary<double,double> result=EulerCal(testfunc,0,1,10,1);
           foreach(var i in result)
           {
               WriteLine("x="+i.Key+"   "+"y="+i.Value);
           }
        }
        public static double testfunc(double x, double y)
        {
            return y-2*x/y;
        } 
    }
    public static class EulerMethod
    {
        public static Dictionary<double,double> EulerCal(Func<double,double,double> f,double a,double b,int n,double y0)
        {
            Dictionary<double,double> result =new Dictionary<double,double>();
            double y=y0;
            double x=a;
            result.Add(x,y);
            double h=(b-a)/n;
            for(int i=0;i<n;i++)
            {
                y=y+h*f(x,y);
                x=x+h;
                result.Add(x,y);
                
            }
            return result;
        }
    }
}
