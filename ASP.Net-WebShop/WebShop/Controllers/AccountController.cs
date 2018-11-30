using System.Collections.Generic;
using System.Web.Mvc;
using WebShop.Models;
using static DataLibrary.BuisnessLogic.CustomerProcessor;


namespace WebShop.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account 
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
             ViewBag.CountryList = new SelectList(GetCountryList(), "Id", "Name");

            return View();
        }
        public List<Countries> GetCountryList()
        {
            var countries = LoadCountries();
            List < Countries > nations= new List<Countries>();
            foreach (var item in countries)
            {
                nations.Add(new Countries
                {
                    Id = item.Id,
                    Name = item.Name
                });
            }
           
            return nations;
        }
        public ActionResult GetStateList(int Id)
        {
            var province = LoadStates(Id);
            List<States> StateList = new List<States>();
            foreach (var item in province)
            {
                StateList.Add(new States
                {                  
                    StateId = item.StateId,
                    StateName = item.StateName
                  
                });
            }

            ViewBag.StateList = new SelectList(StateList, "StateId", "StateName");
            return PartialView("_DisplayStates");
        }
        public ActionResult GetCityList(int StateId)
        {
            var CityList = LoadCities(StateId);
            List<Cities> settle = new List<Cities>();
            foreach (var item in CityList)
            {
                settle.Add(new Cities
                {
                    CityId = item.CityId,
                    CityName = item.CityName,
                  
                });
            }
            ViewBag.CityList = new SelectList(settle, "CityId", "CityName");
            return PartialView("_DisplayCities");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SignUp(Customers model, FormCollection form)
        {
            int countryId=int.Parse(model.Country);
           int stateId=int.Parse(model.States);
           int cityId=int.Parse(model.Settlement);
          
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
                   model.Country = GetCountryName(countryId),
                   model.States= GetStateName(stateId),
                   model.Zipcode,
                   model.Settlement = GetCityName(cityId),
                   model.Addresses
                    );
                return RedirectToAction("Index","Home");
            }
            return View();
        }
        [HttpPost]
        public JsonResult IsUsernameSigned(string Username)
        {
            return Json(IsUsernameOrEmailAvailable(Username));
        }
        public bool IsUsernameOrEmailAvailable(string userName)
        {
            int count= CheckEmailorUserName(userName);
            bool status;
            if (count > 0) status = false;
            else status = true;
            return status;
        }
        [HttpPost]
        public JsonResult IsEmailSigned(string Email)
        {
            return Json(IsUsernameOrEmailAvailable(Email));
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


        int count = LoginCustomer(customer.Username,SHA512(customer.Password));
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