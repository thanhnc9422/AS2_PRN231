using System;
using System.Collections.Generic;

namespace BusinessObject.Model
{
    public partial class Book
    {
        public Book()
        {
            BookAuthors = new HashSet<BookAuthor>();
        }

        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? Type { get; set; }
        public int? PubId { get; set; }
        public int? Price { get; set; }
        public string? Advance { get; set; }
        public int? Royalty { get; set; }
        public int? YtdSale { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }

        public virtual Publisher? Pub { get; set; }
        public virtual ICollection<BookAuthor> BookAuthors { get; set; }
    }
}
