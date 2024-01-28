using BusinessObject.Model;

namespace DataAccess.DAO
{
    internal class AuthorDAO
    {
        readonly PRN231_AS2Context _context = new PRN231_AS2Context();
        public AuthorDAO() { }
        public AuthorDAO(PRN231_AS2Context context)
        {
            _context = context;
        }
        public void createAuthor(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
        }

        public void deleteAuthor(int id)
        {
            Author author = _context.Authors.FirstOrDefault(x => x.AuthorId == id);
            if (author != null)
            {
                _context.Remove(author);
                _context.SaveChanges();
            }
        }

        public List<Author> listAuthor()
        {
            return _context.Authors.ToList();
        }

        public void updateAuthor(Author author)
        {
            Author a = _context.Authors.SingleOrDefault(x => x.AuthorId == author.AuthorId);
            if (a != null)
            {
                a.LastName = author.LastName;
                a.FirstName = author.FirstName;
                a.Phone = author.Phone;
                a.Address = author.Address;
                a.City = author.City;
                a.State = author.State;
                a.Zip = author.Zip;
                a.EmailAddress = author.EmailAddress;
                _context.Update(a);
                _context.SaveChanges();
            }
        }

    }

}
