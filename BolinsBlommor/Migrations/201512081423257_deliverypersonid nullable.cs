namespace BolinsBlommor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deliverypersonidnullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "DeliveryPersonId", "dbo.DeliveryPersons");
            DropIndex("dbo.Orders", new[] { "DeliveryPersonId" });
            AlterColumn("dbo.Orders", "DeliveryPersonId", c => c.Int());
            CreateIndex("dbo.Orders", "DeliveryPersonId");
            AddForeignKey("dbo.Orders", "DeliveryPersonId", "dbo.DeliveryPersons", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "DeliveryPersonId", "dbo.DeliveryPersons");
            DropIndex("dbo.Orders", new[] { "DeliveryPersonId" });
            AlterColumn("dbo.Orders", "DeliveryPersonId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "DeliveryPersonId");
            AddForeignKey("dbo.Orders", "DeliveryPersonId", "dbo.DeliveryPersons", "Id", cascadeDelete: true);
        }
    }
}
