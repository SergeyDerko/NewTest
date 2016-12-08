
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gipotenuza
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Веедите длину катета А");
            double A = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите катет B");
            double B = double.Parse(Console.ReadLine());
            A *= A;
            B *= B;
            double C = Math.Sqrt(A + B);
            Console.WriteLine("Гипотенуза равна - {0}", C);
            Console.Read();

        }
    }
}
