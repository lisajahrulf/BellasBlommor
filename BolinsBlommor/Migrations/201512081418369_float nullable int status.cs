namespace BolinsBlommor.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class floatnullableintstatus : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "Status", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Single());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "TotalPrice", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "Status", c => c.String());
        }
    }
}
