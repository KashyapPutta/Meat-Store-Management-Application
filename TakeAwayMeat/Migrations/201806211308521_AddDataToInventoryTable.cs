namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataToInventoryTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Inventories(MeatTypeInStock, QuantityInStock) Values('Beef', 50)");
            Sql("INSERT INTO Inventories(MeatTypeInStock, QuantityInStock) Values('Chicken', 50)");
            Sql("INSERT INTO Inventories(MeatTypeInStock, QuantityInStock) Values('Fish', 50)");
        }
        
        public override void Down()
        {
        }
    }
}
