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
        public album() {
            songs = new HashSet<song>();

        }

        

        public string names { get; set; }

        [Display(Name =" Year Released")]
        public int yearReleased { get; set; }
        
        public string producer { get; set; }
        [Display(Name = "Record Label")]
        public string recodLabel { get; set; }
        public decimal Price { get; set; }
        public virtual ICollection<song> songs { get; set; }
        public virtual bands band { get; set; }
    
        
        

    }
}

