using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Guass
{
    //顺序消去法
    class Program
    {
        //public double[,] a = new double[3, 4];
        static void Main(string[] args)
        {
            //消元过程
            double[,] a = new double[3, 4] { { 2,3,4,6 },{ 3, 5, 2, 5 },{ 4, 3, 30, 32 } };
            double[,] l = new double[3, 4];
            for(int k=0;k<2;k++)
            { for (int i = k + 1; i < 3; i++)
                {
                    l[i, k] = a[i, k] / a[k, k];
                    for (int j = k + 1; j < 4;j++)
                    {
                        a[i, j] = a[i, j] - l[i, k] * a[k, j];
                    }
                }
            }
            //回带过程
            double[] x = new double[3];
            x[2] = a[2, 3] / a[2, 2];
            for (int i = 1; i >= 0; i--)
            {
                double s = 0;
                for (int j = i + 1; j < 3; j++)
                {
                    s = s + a[i, j] * x[j];
                    x[i] = (a[i, 3] - s) / a[i, i];
                }
            }
            //输出
            foreach (var i in x)
            { Console.WriteLine(i); }
        }
    }
}
