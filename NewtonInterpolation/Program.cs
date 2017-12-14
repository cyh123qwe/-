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
            //初始化x
            /* 
            double[] x=new double[10];
            for(int i =0;i<10;i++)
            {
                x[i]=1.0/(i+1);
            }
            //计算差商
            List<List<double>> table= Newton.TableCal(f,x,false);
            foreach(var i in table)
            Console.WriteLine(i);
            */
            
            double[] x=new double[4]{-1,0,1,3};
            double[] y=new double[4]{1,-1,-1,29};
            List<List<double>> table=Newton.TableCal(y,x,false);
            Console.ReadKey();
            
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
        //在默认情况下计算差分表。d参数输入false计算差商表
        public static List<List<double>> TableCal(Func<double,double> f,double[] x,bool d=true)
        {
            List<double> y= x.ToList();
            y=y.Select(e=>e=f(e)).ToList();//计算初始值
            if(d)
            return InnerCal(y,x.ToList(),diff);//差分情况
            else
            return InnerCal(y,x.ToList(),difq);//差商情况
        }
        public static List<List<double>> TableCal(double[] y,double[] x,bool d=true)
        {
            if(d)
            return InnerCal(y.ToList(),x.ToList(),diff);//差分情况
            else
            return InnerCal(y.ToList(),x.ToList(),difq);//差商情况
        }
        //计算各阶差商，两个list嵌套封装成一个类会好一点
        private static List<List<double>> InnerCal(List<double> y,List<double> x,Func<int,int,List<double>,List<double>,double> dif)
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
                    //计算差分
                    //double t=result.Last()[i]-result.Last()[i-1];
                    //计算差商
                    int j=result.Count();
                    double t=dif(i,j,result.Last(),x);
                    //double t=(result.Last()[i]-result.Last()[i-1])/(x[i]-x[i-(j-1)]);
                    temp.Add(t);
                }
                result.Add(temp);
            }
            return result;
        }
        //用于差商的函数
        public static double difq(int i,int j,List<double> Last,List<double> x)
        {
            return (Last[i]-Last[i-1])/(x[i+j-1]-x[i-1]);
        }
        //用于差分
        public static double diff(int i,int j,List<double> Last,List<double> x)
        {
            return Last[i]-Last[i-1];
        }
    }
}
