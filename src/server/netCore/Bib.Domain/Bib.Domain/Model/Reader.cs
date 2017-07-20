using System;
using System.Collections.Generic;

namespace Bib.Domain.Bib_Domain.Model
{
    public partial class Reader
    {
        public Reader()
        {
            Borrow = new HashSet<Borrow>();
        }

        public long Id { get; set; }
        public string CardId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public long? IsActive { get; set; }

        public virtual ICollection<Borrow> Borrow { get; set; }
    }
}
