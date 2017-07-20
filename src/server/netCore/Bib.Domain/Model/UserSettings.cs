using System;
using System.Collections.Generic;

namespace Bib.Domain.Model
{
    public partial class UserSettings
    {
        public long Id { get; set; }
        public long UserId { get; set; }
        public string Language { get; set; }
        public string DateTimeFormat { get; set; }
        public long IsActive { get; set; }

        public virtual User User { get; set; }
    }
}
