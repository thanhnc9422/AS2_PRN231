using BusinessObject.Model;
using DataAccess.DAO;

namespace DataAccess.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AuthorDAO authorDAO = new AuthorDAO();
        public void createAuthor(Author author)
        {
            authorDAO.createAuthor(author);
        }

        public void deleteAuthor(int id)
        {
            authorDAO.deleteAuthor(id);
        }

        public List<Author> listAuthor()
        {
            return authorDAO.listAuthor();
        }

        public void updateAuthor(Author author)
        {
            authorDAO.updateAuthor(author);
        }
    }
}
