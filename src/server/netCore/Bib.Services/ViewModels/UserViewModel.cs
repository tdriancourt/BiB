using System.ComponentModel.DataAnnotations;

namespace Bib.Services.ViewModels
{
    public class UserViewModel
    {
        public long Id { get; set; }
        public long? GroupId { get; set; }
        public long? AclId { get; set; }
        public string AccountName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public long IsActive { get; set; }
    }
}