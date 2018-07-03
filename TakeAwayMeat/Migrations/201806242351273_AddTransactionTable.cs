namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTransactionTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionId = c.Int(nullable: false, identity: true),
                        QuantityPurchased = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeatKindId = c.Int(nullable: false),
                        BoneMeatQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        BonelessMeatQuantity = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalPurchaseAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionDateTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionId)
                .ForeignKey("dbo.MeatKinds", t => t.MeatKindId, cascadeDelete: true)
                .Index(t => t.MeatKindId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "MeatKindId", "dbo.MeatKinds");
            DropIndex("dbo.Transactions", new[] { "MeatKindId" });
            DropTable("dbo.Transactions");
        }
    }
}
