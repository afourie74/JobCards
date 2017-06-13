using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using JobCards.Security;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class JobCardController : Controller
    {
        [AuthorizeRoles("Admin", "User")]
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                JobCardManager manager = new JobCardManager();
                List<JobCardView> view = manager.GetAllJobCards(true);
                return View(view);
            }

            return View();
        }

        [AuthorizeRoles("User")]
        public ActionResult Create()
        {
            JobCardManager manager = new JobCardManager();

            var jobCardView = new JobCardView()
            {
                Customers = manager.GetAllCustomers(false),
                Designers = manager.GetAllDesigners(false),
                JobTypes = manager.GetAllJobTypes(false),
                Materials = manager.GetAllMaterials(false)
            };

            return View(jobCardView);
        }

        [AuthorizeRoles("Admin")]
        public ActionResult CreateAdmin()
        {
            JobCardManager manager = new JobCardManager();

            var jobCardView = new JobCardAdminView()
            {
                Customers = manager.GetAllCustomers(false),
                Designers = manager.GetAllDesigners(false),
                JobTypes = manager.GetAllJobTypes(false),
                Materials = manager.GetAllMaterials(false)
            };

            return View(jobCardView);
        }

        [HttpPost]
        public ActionResult Create(JobCardView jobCardView)
        {
            if (ModelState.IsValid)
            {
                if (jobCardView.CustomerID == null ||
                    jobCardView.DesignerID == null ||
                    jobCardView.JobTypeID == null ||
                    jobCardView.MaterialID == null)
                {
                    return CreateAdmin();
                }

                JobCardManager manager = new JobCardManager();
                jobCardView.CreatedID = manager.GetUserID(User.Identity.Name);
                jobCardView.CreatedDate = DateTime.Now;
                manager.CreateJobCard(jobCardView);

                return RedirectToAction("Index");
            }

            return Create();
        }

        [HttpPost]
        public ActionResult CreateAdmin(JobCardAdminView jobCardView)
        {
            if (ModelState.IsValid)
            {
                if (jobCardView.CustomerID == null ||
                    jobCardView.DesignerID == null ||
                    jobCardView.JobTypeID == null ||
                    jobCardView.MaterialID == null)
                {
                    return CreateAdmin();
                }

                JobCardManager manager = new JobCardManager();
                jobCardView.CreatedID = manager.GetUserID(User.Identity.Name);
                jobCardView.CreatedDate = DateTime.Now;
                manager.CreateJobCard(jobCardView);

                return RedirectToAction("Index");
            }

            return CreateAdmin();
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Details(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult UVPrinted(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult UVPrintedResult(JobCardView jobCard)
        {
            JobCardManager manager = new JobCardManager();
            manager.SetUVPrinted(User.Identity.Name, jobCard);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Application(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult ApplicationResult(JobCardView jobCard)
        {
            JobCardManager manager = new JobCardManager();
            manager.SetApplication(User.Identity.Name, jobCard);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Clading(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult CladingResult(JobCardView jobCard)
        {
            JobCardManager manager = new JobCardManager();
            manager.SetClading(User.Identity.Name, jobCard);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Installation(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult InstallationResult(JobCardView jobCard)
        {
            JobCardManager manager = new JobCardManager();
            manager.SetInstallation(User.Identity.Name, jobCard);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Invoice(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);

            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult InvoiceResult(JobCardView jobCard)
        {
            JobCardManager manager = new JobCardManager();
            manager.SetInvoice(User.Identity.Name, jobCard);
            return RedirectToAction("Index");
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult History(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);
            jobCard.Customers = manager.GetAllCustomers(true);
            jobCard.Designers = manager.GetAllDesigners(true);
            jobCard.JobTypes = manager.GetAllJobTypes(true);
            jobCard.Materials = manager.GetAllMaterials(true);
            jobCard.Users = manager.GetAllUsers();
            return View(jobCard);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Delete(int id)
        {
            JobCardManager manager = new JobCardManager();
            JobCardView jobCard = manager.GetJobCard(id, true);
            jobCard.Users = manager.GetAllUsers();
            jobCard.Customers = manager.GetAllCustomers(true);
            jobCard.Designers = manager.GetAllDesigners(true);

            return View(jobCard);
        }

        [HttpPost]
        public ActionResult Delete(JobCardView jobCard)
        {
            try
            {
                if (jobCard.JobCardID != 0)
                { 
                    JobCardManager manager = new JobCardManager();
                    manager.DeleteJobCard(jobCard);
                    return RedirectToAction("Index");
                }

                return View(jobCard);
            }
            catch
            {
                return View();
            }
        }
    }
}