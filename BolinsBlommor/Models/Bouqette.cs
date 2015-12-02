using System;
using System.Collections.Generic;
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

        public int OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}