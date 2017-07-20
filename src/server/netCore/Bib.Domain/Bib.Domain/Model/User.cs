using System;
using System.Collections.Generic;

namespace Bib.Domain.Bib_Domain.Model
{
    public partial class User
    {
        public User()
        {
            UserSettings = new HashSet<UserSettings>();
        }

        public long Id { get; set; }
        public long? GroupId { get; set; }
        public long? AclId { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public long IsActive { get; set; }

        public virtual ICollection<UserSettings> UserSettings { get; set; }
        public virtual Acl Acl { get; set; }
        public virtual UserGroup Group { get; set; }
    }
}
