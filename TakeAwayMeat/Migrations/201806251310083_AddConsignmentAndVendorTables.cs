namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddConsignmentAndVendorTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Consignments",
                c => new
                    {
                        ConsignmentId = c.Int(nullable: false, identity: true),
                        VendorId = c.Int(nullable: false),
                        MeatType = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SuppliedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ConsignmentId)
                .ForeignKey("dbo.Vendors", t => t.VendorId, cascadeDelete: true)
                .Index(t => t.VendorId);
            
            CreateTable(
                "dbo.Vendors",
                c => new
                    {
                        VendorId = c.Int(nullable: false, identity: true),
                        VendorName = c.String(),
                        ContactNum = c.Long(nullable: false),
                        EmailId = c.String(),
                        MyProperty = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.VendorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Consignments", "VendorId", "dbo.Vendors");
            DropIndex("dbo.Consignments", new[] { "VendorId" });
            DropTable("dbo.Vendors");
            DropTable("dbo.Consignments");
        }
    }
}
