namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAttributesToConsignmentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Consignments", "BillAmount", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Consignments", "MeatType", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Consignments", "MeatType", c => c.String());
            DropColumn("dbo.Consignments", "BillAmount");
        }
    }
}
