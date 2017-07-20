using System;
using System.Collections.Generic;

namespace Bib.Domain.Bib_Domain.Model
{
    public partial class Medium
    {
        public Medium()
        {
            Borrow = new HashSet<Borrow>();
        }

        public long Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Year { get; set; }
        public string Isbn { get; set; }
        public string Picture { get; set; }
        public long? Type { get; set; }
        public long? IsAvailable { get; set; }
        public long? IsDeleted { get; set; }
        public long? DevelopmentPlan { get; set; }

        public virtual ICollection<Borrow> Borrow { get; set; }
        public virtual MediaType TypeNavigation { get; set; }
    }
}
