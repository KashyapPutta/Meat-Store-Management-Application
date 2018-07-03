namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeDataTypesOfBoneAndBonelessTypeMeats : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "BoneMeatQuantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Transactions", "BonelessMeatQuantity", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.Transactions", "MeatTypeBone");
            DropColumn("dbo.Transactions", "MeatTypeBoneless");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "MeatTypeBoneless", c => c.String());
            AddColumn("dbo.Transactions", "MeatTypeBone", c => c.String());
            DropColumn("dbo.Transactions", "BonelessMeatQuantity");
            DropColumn("dbo.Transactions", "BoneMeatQuantity");
        }
    }
}
