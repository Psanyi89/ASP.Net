using DataLibrary.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;
using WebShop.Models;
using static DataLibrary.BuisnessLogic.CustomerProcessor;

namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account az
        public ActionResult ViewCustomers()
        {
            ViewBag.Message = "Customers List";
            var customers = LoadCustomers();
            List<CustomerList> list = new List<CustomerList>();
            foreach (var row in customers)
            {
                list.Add(new CustomerList
                {
                    Username = row.Username,
                    Firstname = row.Firstname,
                    Lastname = row.Lastname,
                    Phonenumber = row.Phonenumber,
                    Email = row.Email,
                    Birthdate = row.Birthdate,
                    Country = row.Country,
                    States = row.States,
                    Zipcode = row.Zipcode,
                    Settlement = row.Settlement,
                    Addresses = row.Addresses,
                    Modified=row.Modified
                });
            }
            return View(list);
        }
        public ActionResult SignUp()
        {
            ViewBag.Message = "Create new a profile";

            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Customers model)
        {
            if (ModelState.IsValid)
            {
                int recordCreate = CreateCustomer(
                   model.Username,
                   model.Firstname,
                   model.Lastname,
                   model.Phonenumber,
                   model.Email,
                   model.Passwd,
                   model.Birthdate,
                   model.Country,
                   model.States,
                   model.Zipcode,
                   model.Settlement,
                   model.Addresses
                    );
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public JsonResult IsUsernameSigned(string Username)
        {
            return Json(IsUsernameAvailable(Username));
        }
        public bool IsUsernameAvailable(string userName)
        {
            int count=CheckUsername(userName);
            bool status;
            if (count > 0) status = false;
            else status = true;
            return status;
        }
        [HttpPost]
        public JsonResult IsEmailSigned(string Email)
        {
            return Json(IsEmailAvailable(Email));
        }
        public bool IsEmailAvailable(string eMail)
        {
            int count = CheckEmail(eMail);
            bool status;
            if (count > 0) status = false;
            else status = true;
            return status;
        }
        public ActionResult LogIn()
        {
            ViewBag.Message = "Sign In";

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(CustomerLogin customer)
        {
            int count = LoginCustomer(customer.Username, customer.Password);
           if ( count== 1)
            {

                Session["Username"] = customer.Username.ToString();
             return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Username or password invalid");
               
            }
            ViewBag.Message = "Signed In";

             return View();
        }
        public ActionResult LoggedIn()
        {
            if (!string.IsNullOrWhiteSpace(Session["Username"].ToString()))
            {
                return View();
            }
            else return RedirectToAction("LogIn");
        }
    }
}