﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BolinsBlommor.Models
{
    public class Order
    {
        [NotMapped]
        public const int CREATED = 1;
        [NotMapped]
        public const int STARTED = 2;
        [NotMapped]
        public const int FINISHED = 3;

        [NotMapped]
        public const string Created = "Skapad";
        [NotMapped]
        public const string Started = "Påbörjad";
        [NotMapped]
        public const string Finished = "Levererad";


        public int Id { get; set; }
        public string Address { get; set; }
        public string Sender { get; set; }
        public string Receiver { get; set; }
        public string Messsage { get; set; }
        public int Status { get; set; }
        public float? TotalPrice { get; set; }

        public virtual List<OrderBouqette> OrderBouqettes { get; set; }
        public int? DeliveryPersonId { get; set; }
        public virtual DeliveryPerson DeliveryPerson { get; set; }

        public float? SetTotalPrice()
        {
            
            TotalPrice = 0;

            foreach (OrderBouqette ob in OrderBouqettes)
            {
                TotalPrice += ob.Bouqette.Price;
            }

            return TotalPrice;
            
        }

        public string GetStatus(int status)
        {
            switch(status)
            {
                case CREATED: return Created;
                case STARTED: return Started;
                case FINISHED: return Finished;
                default: return "";
            }

        }

    }
}