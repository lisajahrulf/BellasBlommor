using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BolinsBlommor.Models
{
    public class Bouqette
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripton { get; set; }
        public float Price { get; set; }

        [NotMapped]
        public virtual List<OrderBouqette> OrderBouqettes { get; set; }
    }
}