using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Le_Dojo.Models
{
    public class SamouraiViewModel
    {
        public Samourai Samourai { get; set; }
        public List<Arme> Armes { get; set; }
        public int? IdArmes { get; set; }
    }
}