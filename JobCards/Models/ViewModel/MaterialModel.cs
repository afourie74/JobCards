using System;
using System.ComponentModel.DataAnnotations;

namespace JobCards.Models.ViewModel
{
    public class MaterialView
    {
        [Key]
        public Guid MaterialID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        [Display(Name = "Is Deleted")]
        public bool IsDeleted { get; set; }
    }
}