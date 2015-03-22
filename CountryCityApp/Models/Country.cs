using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CountryCityApp.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [AllowHtml]
        public string About { get; set; }

        public string Picture { get; set; }
    }
}