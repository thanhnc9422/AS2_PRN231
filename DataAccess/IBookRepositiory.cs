using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IBookRepositiory
    {
        void deleteBook(int id);
        void updateBook(Book book);
        void createBook(Book book);
        List<Book> listBook();

    }
}
