namespace BolinsBlommor.Migrations
{
    using Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BolinsBlommor.Models.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BolinsBlommor.Models.DataContext context)
        {
            //This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.E.g.

              context.DeliveryPersons.AddOrUpdate(
                p => p.Id,
                new DeliveryPerson { Id = 1, Name = "Andrew Peters", PhoneNumber = "070-1234567" },
                new DeliveryPerson { Id = 2, Name = "Brice Lambson", PhoneNumber = "070-9873542" },
                new DeliveryPerson { Id = 3, Name = "Rowan Miller", PhoneNumber = "073-87453629" }
              );

            context.Bouqettes.AddOrUpdate(
                    b => b.Id,
                    new Bouqette { Id = 1, Name = "LiljeBulle", Descripton = "Liljor och gröna blad", Price = 199, OrderId = 1 }
                );

            context.Orders.AddOrUpdate(
                    o => o.Id, 
                    new Order { Id = 1, Address  = "Knallstigen 17", Sender = "Roger Person", Receiver = "Astrid Lundgren", Messsage = "Veckans bukett", DeliveryPersonId = 1, Status = Order.Started  }
                );

        }
    }
}
