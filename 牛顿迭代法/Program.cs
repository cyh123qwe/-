using System;
using System.IO;
using System.Text;
using System.Data;
using System.Linq;
using static System.Math;
namespace hwapp2
{
    class Program
    {
        static void Main(string[] args)
        {
           
            double x=1;
            while(true)
            {
                double x0=x;
                x=(2*Pow(x,3)+4*Pow(x,2)+10)/(3*Pow(x,2)+8*x);
                if(Abs(x-x0)<0.00001)
                {Console.WriteLine(x);break;}

            }
        }
    }
}
