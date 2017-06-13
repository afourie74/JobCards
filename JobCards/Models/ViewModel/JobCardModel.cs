using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using JobCards.Models.Validation;
using JobCards.Models.EntityManager;

namespace JobCards.Models.ViewModel
{
    public class JobCardView
    {
        [Key]
        [Display(Name = "Job Number")]
        public int JobCardID { get; set; }
        [Required(ErrorMessage ="Required")]
        [Display(Name = "Customer")]
        public Guid? CustomerID { get; set; }
        public List<CustomerView> Customers { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Designer")]
        public Guid? DesignerID { get; set; }
        public List<DesignerView> Designers { get; set; }
        public string Description { get; set; }
        [JobsPerDate(4)]
        [DataType(DataType.Date)]
        [Display(Name = "Job Date")]
        public DateTime JobDate { get; set; }
        public string JobDateString { get { return JobDate.ToShortDateString(); } }
        [Display(Name = "Quote Ref.")]
        public string QuoteRef { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Job Type")]
        public Guid? JobTypeID { get; set; }
        public List<JobTypeView> JobTypes { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Material")]
        public Guid? MaterialID { get; set; }
        public List<MaterialView> Materials { get; set; }
        [Display(Name = "Is Deleted")]
        public TaskStep TaskStep { get; set; }  
        public List<UserView> Users { get; set; }
        [Display(Name = "Created by")]    
        public int? CreatedID { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "UV Printed by")]
        public int? UVPrinterID { get; set; }
        [Display(Name = "UV Printed Date")]
        public DateTime? UVPrintedDate { get; set; }
        [Display(Name = "Application by")]
        public int? ApplicationID { get; set; }
        public DateTime? ApplicationDate { get; set; }
        [Display(Name = "Clading by")]
        public int? CladingID { get; set; }
        public DateTime? CladingDate { get; set; }
        [Display(Name = "Installation by")]
        public int? InstallID { get; set; }
        public DateTime? InstallDate { get; set; }
        [Display(Name = "Invoiced by")]
        public int? InvoiceID { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public bool IsDeleted { get; set; }

        public JobCardView()
        {
            Customers = new List<CustomerView>();
            Designers = new List<DesignerView>();
            JobTypes = new List<JobTypeView>();
            Materials = new List<MaterialView>();
            Users = new List<UserView>();
        }
    }

    public class JobCardAdminView
    {
        [Key]
        [Display(Name = "Job Number")]
        public int JobCardID { get; set; }
        [Required(ErrorMessage = "Required")]
        [Display(Name = "Customer")]
        public Guid? CustomerID { get; set; }
        public List<CustomerView> Customers { get; set; }
        [Display(Name = "Designer")]
        public Guid? DesignerID { get; set; }
        public List<DesignerView> Designers { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Job Date")]
        public DateTime JobDate { get; set; }
        public string JobDateString { get { return JobDate.ToShortDateString(); } }
        [Display(Name = "Quote Ref.")]
        public string QuoteRef { get; set; }
        [Display(Name = "Job Type")]
        public Guid? JobTypeID { get; set; }
        public List<JobTypeView> JobTypes { get; set; }
        [Display(Name = "Material")]
        public Guid? MaterialID { get; set; }
        public List<MaterialView> Materials { get; set; }
        [Display(Name = "Is Deleted")]
        public TaskStep TaskStep { get; set; }
        public List<UserView> Users { get; set; }
        [Display(Name = "Created by")]
        public int? CreatedID { get; set; }
        [Display(Name = "Created Date")]
        public DateTime? CreatedDate { get; set; }
        [Display(Name = "UV Printed by")]
        public int? UVPrinterID { get; set; }
        [Display(Name = "UV Printed Date")]
        public DateTime? UVPrintedDate { get; set; }
        [Display(Name = "Application by")]
        public int? ApplicationID { get; set; }
        public DateTime? ApplicationDate { get; set; }
        [Display(Name = "Clading by")]
        public int? CladingID { get; set; }
        public DateTime? CladingDate { get; set; }
        [Display(Name = "Installation by")]
        public int? InstallID { get; set; }
        public DateTime? InstallDate { get; set; }
        [Display(Name = "Invoiced by")]
        public int? InvoiceID { get; set; }
        public DateTime? InvoiceDate { get; set; }

        public bool IsDeleted { get; set; }

        public JobCardAdminView()
        {
            Customers = new List<CustomerView>();
            Designers = new List<DesignerView>();
            JobTypes = new List<JobTypeView>();
            Materials = new List<MaterialView>();
            Users = new List<UserView>();
        }
    }

    public enum TaskStep
    {
        Created = 0,
        UVPrint,
        Application,
        Clading,
        Install,
        Invoice
    }
}