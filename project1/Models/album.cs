using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class album
    {
        public int id { get; set; }

        

        public string names { get; set; }

        [Display(Name =" Year Released")]
        public int yearReleased { get; set; }
        
        public string producer { get; set; }
        [Display(Name = "Record Label")]
        public string recodLabel { get; set; }
        public decimal price { get; set; }

    }
}

