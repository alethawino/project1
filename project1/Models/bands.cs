using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace project1.Models
{
    public class bands
    {
        public bands()
        {
            albums = new HashSet<album>();
        }

        public int ID { get; set; }

        public String Name { get; set; }
        [Display(Name = "Genre")]
        public String genre { get; set; }

        [Display(Name = "Albums")]
        public virtual ICollection<album> albums { get; set; }
        




    }
}