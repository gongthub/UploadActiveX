using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult IndexP()
        {
            string name = Request["FileName"];
            string str = Request["FileStr"];
            byte[] by = Getby(str);
            System.IO.File.WriteAllBytes(@"c:\test.bmp", by);
            return View();
        }
        public byte[] Getby(string str)
        {
            byte[] by = null;
            string[] strs = str.Split(',');
            by = new byte[strs.Length - 1];
            for (int i = 0; i < strs.Length - 1; i++)
            {
                by[i] = byte.Parse(strs[i]);
            }
            return by;
        }

    }
}
