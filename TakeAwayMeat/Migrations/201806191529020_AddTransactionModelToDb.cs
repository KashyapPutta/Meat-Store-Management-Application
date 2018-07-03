namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionModelToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        CustomersId = c.Int(nullable: false),
                        QuantityPurchased = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeatType = c.String(),
                        MeatTypeBone = c.String(),
                        MeatTypeBoneless = c.String(),
                        TotalPurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.Customers", t => t.CustomersId, cascadeDelete: true)
                .Index(t => t.CustomersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CustomersId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomersId" });
            DropTable("dbo.Transactions");
        }
    }
}
