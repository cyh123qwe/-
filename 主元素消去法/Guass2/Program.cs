using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Math;

namespace Guass2
{
    class Program
    {
        //主元素消去法
        static void Main(string[] args)
        {
            double eps = 1e-5;
            double[,] a = new double[3, 4] { { 2, 1, 3, 7 }, { 1, 1, 1, 4 } , { 3, 1, 6, 2 } };
            double[,] l = new double[3, 4];
            //首先将矩阵整成主元形式
            
            double[] rank = new double[3] { 1, 2, 3 };//用于记录行的交换情况
            //for (int i = 0; i < 2; i++)
            //{
            //    ChangeCol(a, rank, FindMax(i, a), i);
            //    for(int k=i)
            //    for (int j = i; j < 4; j++)
            //    {
                    
            //       // ChangeCol(a, rank, FindMax(i, a), i);
            //        a[i + 1, j] = a[i + 1, j] - a[i + 1, i] / a[i, i] * a[i, j];
            //    }
            //}
            for (int k = 0; k < 2; k++)
            {
                ChangeCol(a, rank, FindMax(k, a), k);
                for (int i = k + 1; i < 3; i++)
                {
                    l[i, k] = a[i, k] / a[k, k];
                    for (int j = k + 1; j < 4; j++)
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
            Console.ReadKey();


        }
        //交换第i行与第j行的函数，并且交换过程保留在了rank矩阵中,由于实际上换行不影响未知数的顺序
        //所以此处rank矩阵多余了，但是可以用在全主元中.
        public static void ChangeCol(double[,] a,double[] rank,int i,int j)
        {
            for (int row = 0; row < a.GetLength(1); row++) 
            {

                //double temp;
                //temp = a[i,row];
                //a[j, row] = a[i, row];
                swap(ref a[i, row], ref a[j, row]);
                
            }
            swap(ref rank[i], ref rank[j]);
        }
        public static void swap(ref double  a, ref double b)
        {
            double temp;
            temp = a;
            a = b;
            b = temp;
        }
        public static int FindMax(int m, double[,] a)
        {
            List<double> temp = new List<double>();//用于存放一列 
                for (int i = m; i <a.GetLength(0); i++)
                {
                    temp.Add(a[i, m]);
                }
              
            return temp.IndexOf(temp.Max())+m;
        }
    }
}
