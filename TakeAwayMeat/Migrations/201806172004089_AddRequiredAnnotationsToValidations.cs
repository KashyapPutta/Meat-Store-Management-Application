namespace TakeAwayMeat.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRequiredAnnotationsToValidations : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "NameOfCustomer", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "NameOfCustomer", c => c.String());
        }
    }
}
