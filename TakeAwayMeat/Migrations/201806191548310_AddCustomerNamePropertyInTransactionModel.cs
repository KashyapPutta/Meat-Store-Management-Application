namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCustomerNamePropertyInTransactionModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Transactions", "NameOfTheCustomer", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Transactions", "NameOfTheCustomer");
        }
    }
}
