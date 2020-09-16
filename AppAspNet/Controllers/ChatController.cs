using AppAspNet.entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppAspNet.Controllers
{
    public class ChatController : Controller
    {
        // GET: Chat
        public ActionResult Index()
        {
            return View(FakeDb.Instance.Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            return View(FakeDb.Instance.Chats.FirstOrDefault(x => x.Id == id));
        }

        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            var item = FakeDb.Instance.Chats.FirstOrDefault(x => x.Id == id);
            FakeDb.Instance.Chats.Remove(item);
            return View(item);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
