using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;    
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InterviewTasks2023.Models;

namespace InterviewTasks2023.Controllers
{
    [Route("API/BooksController")]
    [ApiController]
    public class BooksController : Controller
    {
        // GET 
        [HttpGet]
         public ActionResult ShowAllBookDetails()    
        {    
            Book obj = new Book();    
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            obj.ShowallBook= objDB.Selectalldata();    
            return View(obj);    
        } 

        // GET: 
        [HttpGet("{code}")]
         public ActionResult Details(int code)    
        {        
            DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
            return View(objDB.SelectDatabyID(code));    
        }

        

        // POST:
        [HttpPost]
        public ActionResult Edit(Book book)    
        {      
            if (ModelState.IsValid) //checking model is valid or not    
            {    
                DataAccessLayer objDB = new DataAccessLayer(); //calling class DBdata    
                string result = objDB.UpdateData(book);       
                TempData["result2"] = result;    
                ModelState.Clear(); //clearing model    
                return RedirectToAction("ShowAllBookDetails");    
            }    
            else    
            {    
                ModelState.AddModelError("", "Error in saving data");    
                return View();    
            }    
        } 

        // DELETE:
        [HttpDelete("{code}")]
          public ActionResult Delete(int code)    
        {            
                DataAccessLayer objDB = new DataAccessLayer();    
                int result = objDB.DeleteData(code);    
                TempData["result3"] = result;    
                ModelState.Clear(); //clearing model        
                return RedirectToAction("ShowAllBookDetails");    
         } 
        
    }
}
