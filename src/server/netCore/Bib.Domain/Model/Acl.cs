using System;
using System.Collections.Generic;

namespace Bib.Domain.Model
{
    public partial class Acl
    {
        public Acl()
        {
            User = new HashSet<User>();
            UserGroup = new HashSet<UserGroup>();
        }

        public long Id { get; set; }
        public long CanAddMedia { get; set; }
        public long CanAddReaders { get; set; }
        public long CanAddUsers { get; set; }
        public long CanAddUserGroups { get; set; }
        public long CanRemoveMedia { get; set; }
        public long CanRemoveReaders { get; set; }
        public long CanRemoveUsers { get; set; }
        public long CanRemoveUserGroups { get; set; }
        public long CanModifyMedia { get; set; }
        public long CanModifyReaders { get; set; }
        public long CanModifyUsers { get; set; }
        public long CanModifyUserGroups { get; set; }

        public virtual ICollection<User> User { get; set; }
        public virtual ICollection<UserGroup> UserGroup { get; set; }
    }
}
