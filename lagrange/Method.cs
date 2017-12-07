using System;
using System.Data;
using System.Linq;
using static System.Math;
using static System.Console;
namespace lagrange
{
       public static class Method
    {
        public delegate double InterpolationMethod(double[]x,double[]y,int n,double x0);
        public static double LagrangeInter(double[] x,double[] y,int n,double x0)//用于计算插值多项式
        {
            //double result;
            double L=0;
           // int j=0;
            //q=(x0-x[i])/(x[j]-x[i])*q;
            for(int j=0;j<n+1;j++)
            {
                double q=1;
                for(int i=0;i<n+1;i++)
                {
                    if(j!=i)
                    {
                        q=(x0-x[i])/(x[j]-x[i])*q;
                        
                    }

                }
                L=L+q*y[j];
            }
            return L;
        }
    }
}