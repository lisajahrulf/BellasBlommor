using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace BolinsBlommor.Models
{
    public class OrderBouqette
    {
        [Key, Column(Order = 0)]
        public int OrderId { get; set; }
        [Key, Column(Order = 1)]
        public int BouqetteId { get; set; }

        [NotMapped]
        public virtual Order Order { get; set; }
        public virtual Bouqette Bouqette { get; set; }

    }
}