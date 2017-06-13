using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using JobCards.Security;
using System;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class DesignerController : Controller
    {
        [AuthorizeRoles("Admin", "User")]
        public ActionResult Index()
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetAllDesigners(false));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Details(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetDesigner(id));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Create()
        {
            return View();
        }

        [AuthorizeRoles("Admin", "User")]
        [HttpPost]
        public ActionResult Create(DesignerView designer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.CreateDesigner(designer);
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
            DesignerView designer = manager.GetDesigner(id);

            return View(designer);
        }

        [HttpPost]
        public ActionResult Edit(DesignerView designer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.UpdateDesigner(designer);
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
            DesignerView designer = manager.GetDesigner(id);

            return View(designer);
        }

        [HttpPost]
        public ActionResult Delete(DesignerView designer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.DeleteDesigner(designer);
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
