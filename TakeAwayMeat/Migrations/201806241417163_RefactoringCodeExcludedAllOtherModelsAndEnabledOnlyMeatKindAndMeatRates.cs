namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RefactoringCodeExcludedAllOtherModelsAndEnabledOnlyMeatKindAndMeatRates : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MeatKinds",
                c => new
                    {
                        MeatId = c.Int(nullable: false, identity: true),
                        MeatName = c.String(),
                    })
                .PrimaryKey(t => t.MeatId);
            
            CreateTable(
                "dbo.MeatRates",
                c => new
                    {
                        MeatTypeId = c.Int(nullable: false, identity: true),
                        CostPerLb = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CostPerLbBoneless = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MeatName_MeatId = c.Int(),
                    })
                .PrimaryKey(t => t.MeatTypeId)
                .ForeignKey("dbo.MeatKinds", t => t.MeatName_MeatId)
                .Index(t => t.MeatName_MeatId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MeatRates", "MeatName_MeatId", "dbo.MeatKinds");
            DropIndex("dbo.MeatRates", new[] { "MeatName_MeatId" });
            DropTable("dbo.MeatRates");
            DropTable("dbo.MeatKinds");
        }
    }
}
