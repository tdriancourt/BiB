using System.Collections.Generic;

namespace Bib.Services.ViewModels
{
    public class UserGroupViewModel
    {
         public long Id { get; set; }
        public string Name { get; set; }
        public long AclId { get; set; }

        public virtual IEnumerable<UserViewModel> User { get; set; }
        public virtual AclViewModel Acl { get; set; }
    }
}