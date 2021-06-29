using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using THWeb_Buoi3.Models;

namespace THWeb_Buoi3.Controllers
{
    public class BookController : Controller
    {
        DBContext context = new DBContext();
        // GET: Book
        public ActionResult ListBook()
        {
            
            var listBook = context.Books.ToList();
            return View(listBook);
        }

        [Authorize]
        public ActionResult Buy(int id)
        {
            Book book = context.Books.SingleOrDefault(p => p.Id == id);
            if(book == null)
            {
                return HttpNotFound()
;
            }
            return View(book);
        }

        public ActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create(FormCollection bookinfo)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            Book newbook = new Book();
        //            newbook.Author = bookinfo["Author"];
        //            newbook.Title = bookinfo["Title"];
        //            newbook.Description = bookinfo["Description"];
        //            newbook.ImageCover = bookinfo["ImageCover"];
        //            newbook.Price = Int32.Parse(bookinfo["Price"]);
        //            context.Books.AddOrUpdate(newbook);
        //            context.SaveChanges();
        //            return RedirectToAction("ListBook");
        //        }
        //        catch (Exception ex)
        //        {
        //            return HttpNotFound();
        //        }
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "Input Model Not Valid");
        //        return RedirectToAction("ListBook");
        //    }
        //}
        public ActionResult Create(Book b)
        {
            context.Books.AddOrUpdate(b);
            context.SaveChanges();
            return RedirectToAction("ListBook");
        }

        
        public ActionResult Edit()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book b)
        {
            Book update = context.Books.FirstOrDefault(p => p.Id == b.Id);
            if(update != null)
            {
                context.Books.AddOrUpdate(b);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }

        public ActionResult Delete(int id)
        {
            var book = context.Books.Find(id);
            return View(book);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Deletes(int id)
        {
            Book delete = context.Books.FirstOrDefault(p => p.Id == id);
            if (delete != null)
            {
                context.Books.Remove(delete);
                context.SaveChanges();
            }
            return RedirectToAction("ListBook");
        }
    }
}