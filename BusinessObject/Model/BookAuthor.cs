using System;
using System.Collections.Generic;

namespace BusinessObject.Model
{
    public partial class BookAuthor
    {
        public int AuthorId { get; set; }
        public int BookId { get; set; }
        public int? AuthorOrder { get; set; }
        public int? RoyaltyPercentage { get; set; }

        public virtual Author Author { get; set; } = null!;
        public virtual Book Book { get; set; } = null!;
    }
}
