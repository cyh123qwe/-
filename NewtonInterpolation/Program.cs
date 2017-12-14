using System;
using System.Linq;
using System.Collections.Generic;
using System.Data;
using System.Text;
using static System.Math;
namespace NewtonInterpolation
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            double[] x=new double[10];
            for(int i =0;i<10;i++)
            {
                x[i]=1.0/(i+1);
            }
            List<List<double>> table= Newton.TableCal(f,x);
        }
        static double f(double x)
        {
            return Pow(x,8)+5*Pow(x,7)-3*x-1;
        }
    }
    public static class Newton
    {
        public static double NewtonInterpolation(double[]x,double[]y,double x0,double n)
        {
            return 0;
        }
        //计算差商表的函数
        public static List<List<double>> TableCal(Func<double,double> f,double[] x)
        {
            List<double> y= x.ToList();
            y=y.Select(e=>e=f(e)).ToList();//计算初始值

            return InnerCal(y);
        }
        //计算各阶差分，两个list嵌套封装成一个类会好一点
        private static List<List<double>> InnerCal(List<double> y)
        {
            List<List<double>> result=new List<List<double>>();
            result.Add(y);
            while(true)
            {
                if(result.Last().Count()<=1)
                break;
                List<double> temp =new List<double>();
                for(int i =1;i<result.Last().Count();i++)
                {
                    double t=result.Last()[i]-result.Last()[i-1];
                    temp.Add(t);
                }
                result.Add(temp);
            }
            return result;
        }
    }
}
