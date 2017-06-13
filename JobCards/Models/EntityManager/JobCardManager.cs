using JobCards.Models.Database;
using JobCards.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;

namespace JobCards.Models.EntityManager
{
    public class JobCardManager
    {
        public void CreateCustomer(CustomerView customer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbCustomer = new Customer
                {
                    ContactNumber = customer.ContactNumber,
                    CustomerID = Guid.NewGuid(),
                    Description = customer.Description,
                    IsDeleted = false,
                    Name = customer.Name
                };

                db.Customers.Add(dbCustomer);
                db.SaveChanges();
            }
        }

        public void CreateDesigner(DesignerView designer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbDesigner = new Designer
                {
                    ContactNumber = designer.ContactNumber,
                    DesignerID = Guid.NewGuid(),
                    Description = designer.Description,
                    IsDeleted = false,
                    Name = designer.Name
                };

                db.Designers.Add(dbDesigner);
                db.SaveChanges();
            }
        }

        public void CreateJobType(JobTypeView jobType)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbJobType = new JobType
                { 
                    JobTypeID = Guid.NewGuid(),
                    Description = jobType.Description,
                    IsDeleted = false,
                    Name = jobType.Name
                };

                db.JobTypes.Add(dbJobType);
                db.SaveChanges();
            }
        }

        public void CreateJobCard(JobCardView jobCard)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbJobCard = new JobCard
                {
                    CustomerID = (Guid)jobCard.CustomerID,
                    DesignerID = (Guid)jobCard.DesignerID,
                    IsDeleted = jobCard.IsDeleted,
                    JobCardID = jobCard.JobCardID,
                    JobDate = jobCard.JobDate,
                    JobTypeID = jobCard.JobTypeID,
                    MaterialID = jobCard.MaterialID,
                    QuoteRef = jobCard.QuoteRef,
                    CreatedID = jobCard.CreatedID,
                    CreatedDate = jobCard.CreatedDate,
                    Description = jobCard.Description
                };

                db.JobCards.Add(dbJobCard);
                db.SaveChanges();
            }
        }

        public void CreateJobCard(JobCardAdminView jobCard)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbJobCard = new JobCard
                {
                    CustomerID = (Guid)jobCard.CustomerID,
                    DesignerID = (Guid)jobCard.DesignerID,
                    IsDeleted = jobCard.IsDeleted,
                    JobCardID = jobCard.JobCardID,
                    JobDate = jobCard.JobDate,
                    JobTypeID = jobCard.JobTypeID,
                    MaterialID = jobCard.MaterialID,
                    QuoteRef = jobCard.QuoteRef,
                    CreatedID = jobCard.CreatedID,
                    CreatedDate = jobCard.CreatedDate,
                    Description = jobCard.Description
                };

                db.JobCards.Add(dbJobCard);
                db.SaveChanges();
            }
        }

        public void CreateMaterial(MaterialView material)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var dbMaterial = new Material
                {
                    MaterialID = Guid.NewGuid(),
                    Description = material.Description,
                    IsDeleted = false,
                    Name = material.Name
                };

                db.Materials.Add(dbMaterial);
                db.SaveChanges();
            }
        }

        public void DeleteCustomer(CustomerView customer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Customer customerDb = db.Customers.Single(x => x.CustomerID == customer.CustomerID);;
                customerDb.IsDeleted = true;

                db.SaveChanges();
            }
        }

        public void DeleteDesigner(DesignerView designer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Designer designerDb = db.Designers.Single(x => x.DesignerID == designer.DesignerID); ;
                designerDb.IsDeleted = true;

                db.SaveChanges();
            }
        }

        public void DeleteJobType(JobTypeView jobType)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                JobType jobTypeDb = db.JobTypes.Single(x => x.JobTypeID == jobType.JobTypeID); ;
                jobTypeDb.IsDeleted = true;

                db.SaveChanges();
            }
        }
        
        public void DeleteJobCard(JobCardView jobCard)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                JobCard jobCardDB = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                jobCardDB.IsDeleted = true;

                db.SaveChanges();
            }
        }

        public void DeleteMaterial(MaterialView material)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Material materialDB = db.Materials.Single(x => x.MaterialID == material.MaterialID);
                materialDB.IsDeleted = true;

                db.SaveChanges();
            }
        }

        public CustomerView GetCustomer(Guid id)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                var customer = db.Customers.SingleOrDefault(x => x.CustomerID == id && !x.IsDeleted);
                CustomerView result = new CustomerView()
                {
                    ContactNumber = customer.ContactNumber,
                    CustomerID = customer.CustomerID,
                    Description = customer.Description,
                    IsDeleted = customer.IsDeleted,
                    Name = customer.Name
                };

                return result;
            }
        }

        public DesignerView GetDesigner(Guid id)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                var designer = db.Designers.SingleOrDefault(x => x.DesignerID == id && !x.IsDeleted);
                DesignerView result = new DesignerView()
                {
                    ContactNumber = designer.ContactNumber,
                    DesignerID = designer.DesignerID,
                    Description = designer.Description,
                    IsDeleted = designer.IsDeleted,
                    Name = designer.Name
                };

                return result;
            }
        }

        public JobTypeView GetJobType(Guid id)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                var jobType = db.JobTypes.SingleOrDefault(x => x.JobTypeID == id && !x.IsDeleted);
                JobTypeView result = new JobTypeView()
                {
                    JobTypeID = jobType.JobTypeID,
                    Description = jobType.Description,
                    Name = jobType.Name
                };

                return result;
            }
        }

        public MaterialView GetMaterial(Guid id)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                var material = db.Materials.SingleOrDefault(x => x.MaterialID == id && !x.IsDeleted);
                MaterialView result = new MaterialView()
                {
                    MaterialID = material.MaterialID,
                    Description = material.Description,
                    Name = material.Name
                };

                return result;
            }
        }

        public List<CustomerView> GetAllCustomers(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<CustomerView> result = new List<CustomerView>();
                if (includeDeleted)
                {
                    db.Customers.ToList().ForEach(y => result.Add(GetViewModel(y)));
                }
                else
                {
                    db.Customers.Where(x => !x.IsDeleted).ToList().ForEach(y => result.Add(GetViewModel(y)));
                }

                return result;
            }
        }      

        public List<DesignerView> GetAllDesigners(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<DesignerView> result = new List<DesignerView>();
                if (includeDeleted)
                {
                    db.Designers.ToList().ForEach(y => result.Add(GetViewModel(y)));
                }
                else
                {
                    db.Designers.Where(x => !x.IsDeleted).ToList().ForEach(y => result.Add(GetViewModel(y)));
                }

                return result;
            }
        }

        public List<JobTypeView> GetAllJobTypes(bool incluideDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobTypeView> result = new List<JobTypeView>();
                if (incluideDeleted)
                {
                    db.JobTypes.ToList().ForEach(y => result.Add(GetViewModel(y)));
                }
                else
                {
                    db.JobTypes.Where(x => !x.IsDeleted).ToList().ForEach(y => result.Add(GetViewModel(y)));
                }

                return result;
            }
        }

        public List<MaterialView> GetAllMaterials(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<MaterialView> result = new List<MaterialView>();
                if (includeDeleted)
                {
                    db.Materials.ToList().ForEach(y => result.Add(GetViewModel(y)));
                }
                else
                {
                    db.Materials.Where(x => !x.IsDeleted).ToList().ForEach(y => result.Add(GetViewModel(y)));
                }

                return result;
            }
        }

        public List<UserView> GetAllUsers()
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<UserView> result = new List<UserView>();
                db.SYSUsers.ToList().ForEach(y => result.Add(GetViewModel(y)));

                return result;
            }
        }

        public JobCardView GetJobCard(int jobCardID, bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var result = GetViewModel(db.JobCards.SingleOrDefault(x => x.JobCardID == jobCardID && !x.IsDeleted), includeDeleted);
                return result;
            }
        }

        public List<JobCardView> GetAllJobCards(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }

        public List<JobCardView> GetLastJobCards(int amount, int userID, bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(
                    x => !x.IsDeleted && (
                        x.ApplicationID == userID || 
                        x.CladingID == userID || 
                        x.CreatedID == userID || 
                        x.InstallID == userID || 
                        x.InvoiceID == userID ||
                        x.UVPrinterID == userID)).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));

                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();
                result = result.OrderByDescending(x => x.JobCardID).Take(amount).OrderBy(x => x.JobCardID).ToList();
                return result;
            }
        }

        public void UpdateCustomer(CustomerView customer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Customer customerDb = db.Customers.Single(x => x.CustomerID == customer.CustomerID);
                customerDb.ContactNumber = customer.ContactNumber;
                customerDb.Description = customer.Description;
                customerDb.IsDeleted = customer.IsDeleted;
                customerDb.Name = customer.Name;

                db.SaveChanges();
            }
        }

        public void UpdateDesigner(DesignerView designer)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Designer designerrDb = db.Designers.Single(x => x.DesignerID == designer.DesignerID);
                designerrDb.ContactNumber = designer.ContactNumber;
                designerrDb.Description = designer.Description;
                designerrDb.IsDeleted = designer.IsDeleted;
                designerrDb.Name = designer.Name;

                db.SaveChanges();
            }
        }

        public void UpdateJobType(JobTypeView jobType)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                JobType jobTypeDb = db.JobTypes.Single(x => x.JobTypeID == jobType.JobTypeID);
                jobTypeDb.Description = jobType.Description;
                jobTypeDb.IsDeleted = jobType.IsDeleted;
                jobTypeDb.Name = jobType.Name;

                db.SaveChanges();
            }
        }

        public void UpdateMaterial(MaterialView material)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                Material materialDb = db.Materials.Single(x => x.MaterialID == material.MaterialID);
                materialDb.Description = material.Description;
                materialDb.IsDeleted = material.IsDeleted;
                materialDb.Name = material.Name;

                db.SaveChanges();
            }
        }
        private JobCardView GetViewModel(JobCard jobCard, bool includeDeleted)
        {
            JobCardView result = new JobCardView
            {
                CustomerID = jobCard.CustomerID,
                Customers = GetAllCustomers(includeDeleted),
                DesignerID = jobCard.DesignerID,
                Designers = GetAllDesigners(includeDeleted),
                IsDeleted = jobCard.IsDeleted,
                JobCardID = jobCard.JobCardID,
                JobTypeID = jobCard.JobTypeID,
                JobTypes = GetAllJobTypes(includeDeleted),
                JobDate = jobCard.JobDate,
                MaterialID = jobCard.MaterialID,
                Materials = GetAllMaterials(includeDeleted),
                QuoteRef = jobCard.QuoteRef,
                CreatedID = jobCard.CreatedID,
                CreatedDate = jobCard.CreatedDate,
                ApplicationDate = jobCard.ApplicationDate,
                ApplicationID = jobCard.ApplicationID,
                CladingDate = jobCard.CladingDate,
                CladingID = jobCard.CladingID,
                InstallDate = jobCard.InstalDate,
                InstallID = jobCard.InstallID,
                InvoiceDate = jobCard.InvoiceDate,
                InvoiceID = jobCard.InvoiceID,
                UVPrinterID = jobCard.UVPrinterID,
                UVPrintedDate = jobCard.UVPrintedDate,
                TaskStep = (TaskStep)jobCard.TaskStep,
                Description = jobCard.Description,
            };

            return result;
        }

        private DesignerView GetViewModel(Designer designer)
        {
            DesignerView result = new DesignerView
            {
                ContactNumber = designer.ContactNumber,
                DesignerID = designer.DesignerID,
                Description = designer.Description,
                IsDeleted = designer.IsDeleted,
                Name = designer.Name
            };

            return result;
        }

        private CustomerView GetViewModel(Customer customer)
        {
            CustomerView result = new CustomerView
            {
                ContactNumber = customer.ContactNumber,
                CustomerID = customer.CustomerID,
                Description = customer.Description,
                IsDeleted = customer.IsDeleted,
                Name = customer.Name
            };

            return result;
        }

        private JobTypeView GetViewModel(JobType jobType)
        {
            JobTypeView result = new JobTypeView
            {              
                JobTypeID = jobType.JobTypeID,
                Description = jobType.Description,
                IsDeleted = jobType.IsDeleted,
                Name = jobType.Name
            };

            return result;
        }

        private MaterialView GetViewModel(Material material)
        {
            MaterialView result = new MaterialView
            {
                MaterialID = material.MaterialID,
                Description = material.Description,
                IsDeleted = material.IsDeleted,
                Name = material.Name
            };

            return result;
        }

        private UserView GetViewModel(SYSUser user)
        {
            UserView result = new UserView
            {
                LoginName = user.LoginName,
                UserID = user.SYSUserID
            };

            return result;
        }

        public int GetUserID(string userName)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                int result = db.SYSUsers.SingleOrDefault(x => x.LoginName == userName).SYSUserID;
                return result;
            }
        }

        public void SetUVPrinted(string userName, JobCardView jobCard)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                JobCard dbItem = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                dbItem.UVPrinterID = GetUserID(userName);
                dbItem.UVPrintedDate = DateTime.Now;
                dbItem.TaskStep = 1;

                db.SaveChanges();
            }
        }

        public void SetApplication(string userName, JobCardView jobCard)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                JobCard dbItem = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                dbItem.ApplicationID = GetUserID(userName);
                dbItem.ApplicationDate = DateTime.Now;
                dbItem.TaskStep = 2;

                db.SaveChanges();
            }
        }

        public void SetClading(string userName, JobCardView jobCard)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                JobCard dbItem = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                dbItem.CladingID = GetUserID(userName);
                dbItem.CladingDate = DateTime.Now;
                dbItem.TaskStep = 3;

                db.SaveChanges();
            }
        }

        public void SetInstallation(string userName, JobCardView jobCard)
        {
            using (DigiFusionEntities db = new Database.DigiFusionEntities())
            {
                JobCard dbItem = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                dbItem.InstallID = GetUserID(userName);
                dbItem.InstalDate = DateTime.Now;
                dbItem.TaskStep = 4;

                db.SaveChanges();
            }
        }

        public void SetInvoice(string userName, JobCardView jobCard)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                JobCard dbItem = db.JobCards.Single(x => x.JobCardID == jobCard.JobCardID);
                dbItem.InvoiceID = GetUserID(userName);
                dbItem.InvoiceDate = DateTime.Now;
                dbItem.TaskStep = 5;

                db.SaveChanges();
            }
        }

        public static string GetJobTypeName(Guid? jobTypeID)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var result = db.JobTypes.Single(x => x.JobTypeID == jobTypeID).Name;
                return result;
            }
        }

        public int GetJobsPerDate(DateTime date)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                var result = db.JobCards.Where(x => x.JobDate == date).Count();
                return result;
            }
        }

        public List<JobCardView> GetUVPrintingJobCards(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted && x.TaskStep == 0).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }

        public List<JobCardView> GetApplicationJobCards(bool includeDeleted)
        {

            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted && x.TaskStep == 1).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }

        public List<JobCardView> GetCladingJobCards(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted && x.TaskStep == 2).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }

        public List<JobCardView> GetInstallationJobCards(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted && x.TaskStep == 3).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }

        public List<JobCardView> GetInvoiceJobCards(bool includeDeleted)
        {
            using (DigiFusionEntities db = new DigiFusionEntities())
            {
                List<JobCardView> result = new List<JobCardView>();
                db.JobCards.Where(x => !x.IsDeleted && x.TaskStep == 4).ToList().ForEach(y => result.Add(GetViewModel(y, includeDeleted)));
                result = result.Where(x => (x.TaskStep == TaskStep.Invoice && x.CreatedDate.Value.AddDays(7) > DateTime.Now) || x.TaskStep < TaskStep.Invoice).ToList();

                return result;
            }
        }
    }
}