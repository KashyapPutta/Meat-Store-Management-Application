namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeatTypeAsForeignKeyToSupplies : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Supplies", "MeatType", c => c.String(maxLength: 128));
            CreateIndex("dbo.Supplies", "MeatType");
            AddForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates", "MeatType");
            DropColumn("dbo.Supplies", "SuppliedMeatType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Supplies", "SuppliedMeatType", c => c.String());
            DropForeignKey("dbo.Supplies", "MeatType", "dbo.MeatRates");
            DropIndex("dbo.Supplies", new[] { "MeatType" });
            DropColumn("dbo.Supplies", "MeatType");
        }
    }
}
