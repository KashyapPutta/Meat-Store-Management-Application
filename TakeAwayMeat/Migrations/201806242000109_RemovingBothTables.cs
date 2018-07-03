namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovingBothTables : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeatRates", "MeatKindId", "dbo.MeatKinds");
            DropIndex("dbo.MeatRates", new[] { "MeatKindId" });
            DropTable("dbo.MeatKinds");
            DropTable("dbo.MeatRates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeatRates",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatKindId = c.Int(nullable: false),
                        CostPerLb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerLbBoneless = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.MeatKinds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.MeatRates", "MeatKindId");
            AddForeignKey("dbo.MeatRates", "MeatKindId", "dbo.MeatKinds", "Id", cascadeDelete: true);
        }
    }
}
