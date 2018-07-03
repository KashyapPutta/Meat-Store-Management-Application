namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingAllTablesOnPartOfRefactoringProcess : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates");
            DropIndex("dbo.Supplies", new[] { "MeatType" });
            DropTable("dbo.Customers");
            DropTable("dbo.Inventories");
            DropTable("dbo.MeatKinds");
            DropTable("dbo.MeatRates");
            DropTable("dbo.Supplies");
            DropTable("dbo.Transactions");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        QuantityPurchased = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeatType = c.String(),
                        BoneMeatQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonelessMeatQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId);
            
            CreateTable(
                "dbo.Supplies",
                c => new
                    {
                        SupplierId = c.Int(nullable: false, identity: true),
                        SupplierName = c.String(),
                        MeatType = c.String(maxLength: 128),
                        Quantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        SuppliedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.SupplierId);
            
            CreateTable(
                "dbo.MeatRates",
                c => new
                    {
                        MeatType = c.String(nullable: false, maxLength: 128),
                        CostPerLb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerLbBoneless = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.MeatType);
            
            CreateTable(
                "dbo.MeatKinds",
                c => new
                    {
                        MeatId = c.Int(nullable: false, identity: true),
                        MeatName = c.String(),
                    })
                .PrimaryKey(t => t.MeatId);
            
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatTypeInStock = c.String(nullable: false),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfCustomer = c.String(nullable: false),
                        ContactNo = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Supplies", "MeatType");
            AddForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates", "MeatType");
        }
    }
}
