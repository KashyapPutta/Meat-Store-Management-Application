namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddAddressToVendor : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vendors", "Address", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vendors", "Address");
        }
    }
}
