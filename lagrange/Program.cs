using System;
using System.Data;
using static lagrange.Method;
//拉格朗日插值 P130 ，T2
namespace lagrange
{
 
    class Program
    {
        
        //采用方法组的形式增强后续复用性
        //牛顿插值方法也可以直接在这里统一调用，还可以增加其他任意的插值方法，调用方式一样
        public static double Interpolation(double[] x,double[]y,int n,double x0 ,Func<double[],double[],int,double,double> method)
        {
            return method(x,y,n,x0);
        }
        static void Main(string[] args)
        {
            double x0=3;//插值点
            double[] x=new double[4]{0,1,2,3};
            double[] y=new double[4]{1,3,9,25};
            int n=3;
            //初始化值
            Console.WriteLine(Interpolation(x,y,n,x0,LagrangeInter));
            
        }
    }
}
