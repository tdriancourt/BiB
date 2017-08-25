using System.Collections.Generic;

namespace Bib.Services.ViewModels
{
    public class MediumViewModel
    {
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

        public virtual ICollection<BorrowViewModel> Borrow { get; set; }
        public virtual MediaTypeViewModel TypeNavigation { get; set; }
    }
}