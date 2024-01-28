using BusinessObject.Model;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public class BookRepository : IBookRepositiory
    {
        private BookDAO bookDAO = new BookDAO();
        public void createBook(Book book)
        {
            bookDAO.createBook(book);
        }

        public void deleteBook(int id)
        {
            bookDAO.deleteBook(id);
        }

        public List<Book> listBook()
        {
           return bookDAO.listBook();
        }

        public void updateBook(Book book)
        {
            bookDAO.updateBook(book);
        }
    }
}
