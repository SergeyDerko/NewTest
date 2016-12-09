using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    interface ILibraryUser
    {
        void AddBook(string add);
        void RemoveBook(string remove);
        void BookInfo();
        void BooksCount();
    }
}
