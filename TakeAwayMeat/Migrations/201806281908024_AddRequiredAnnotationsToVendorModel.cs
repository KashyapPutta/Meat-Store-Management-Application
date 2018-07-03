namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAnnotationsToVendorModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Vendors", "VendorName", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "EmailId", c => c.String(nullable: false));
            AlterColumn("dbo.Vendors", "Address", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "Address", c => c.String());
            AlterColumn("dbo.Vendors", "EmailId", c => c.String());
            AlterColumn("dbo.Vendors", "VendorName", c => c.String());
        }
    }
}
