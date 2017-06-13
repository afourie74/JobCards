using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using JobCards.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class CustomerController : Controller
    {
        [AuthorizeRoles("Admin", "User")]
        public ActionResult Index()
        {
            JobCardManager manager = new JobCardManager();
            return View(manager.GetAllCustomers(false));
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Details(Guid id)
        {
            JobCardManager manager = new JobCardManager();
            CustomerView customer = manager.GetCustomer(id);

            return View(customer);
        }

        [AuthorizeRoles("Admin", "User")]
        public ActionResult Create()
        {
            return View();
        }

        [AuthorizeRoles("Admin", "User")]
        [HttpPost]
        public ActionResult Create(CustomerView customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.CreateCustomer(customer);
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
            CustomerView customer = manager.GetCustomer(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Edit(CustomerView customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.UpdateCustomer(customer);
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
            JobCardManager manager = new Models.EntityManager.JobCardManager();
            CustomerView customer = manager.GetCustomer(id);

            return View(customer);
        }

        [HttpPost]
        public ActionResult Delete(CustomerView customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    JobCardManager manager = new JobCardManager();
                    manager.DeleteCustomer(customer);
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
