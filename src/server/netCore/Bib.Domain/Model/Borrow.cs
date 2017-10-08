using System;
using System.Collections.Generic;

namespace Bib.Domain.Model
{
    public partial class Borrow
    {
        public long Id { get; set; }
        public long ReaderId { get; set; }
        public long MediumId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public virtual Medium Medium { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
