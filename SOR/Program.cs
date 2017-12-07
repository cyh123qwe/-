using System;
using System.Linq;
using System.Data;
using static System.Console;
using static System.Math;
//本程序为超松弛迭代具体为P91T2
namespace jaccobi
{
    class Program
    {
        static void Main(string[] args)
        {
            //p91,t2
            //Console.WriteLine("Hello World!");
            double [,] a=new double[3,3]{{4,3,0},{3,4,-1},{0,-1,4}};
            double[] b=new double[3]{16,20,-12};
            double[] x=new double[3]{0,0,0};
            double omega=1.24;
            //矩阵初始化
            while(true)
            {
                double x1,x2,x3;
                x1=x[0];x2=x[1];x3=x[2];
                x[0]=omega/a[0,0]*(b[0]-a[0,0]*x1-a[0,1]*x2-a[0,2]*x3)+x1;//-a[0,2]*x3)+x1;
                x[1]=omega/a[1,1]*(b[1]-a[1,0]*x[0]-a[1,1]*x2-a[1,2]*x3)+x2;
                x[2]=omega/a[2,2]*(b[2]-a[2,0]*x[0]-a[2,1]*x[1]-a[2,2]*x3)+x3;
                double[] var=new double[3];
                var[0] = x[0] - x1;
                var[1] = x[1] - x2;
                var[2] = x[2] - x3;
                if (Abs(var.Max()) < 0.5e-4)
                {
                    break;
                }
                
            }
            foreach(var i in x)//输出语句
                Console.WriteLine(i);
        }
        
    }
}
