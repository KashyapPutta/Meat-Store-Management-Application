namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSuppliesTableToDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        SuppliedMeatType = c.String(),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SuppliedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Supplies");
        }
    }
}
