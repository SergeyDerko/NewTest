using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Korobka
{
    class Painting
    {
        public Painting() { }
        public int Length { get; } // вводим метод подсчета символов в строке
 
     
       public void paint (int x, int y, char a, string z) // обьявляем метод
            {
            
            int Ots = z.Length + 4; //вводим переменную для подсчёта длины сообщения + 2 пробела и 2 символа.(логика описанна дальше)

            if (x-1<Ots) // ставим затычку - если сообщение слишком длинное чтобы влезть в прямоугольник - завершаем программу и выводим сообщение 
            {
                Console.WriteLine("вы ввели слишком длинную строку!");
                goto Fin; // перемещаемся в конец игноря программу.
            }

            int s;
            int Li = 30; // обозначаем начальную позицию курсора по оси Х
            int Hi = 5; // --//-- по оси У


            Console.SetCursorPosition(Li, Hi); // устанавливаем курсор по позиции
            for ( s =0; s<x; s++) // отрисовуем верхнюю линию
            {  
                Console.Write(a);
            }
            Console.WriteLine(); // делаем отступ


            s = s - 2;
            for (int d = 0; d < y; d++) // опредиляем значение У и начинаем рисование в каждой строчке
            {
                Hi++; // опускаем курсор по Y при каждой итерации 
                Console.SetCursorPosition(Li, Hi); // Устанавливаем курсор, для каждой новой строчки
                Console.Write(a); // каждую строку начинаем символом

                if ((d * 2) + 2 == y) // делаем проверку по типу - если это середина коробки - вставь сообщение
                {
                    Console.ForegroundColor = ConsoleColor.Green; // меняем цвет сообщения
                    Console.Write(" "+z+ " "); // выводим сообщение (перед ним символ + пробел + сообщение + количество отступов + символ)
                    Console.ForegroundColor = ConsoleColor.White; // возвращаем исходный цвет :)

                    if (Ots < x)
                    {
                        int h = Ots;
                        for (h = Ots; h<x; h++) // запускаем подсчёт отступов
                        {  
                            Console.Write(" ");// собственно рисуем отступы
                        }
                        goto you; // по завершению рисования отступов - переходим к строке которая рисует символ
                    }
                    
                }
                else if (d * 2 == y - 1) // а это таже проверка, но для нечётных значений У (если ее не ввести, то при нечётном У сообщение не выводится). Логика ниже таже :)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(" " +z+ " ");
                    Console.ForegroundColor = ConsoleColor.White;

                    if (Ots < x)
                    {
                        int h = Ots;
                        for (h = Ots; h < x; h++)
                        {
                            Console.Write(" ");
                        }
                        goto you;
                    }
                    
                }


                for (int f = 0; f < s; f++) // прорисовываем отступы в каждой строке (S - 2 - другими словами ищим количество отступов по значению Х - 2, ибо 2 символа ставим в начале и конце :))
                {
                    Console.Write(" "); // рисуем отступы
                }
                you:  Console.Write(a);
                Console.WriteLine(); // перемещаем курсор вниз (ибо Write гадкий, и оставляет курсор в конце строчки :) )
                
            }
            Console.SetCursorPosition(Li, Hi); // ставим курсор в нужное место


            for (s = 0; s < x; s++) // отрисовываем нижнюю линию
            { 
                Console.Write(a);
            }
            
            Console.SetCursorPosition(Li, Hi+3);
        Fin: Console.WriteLine( "Конец рисования :)");


        }
    }
}

