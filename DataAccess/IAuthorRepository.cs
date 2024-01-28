using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    internal interface IAuthorRepository
    {
        void deleteAuthor(int id);
        void updateAuthor(Author author);
        void createAuthor(Author author);
        List<Author> listAuthor();
    }
}
