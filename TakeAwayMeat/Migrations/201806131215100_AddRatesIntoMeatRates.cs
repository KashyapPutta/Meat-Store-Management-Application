namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRatesIntoMeatRates : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MeatRates(MeatType, CostPerLb, CostPerLbBoneless) VALUES ('Chicken', 5, 8)");
            Sql("INSERT INTO MeatRates(MeatType, CostPerLb, CostPerLbBoneless) VALUES ('Beef', 3, 4)");
            Sql("INSERT INTO MeatRates(MeatType, CostPerLb, CostPerLbBoneless) VALUES ('Fish', 8 , 12)");
        }
        
        public override void Down()
        {
        }
    }
}
