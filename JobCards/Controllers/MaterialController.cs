using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using JobCards.Security;
using System;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class MaterialController : Controller
    {
        [AuthorizeRoles("Admin", "User")]
        public ActionResult Index()
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetAllMaterials(false));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Details(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetMaterial(id));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Create()
        {
            return View();
        }

        [AuthorizeRoles("Admin", "User")]
        [HttpPost]
        public ActionResult Create(MaterialView material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.CreateMaterial(material);
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
            MaterialView material = manager.GetMaterial(id);

            return View(material);
        }

        [AuthorizeRoles("Admin", "User")]
        [HttpPost]
        public ActionResult Edit(MaterialView material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.UpdateMaterial(material);
                    return RedirectToAction("Index");
                }

                return View();
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
            MaterialView jobType = manager.GetMaterial(id);

            return View(jobType);
        }

        [HttpPost]
        public ActionResult Delete(MaterialView material)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.DeleteMaterial(material);
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