namespace BolinsBlommor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bouqettes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Descripton = c.String(),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DeliveryPersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.OrderBouqettes",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
                        BouqetteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrderId, t.BouqetteId })
                .ForeignKey("dbo.Bouqettes", t => t.BouqetteId, cascadeDelete: true)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.BouqetteId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Address = c.String(),
                        Sender = c.String(),
                        Receiver = c.String(),
                        Messsage = c.String(),
                        Status = c.Int(nullable: false),
                        TotalPrice = c.Single(),
                        DeliveryPersonId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.DeliveryPersons", t => t.DeliveryPersonId)
                .Index(t => t.DeliveryPersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderBouqettes", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "DeliveryPersonId", "dbo.DeliveryPersons");
            DropForeignKey("dbo.OrderBouqettes", "BouqetteId", "dbo.Bouqettes");
            DropIndex("dbo.Orders", new[] { "DeliveryPersonId" });
            DropIndex("dbo.OrderBouqettes", new[] { "BouqetteId" });
            DropIndex("dbo.OrderBouqettes", new[] { "OrderId" });
            DropTable("dbo.Orders");
            DropTable("dbo.OrderBouqettes");
            DropTable("dbo.DeliveryPersons");
            DropTable("dbo.Bouqettes");
        }
    }
}
