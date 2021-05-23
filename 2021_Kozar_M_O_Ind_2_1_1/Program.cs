using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_Kozar_M_O_Ind_2_1_1
{
    class Program
    {
        public static double GetFunctionValueconst(double x, double eps, out int args)
        {
            if (Math.Abs(x) >= 1) throw new ArgumentException("Absolute value of X should be less than 1");
            double comp;
            double sum = 0;
            int n = 0;
            do
            {
                comp = ((Math.Pow(-1, n + 1)) * (Math.Pow(x, 2 * n + 1))) / (2 * n + 1);
                sum += comp;
                n++;
            } while (Math.Abs(comp) > eps);
            args = n;
            return Math.PI / 2 + sum;
        }
        public static double GetSeriesValue(double a, double b, double c, double f)
        {

            if ((f < 5) && (c != 0))
            {
                return (-a * f * f - b);
            }
            if ((f > 5) && (c == 0))
            {
                return ((f - a) / f);
            }
            if ((f == 0) && (c == 0))
            {
                return (-(f / c));
            }
        }
        public static void Main(string[] args)
        {
            int countforFunc = -1, countForGets = -1;
            object[] arrforFunc = new object[81];
            object[] arrforGets = new object[81];
            double a, b, c, xn, xk, f, x;
            double dx = 0.1;
            double eps = 0.001;
            Console.Write("a=");
            a = double.Parse(Console.ReadLine());
            Console.Write("b=");
            b = double.Parse(Console.ReadLine());
            Console.Write("c=");
            c = double.Parse(Console.ReadLine());
            Console.Write("xn=");
            xn = double.Parse(Console.ReadLine());
            Console.Write("xk=");
            xk = double.Parse(Console.ReadLine());
            Console.Write("x=");
            x = double.Parse(Console.ReadLine());
            f = x;
            for (f = xn; xk >= f; f += dx)
            {

                countforFunc++;
                arrforFunc[countforFunc] = GetSeriesValue(a, b, c, f);
                arrforFunc[countforFunc] = (double)arrforFunc[0] + countforFunc * dx;
                Console.WriteLine("|{1}| element = {0}", arrforFunc[countforFunc], countforFunc);

            }
            Console.WriteLine();

            for (a = -0.9; a <= 0.9; a += 0.1)
            {
                countForGets++;
                arrforGets[countForGets] = GetFunctionValueconst(x, eps);
                arrforGets[countForGets] = (double)arrforGets[0] + (countForGets * dx);
                Console.WriteLine("{1} element =|{0}|", arrforGets[countForGets], countForGets);

            }

            Console.ReadKey(true);
        }
    }


}
