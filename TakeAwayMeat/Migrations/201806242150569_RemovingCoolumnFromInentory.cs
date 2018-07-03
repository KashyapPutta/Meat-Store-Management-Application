namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingCoolumnFromInentory : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Inventories", "MeatTypeInStock");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Inventories", "MeatTypeInStock", c => c.String(nullable: false));
        }
    }
}
