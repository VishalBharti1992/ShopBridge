using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShopBridge.Controllers
{
    public class ManageInventoryController : Controller
    {
        // GET: ManageInventory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ManageProductInventory()
        {
            return View();
        }
    }
}