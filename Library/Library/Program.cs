using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{

    class Program
    {
        static void Main(string[] args)
        {
            // 8) declare 2 objects. Use default and paremeter constructors
            LibraryUser user1 = new LibraryUser(), user2 = new LibraryUser("Sergey", "Derko", "+380447777777", 2);
            user1.FirstName = "Дарья";
            user1.LastName = "Лауэрта";
            user1.Phone = "+380446666666";
            user1.id = 1;
            user2.FirstName = "Алексей";
            user2.LastName = "Беляков";
            user2.Phone = "+380447777777";
            user2.id = 2;
            user1.broom += user1.return_books;
            user2.broom += user2.return_books;

            int q;
            try
            {
                do
                {
                    Console.WriteLine(@"         Пожалуйста, выберите пользователя библиотеки (Введите цифру 1 или 2)
                            1. USER 1
                            2. USER2");
                    try
                    {
                        q = int.Parse(Console.ReadLine());
                        switch (q)
                        {
                            case 1:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Имя пользователя  " + user1.FirstName + "  " + user1.LastName +
                                    "  тел.  " + user1.Phone + "  её iD - " + user1.id);
                                int a;
                                try
                                {
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(@"                            Что вы хотите от этого пользователя? :) (Введите цифру 1 - 4)
                            1. Добавить ему книгу
                            2. Вернуть книгу в библиотеку
                            3. Просмотреть какие есть книги у пользователя
                            4. Посмотреть сколько книг есть у пользователя");
                                        try
                                        {
                                            a = int.Parse(Console.ReadLine());
                                            switch (a)
                                            {
                                                case 1:

                                                    Console.WriteLine("Введите название книги");
                                                    string w = Console.ReadLine();
                                                    user1.AddBook(w);
                                                    Console.WriteLine("добавленна в сумочку книга -  " + w);
                                                    break;
                                                case 2:

                                                    Console.WriteLine("Введите название книги которую хотите вернуть в библиотеку");
                                                    string e = Console.ReadLine();
                                                    user1.RemoveBook(e);
                                                    Console.WriteLine("вернули книгу -  " + e);
                                                    break;
                                                case 3:

                                                    user1.BookInfo();
                                                    break;
                                                case 4:

                                                    user1.BooksCount();
                                                    // var count = user1.BooksCount();
                                                    //user1.BooksCount = count;
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы не выбрали пользователя");
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Внимательно смотрите условия ввода в консоль!!!");
                                        }
                                        finally
                                        {

                                        }

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine(@" Для выхода в основное меню жми - ПРОБЕЛ;
 Для просмотра/изменения книг у этого пользователя - жмите что угодно :)
                                                                       ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            case 2:

                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("Имя пользователя  " + user2.FirstName + "  " + user2.LastName +
                                    "  тел.  " + user2.Phone + "  его iD - " + user2.id);
                                int b;
                                try
                                {
                                    do
                                    {
                                        Console.ForegroundColor = ConsoleColor.White;
                                        Console.WriteLine(@"                            Что вы хотите от этого пользователя? :) (Введите цифру 1 - 4)
                            1. Добавить ему книгу
                            2. Вернуть книгу в библиотеку
                            3. Просмотреть какие есть книги у пользователя
                            4. Посмотреть сколько книг есть у пользователя");
                                        try
                                        {
                                            b = int.Parse(Console.ReadLine());
                                            switch (b)
                                            {
                                                case 1:

                                                    Console.WriteLine("Введите название книги");
                                                    string w = Console.ReadLine();
                                                    user2.AddBook(w);
                                                    Console.WriteLine("добавленна в сумочку книга -  " + w);
                                                    break;
                                                case 2:

                                                    Console.WriteLine("Введите название книги которую хотите вернуть в библиотеку");
                                                    string e = Console.ReadLine();
                                                    user2.RemoveBook(e);
                                                    Console.WriteLine("вернули книгу -  " + e);
                                                    break;
                                                case 3:

                                                    user2.BookInfo();
                                                    break;
                                                case 4:

                                                    user2.BooksCount();
                                                    break;
                                                default:
                                                    Console.WriteLine("Вы не выбрали пользователя");
                                                    break;
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            Console.WriteLine("Внимательно смотрите условия ввода в консоль!!!");
                                        }
                                        finally
                                        {

                                        }

                                        Console.ForegroundColor = ConsoleColor.Cyan;
                                        Console.WriteLine(@" Для выхода в основное меню жми - ПРОБЕЛ;
 Для просмотра/изменения книг у этого пользователя - жмите что угодно :)
                                                                     ");
                                        Console.ForegroundColor = ConsoleColor.White;
                                    }
                                    while (Console.ReadKey().Key != ConsoleKey.Spacebar);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex.Message);
                                }
                                break;
                            default:
                                Console.WriteLine("Вы не выбрали пользователя");
                                break;
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Внимательно смотрите условия ввода в консоль!!!");
                    }
                    finally
                    {

                    }

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine(@"Завершить работу - жми ПРОБЕЛ;
 Если хотите выбрать другого пользователя - введите что угодно :)");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                while (Console.ReadKey().Key != ConsoleKey.Spacebar);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }


    }
}
