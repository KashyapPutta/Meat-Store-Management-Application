namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCustomerIdAndCustomerNameFromTransactionTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Transactions", "CustomersId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "CustomersId" });
            DropColumn("dbo.Transactions", "CustomersId");
            DropColumn("dbo.Transactions", "NameOfTheCustomer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Transactions", "NameOfTheCustomer", c => c.String());
            AddColumn("dbo.Transactions", "CustomersId", c => c.Int(nullable: false));
            CreateIndex("dbo.Transactions", "CustomersId");
            AddForeignKey("dbo.Transactions", "CustomersId", "dbo.Customers", "Id", cascadeDelete: true);
        }
    }
}
