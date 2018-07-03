namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TruncateMeatRates : DbMigration
    {
        public override void Up()
        {
            Sql("TRUNCATE TABLE MeatRates");
        }
        
        public override void Down()
        {
        }
    }
}
