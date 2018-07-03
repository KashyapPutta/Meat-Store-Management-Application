namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgainDroppingMeatRatesAndMeatKind : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.MeatRates", "MeatName_MeatId", "dbo.MeatKinds");
            DropIndex("dbo.MeatRates", new[] { "MeatName_MeatId" });
            DropTable("dbo.MeatKinds");
            DropTable("dbo.MeatRates");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.MeatRates",
                c => new
                    {
                        MeatTypeId = c.Int(nullable: false, identity: true),
                        CostPerLb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerLbBoneless = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeatName_MeatId = c.Int(),
                    })
                .PrimaryKey(t => t.MeatTypeId);
            
            CreateTable(
                "dbo.MeatKinds",
                c => new
                    {
                        MeatId = c.Int(nullable: false, identity: true),
                        MeatName = c.String(),
                    })
                .PrimaryKey(t => t.MeatId);
            
            CreateIndex("dbo.MeatRates", "MeatName_MeatId");
            AddForeignKey("dbo.MeatRates", "MeatName_MeatId", "dbo.MeatKinds", "MeatId");
        }
    }
}
