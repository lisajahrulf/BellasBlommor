namespace BolinsBlommor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedorderIdfromBouqettes : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bouqettes", "OrderId", "dbo.Orders");
            DropIndex("dbo.Bouqettes", new[] { "OrderId" });
            CreateIndex("dbo.OrderBouqettes", "OrderId");
            CreateIndex("dbo.OrderBouqettes", "BouqetteId");
            AddForeignKey("dbo.OrderBouqettes", "BouqetteId", "dbo.Bouqettes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderBouqettes", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            DropColumn("dbo.Bouqettes", "OrderId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bouqettes", "OrderId", c => c.Int(nullable: false));
            DropForeignKey("dbo.OrderBouqettes", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.OrderBouqettes", "BouqetteId", "dbo.Bouqettes");
            DropIndex("dbo.OrderBouqettes", new[] { "BouqetteId" });
            DropIndex("dbo.OrderBouqettes", new[] { "OrderId" });
            CreateIndex("dbo.Bouqettes", "OrderId");
            AddForeignKey("dbo.Bouqettes", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
    }
}
