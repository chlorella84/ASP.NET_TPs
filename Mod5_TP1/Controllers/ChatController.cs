using Mod5_TP1.Databases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TP.Models;

namespace Mod5_TP1.Controllers
{
    public class ChatController : Controller
    {

        // GET: Chat
        public ActionResult Index()
        {
            List<Chat> Chats = FakeDb.Instance.Chats;

            return View(Chats);
        }

        // GET: Chat/Details/5
        public ActionResult Details(int id)
        {
            List<Chat> Chats = FakeDb.Instance.Chats;
            Chat chatDetail = Chats.FirstOrDefault(x => x.Id == id);
            if (chatDetail == null)
            {
                return RedirectToAction("Index");
            }
            return View(chatDetail);
        }

 
        // GET: Chat/Delete/5
        public ActionResult Delete(int id)
        {
            List<Chat> Chats = FakeDb.Instance.Chats;
            var chat = Chats.FirstOrDefault(x => x.Id == id);
            if (chat == null)
            {
                return RedirectToAction("Index");
            }

            return View(chat);
        }

        // POST: Chat/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            List<Chat> Chats = FakeDb.Instance.Chats;
            try
            {
                var chat = Chats.FirstOrDefault(x => x.Id == id);
                if (chat != null)
                {
                    Chats.Remove(chat);
                }
            }
            catch
            {
                return View();
            }
            return RedirectToAction("Index");
        }
    }
}
