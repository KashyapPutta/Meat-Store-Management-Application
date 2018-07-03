namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SmallchangeInVenDorTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "DateAdded", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendors", "MyProperty");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vendors", "MyProperty", c => c.DateTime(nullable: false));
            DropColumn("dbo.Vendors", "DateAdded");
        }
    }
}
