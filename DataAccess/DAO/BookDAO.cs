using BusinessObject.Model;

namespace DataAccess.DAO
{
    internal class BookDAO
    {
        readonly PRN231_AS2Context _context = new PRN231_AS2Context();
        public BookDAO() { }
        public BookDAO(PRN231_AS2Context context)
        {
            _context = context;
        }
        public void createBook(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void deleteBook(int id)
        {
            Book b = _context.Books.FirstOrDefault(x => x.BookId == id);
            if (b != null)
            {
                _context.Books.Remove(b);
                _context.SaveChanges();
            }
        }

        public List<Book> listBook()
        {
            return _context.Books.ToList();
        }

        public void updateBook(Book book)
        {
            Book b = _context.Books.FirstOrDefault(x => x.BookId == book.BookId);
            if (b != null)
            {
                b.Title = book.Title;
                b.Type = book.Type;
                b.PubId = book.PubId;

                b.Price = book.Price;
                b.Advance = book.Advance;
                b.Royalty = book.Royalty;
                b.YtdSale = book.YtdSale;
                b.Notes = book.Notes;
                b.PublishedDate = book.PublishedDate;
                _context.Books.Update(b);
                _context.SaveChanges();
            }

        }
    }
}
