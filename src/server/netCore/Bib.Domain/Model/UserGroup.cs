using System;
using System.Collections.Generic;

namespace Bib.Domain.Model
{
    public partial class UserGroup
    {
        public UserGroup()
        {
            User = new HashSet<User>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long AclId { get; set; }

        public virtual ICollection<User> User { get; set; }
        public virtual Acl Acl { get; set; }
    }
}
