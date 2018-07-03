namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToMeatKind : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MeatKinds(MeatName) VALUES('Chicken')");
        }
        
        public override void Down()
        {
        }
    }
}
