using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCWebApplication4.Models;

namespace MVCWebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult ContactUs()
        //{
        //    Provider p = new Provider();
        //    //p.ProviderId = 12;
        //    //p.ProviderName = "Vikas";
        //    //p.ProviderType = "Claim";
        //    //ViewBag.Message = "Welcome to the Tata Group";

        //    var data = p.GetProviderData();

        //    p.ProviderId = Convert.ToInt32(data.Tables[0].Rows[0][0].ToString());
        //    p.ProviderName = data.Tables[0].Rows[0][1].ToString();
        //    p.ProviderType = data.Tables[0].Rows[0][2].ToString();
        //    return View(p);
        //}

        public ActionResult Create()
        {
            ViewBag.Message = "Your contact page.";

            return View(new Provider());
        }

        [HttpPost]
        public ActionResult Create(Provider p)
        {
            if (ModelState.IsValid)
            {
                Provider newP = p;
                p.InsertProvider(p);
            }

            return RedirectToAction("ShowProvider");
        }

        public ActionResult ShowProvider()
        {
            List<Provider> p = new List<Provider>();

            var dataTables = Provider.GetProviderData();
            
            foreach (DataRow data in dataTables.Tables[0].Rows)
            {
                //Provider newProvider = new Provider()
                //{
                //    ProviderId = Convert.ToInt32(data[0].ToString()),
                //    ProviderName = data[1].ToString(),
                //    ProviderType = data[2].ToString()
                //};

                //p.Add(newProvider);

                p.Add(new Provider()
                {
                    ProviderId = Convert.ToInt32(data[0].ToString()),
                    ProviderName = data[1].ToString(),
                    ProviderType = data[2].ToString()
                });
            }
            return View(p);    
        }

    }
}