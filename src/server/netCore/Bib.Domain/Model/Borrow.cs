using System;
using System.Collections.Generic;

namespace Bib.Domain.Model
{
    public partial class Borrow
    {
        public long Id { get; set; }
        public long ReaderId { get; set; }
        public long MediumId { get; set; }
        public string BorrowDate { get; set; }
        public string ReturnDate { get; set; }

        public virtual Medium Medium { get; set; }
        public virtual Reader Reader { get; set; }
    }
}
