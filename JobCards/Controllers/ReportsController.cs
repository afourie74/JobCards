using JobCards.Models.EntityManager;
using JobCards.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobCards.Controllers
{
    public class ReportsController : Controller
    {
        // GET: Reports
        public ActionResult UVPrinting()
        {
            JobCardManager manager = new JobCardManager();
            List<JobCardView> jobCards = manager.GetUVPrintingJobCards(true);
            return View(jobCards);
        }

        public ActionResult Application()
        {
            JobCardManager manager = new JobCardManager();
            List<JobCardView> jobCards = manager.GetApplicationJobCards(true);
            return View(jobCards);
        }

        public ActionResult Clading()
        {
            JobCardManager manager = new JobCardManager();
            List<JobCardView> jobCards = manager.GetCladingJobCards(true);
            return View(jobCards);
        }

        public ActionResult Installation()
        {
            JobCardManager manager = new JobCardManager();
            List<JobCardView> jobCards = manager.GetInstallationJobCards(true);
            return View(jobCards);
        }

        public ActionResult Invoice()
        {
            JobCardManager manager = new JobCardManager();
            List<JobCardView> jobCards = manager.GetInvoiceJobCards(true);
            return View(jobCards);
        }
    }
}