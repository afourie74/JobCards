using System;
using System.ComponentModel.DataAnnotations;

namespace JobCards.Models.ViewModel
{
    public class CustomerView
    {
        [Key]
        public Guid CustomerID { get; set; }
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }
        public bool IsDeleted { get; set; }
    }
}