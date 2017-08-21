using System.Collections.Generic;

namespace Bib.Services.ViewModels
{
    public class AclViewModel
    {
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

        public virtual IEnumerable<UserViewModel> User { get; set; }

        public virtual ICollection<UserGroupViewModel> UserGroup { get; set; }
    }
}