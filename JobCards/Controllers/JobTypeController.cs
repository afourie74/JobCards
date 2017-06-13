using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using JobCards.Security;
using System;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class JobTypeController : Controller
    {
        [AuthorizeRoles("Admin", "User")]
        public ActionResult Index()
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetAllJobTypes(false));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Details(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetJobType(id));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JobTypeView jobType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.CreateJobType(jobType);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch 
            {
                return View();
            }
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Edit(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            JobTypeView jobType = manager.GetJobType(id);

            return View(jobType);
        }

        [HttpPost]
        public ActionResult Edit(JobTypeView jobType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.UpdateJobType(jobType);
                    return RedirectToAction("Index");
                }

                return View(jobType);
            }
            catch
            {
                return View();
            }
        }

        [AuthorizeRoles("Admin")]
        public ActionResult Delete(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            JobTypeView jobType = manager.GetJobType(id);

            return View(jobType);
        }

        [HttpPost]
        public ActionResult Delete(JobTypeView jobType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.DeleteJobType(jobType);
                    return RedirectToAction("Index");
                }

                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}