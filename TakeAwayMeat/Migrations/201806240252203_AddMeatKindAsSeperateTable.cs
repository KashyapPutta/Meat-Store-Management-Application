namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMeatKindAsSeperateTable : DbMigration
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MeatKinds");
        }
    }
}
