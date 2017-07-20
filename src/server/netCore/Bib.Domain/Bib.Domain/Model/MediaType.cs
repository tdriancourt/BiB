using System;
using System.Collections.Generic;

namespace Bib.Domain.Bib_Domain.Model
{
    public partial class MediaType
    {
        public MediaType()
        {
            Medium = new HashSet<Medium>();
        }

        public long Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Medium> Medium { get; set; }
    }
}
