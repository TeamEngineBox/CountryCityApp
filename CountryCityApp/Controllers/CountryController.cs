using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CountryCityApp.Models;

namespace CountryCityApp.Controllers
{
    public class CountryController : Controller
    {
       CountryDbGateway aCountryDbGateway= new CountryDbGateway();
        public ActionResult Create()
        {
            ViewBag.countries = aCountryDbGateway.GetAllCountry().OrderBy(x => x.Name).ToList(); 
            return View();
        }
        [HttpPost]
        public ActionResult Create(HttpPostedFileBase picture, Country aCountry)
        {
            if (picture != null)
            {
                string fileName = Path.GetFileName(picture.FileName);
                string path = Path.Combine(Server.MapPath("/Images"), fileName);
                picture.SaveAs(path);
                aCountry.Picture = "/Images/" + fileName;
            }
            

            aCountryDbGateway.Save(aCountry);
            ViewBag.countries = aCountryDbGateway.GetAllCountry().OrderBy(x => x.Name).ToList(); 
            return View();
        }
	}
}