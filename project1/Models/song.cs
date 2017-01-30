using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace project1.Models
{
    public class song
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String Lyrics { get; set; }
        public String Duration { get; set; }
        public virtual album album { get; set; }
        

    }
}