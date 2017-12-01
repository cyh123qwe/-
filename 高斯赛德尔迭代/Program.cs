using System;
using System.Linq;
using System.Data;
using static System.Console;
using static System.Math;

namespace jaccobi
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");
            double [,] a=new double[3,3]{{5,-2,1},{1,5,-3},{2,1,-5}};
            double[] b=new double[3]{4,2,-11};
            double[] x=new double[3]{0,0,0};
            //矩阵初始化
            while(true)
            {
                double x1,x2,x3;
                x1=x[0];x2=x[1];x3=x[2];
                x[0]=1/a[0,0]*(b[0]-a[0,1]*x[1]-a[0,2]*x[2]);
                x[1]=1/a[1,1]*(b[1]-a[1,0]*x[0]-a[1,2]*x[2]);
                x[2]=1/a[2,2]*(b[2]-a[2,0]*x[0]-a[2,1]*x[1]);
                double[] var=new double[3];
                var[0] = x[0] - x1;
                var[1] = x[1] - x2;
                var[2] = x[2] - x3;
                if (Abs(var.Max()) < 0.5e-3)
                {
                    break;
                }
                
            }
            foreach(var i in x)
            Console.WriteLine(i);
        }
        
    }
}
