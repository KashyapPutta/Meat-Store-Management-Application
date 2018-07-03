namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributeToMeatTypeToSupplies : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates");
            DropIndex("dbo.Supplies", new[] { "MeatType" });
            AlterColumn("dbo.Supplies", "MeatType", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Supplies", "MeatType");
            AddForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates", "MeatType", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates");
            DropIndex("dbo.Supplies", new[] { "MeatType" });
            AlterColumn("dbo.Supplies", "MeatType", c => c.String(maxLength: 128));
            CreateIndex("dbo.Supplies", "MeatType");
            AddForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates", "MeatType");
        }
    }
}
