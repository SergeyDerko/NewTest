using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korobka
{
    class Program
    {
        static void Main(string[] args)
        {
            ///создаем класс 
            ///вызываем метод и вводим любые значения :) 
            ///Тестим что вышло!
            
            Painting Paint = new Painting();
            Paint.paint(40,20, '$', "Привет! хрень на экране! :)");
            Console.Read();
        }
    }
}
