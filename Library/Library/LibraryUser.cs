using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    // 1) declare interface ILibraryUser
    // declare method's signature for methods of class LibraryUser



    // 2) declare class LibraryUser, it implements ILibraryUser
    public class LibraryUser : ILibraryUser
    {
        // 4) declare field (bookList) as a string array
        // Вводим событие
        public delegate void Return_books(string a);
        public event Return_books broom;

        public void return_books(string a)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(a);
        }

        private string[] BookList = new string[5];

        // 3) declare properties: FirstName (read only), LastName (read only), 
        // Id (read only), Phone (get and set), BookLimit (read only)
        public string First_Name;
        public string Last_Name;
        public string phone;
        public int Id;
        public int number_of_books = 0;
        public int BookLimit = 5;

        public string FirstName
        {
            get { return First_Name; }
            set { First_Name = value; }
        }
        public string LastName
        {
            get { return Last_Name; }
            set { Last_Name = value; }
        }
        public int id
        {
            get { return Id; }
            set { Id = value; }
        }
        public string Phone
        {
            get { return phone; }
            set { phone = value; }
        }
        // 5) declare indexer BookList for array bookList
        public string this[int i]
        {
            get { return BookList[i]; }
            set { BookList[i] = value; }
        }
        // 6) declare constructors: default and parameter
        public LibraryUser()
        {

        }
        public LibraryUser(string AddBook, string RemoveBook, string BookInfo, int BooksCount)
        {


        }

        // 7) declare methods: 

        //AddBook() – add new book to array bookList

        //RemoveBook() – remove book from array bookList

        //BookInfo() – returns book info by index

        //BooksCout() – returns current count of books

        public void AddBook(string add)
        {
            foreach (string Book in BookList)
            {
                if (number_of_books >= BookLimit)
                {
                    //Console.ForegroundColor = ConsoleColor.Red;
                    // Console.WriteLine(@"Вы взяли максимально допустимое количество книг! Что бы взять новые - сдайте ненужные книги обратно в библиотеку!!!
                    //НЕ ");
                    broom(@"Вы взяли максимально допустимое количество книг!Что бы взять новые - сдайте ненужные книги обратно в библиотеку!!!
                    НЕ");
                    break;
                }
                if (BookList[0] == null)
                {
                    BookList[0] = add;
                    number_of_books++;
                    break;
                }

                if (BookList[1] == null)
                {
                    BookList[1] = add;
                    number_of_books++;
                    break;
                }
                if (BookList[2] == null)
                {
                    BookList[2] = add;
                    number_of_books++;
                    break;
                }
                if (BookList[3] == null)
                {
                    BookList[3] = add;
                    number_of_books++;
                    break;
                }
                if (BookList[4] == null)
                {
                    BookList[4] = add;
                    number_of_books++;
                    break;
                }
            }

        }

        public void RemoveBook(string remove)
        {
            foreach (string Book in BookList)
            {
                if (BookList[0] == remove)
                {
                    BookList[0] = null;
                    number_of_books--;
                    break;
                }

                if (BookList[1] == remove)
                {
                    BookList[1] = null;
                    number_of_books--;
                    break;
                }
                if (BookList[2] == remove)
                {
                    BookList[2] = null;
                    number_of_books--;
                    break;
                }
                if (BookList[3] == remove)
                {
                    BookList[3] = null;
                    number_of_books--;
                    break;
                }
                if (BookList[4] == remove)
                {
                    BookList[4] = null;
                    number_of_books--;
                    break;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(@"Такой книги нет у пользователя! Посмотрите какие у него есть книги!!!
Вы НЕ");
                }
                break;
            }
        }

        public void BookInfo()
        {
            int r = 0;
            foreach (string Book in BookList)
            {
                if (BookList[0] != null)
                {
                    r++;
                }

                if (BookList[1] != null)
                {
                    r++;
                }
                if (BookList[2] != null)
                {
                    r++;
                }
                if (BookList[3] != null)
                {
                    r++;
                }
                if (BookList[4] != null)
                {
                    r++;
                }
                break;
            }
            if (r == 0)
            {
                Console.WriteLine("У пользователя нет книг! Он тупеет на глазах! Срочно читать!!!  :) ");
            }
            else
                Console.WriteLine("У пользователя есть -  " + BookList[0] + "  " + BookList[1] + "  " + BookList[2] + "  " + BookList[3] + "  " + BookList[4]);
        }

        public void BooksCount()
        {
            int n = 0;
            foreach (string book in BookList)
            {
                /*if (string.IsNullOrEmpty(book))
                {
                    n++;
                }
                if (book != null)
                { 

                }*/
                if (BookList[0] != null)
                {
                    n++;
                }

                if (BookList[1] != null)
                {
                    n++;
                }
                if (BookList[2] != null)
                {
                    n++;
                }
                if (BookList[3] != null)
                {
                    n++;
                }
                if (BookList[4] != null)
                {
                    n++;
                }
                break;
            }

            Console.WriteLine(" Колличество книг у пользователя  - " + n);

        }
    }

}
