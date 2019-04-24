using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Mvc;
using CustomerMVCApp.BLL;
using CustomerMVCApp.DAL;
using CustomerMVCApp.Models;

namespace CustomerMVCApp.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager customerManager=new CustomerManager();
        //Add Using Form
        public ActionResult AddCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddCustomer(Customer customer)
        {
            try
            {
                if (customerManager.AddCustomer(customer))
                {
                    ViewBag.SMsg = "Saved Successfully";
                }
                else
                {
                    ViewBag.FMsg = "Not Saved..!!!";
                }                
            }
            catch (Exception ex)
            {
                ViewBag.FMsg=ex.Message;
            }
            return View();
        }
        //Add using URL
        public string Add(Customer customer)
        {
            if (customerManager.AddCustomer(customer))
            {
                return "Successfully Saved!";
            }
            else
            {
                return "Not Saved!";
            }
            
        }
         //Delete Using URL
        public string Delete(int code)
        {
            if (customerManager.DeleteCustomer(code))
            {
                return "Successfully Deleted!";
            }
            else
            {
                return "Not Deleted!";
            }
            
        }
        //Delete Using Form
        public ViewResult DeleteCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DeleteCustomer(Customer customer)
        {
            try
            {
                if (customerManager.DeleteCustomer(customer.Code))
                {
                    ViewBag.SMsg = "Successfully Deleted.";
                }
                else
                {
                    ViewBag.FMsg = "Not Deleted.";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }        
            return View();
        }
        
        //Update with Form
        public ViewResult UpdateCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                if (customerManager.UpdateCustomer(customer))
                {
                    ViewBag.SMsg = "Successfully Updated.";
                }
                else
                {
                    ViewBag.FMsg = "Update Fail.!!!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.FMsg = ex.Message;
            }
            
            return View();
        }
        public ViewResult ShowCustomer()
        {
            return View(customerManager.ShowCustomer());
        }
        //Update with URL
        public string Update(Customer customer)
        {
            if (customerManager.UpdateCustomer(customer))
            {
                return "Successfully Updated!";
            }
            else
            {
                return "Not Updated!";
            }
            
        }
       
	}

}