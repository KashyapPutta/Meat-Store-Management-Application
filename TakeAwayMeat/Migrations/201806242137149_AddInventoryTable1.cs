namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddInventoryTable1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Inventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MeatKindId = c.Int(nullable: false),
                        MeatTypeInStock = c.String(nullable: false),
                        QuantityInStock = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MeatKinds", t => t.MeatKindId, cascadeDelete: true)
                .Index(t => t.MeatKindId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Inventories", "MeatKindId", "dbo.MeatKinds");
            DropIndex("dbo.Inventories", new[] { "MeatKindId" });
            DropTable("dbo.Inventories");
        }
    }
}
