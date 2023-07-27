using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace ProjectDB2022.Areas.Admin.Controllers
{
    public class MasterController : Controller
    {
        // GET: Admin/Master
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Topic()
        {
            return View();
        }


        public ActionResult TopicContent()
        {
            return View();
        }

        public ActionResult PostCatagories()
        {
            return View();
        }
        public ActionResult State()
        {
            return View();
        }

        public ActionResult City()
        {

            return View();
        }

        public ActionResult Location()
        {

            return View();
        }


        public ActionResult Qualification()
        {
            return View();
        }

        public ActionResult Specialization()
        {
            return View();
        }


        public ActionResult Roles()
        {
            return View();
        }

        public ActionResult Genders()
        {
            return View();
        }

        public ActionResult Designations()
        {
            return View();
        }

       
    }
}