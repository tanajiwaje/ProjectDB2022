using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using ProjectDatabaseOperation;
using System.Text;
using System.Web.Http.Results;
using System.Web.UI.WebControls;
using System.Security.Cryptography.X509Certificates;
using Microsoft.Ajax.Utilities;
using System.Security.Claims;
//using ProjectDB2022.Models;
using ProjectDB2022.Areas.Admin.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using ProjectDB2022.BL;
//using System.Web.Http;

namespace ProjectDB2022.Areas.Admin.Controllers
{
  
    public class UserController : Controller
    {
        
       
        public ActionResult Login()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection fc)
        {

            return View();
        }

        public ActionResult index()
        {
            return View();
        }
            public void GenerateToken(sp_fetch_tbluser_details_Result data)
            { 

            }
        public ActionResult Dashboard()
        {
            
            return View();
        }

        public ActionResult PasswordLink()
        {
            return View();
        }


        public ActionResult ResetPassword(string userId)
        {
            string uid =EncryptedUserId.Decrypt1(userId);
            int userid = int.Parse(uid);
            ViewBag.UserId = userid;
            return View();
        }


        public ActionResult DashboardFirst()
        {
          
            return View();
        }




        public ActionResult Logout()
        {

            Session["userId"] =null;

            return View("Login");
        }

      
        public ActionResult CheckUsers()
        {
            return View();
        }
       
        public ActionResult UserDetails()
        {
            return View();
        }


        public ActionResult UserQualification()
        {
            return View();
        }

        public ActionResult experienceDetails()
        {
            return View();
        }

        public ActionResult ProfessionExpertise()
        {
            return View();
        }
    }
}