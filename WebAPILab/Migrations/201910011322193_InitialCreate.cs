namespace WebAPILab.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        CustomerName = c.String(maxLength: 30),
                        CustomerEmail = c.String(maxLength: 25),
                        MobileNo = c.Double(nullable: false),
                        TransactionIds = c.String(),
                    })
                .PrimaryKey(t => t.CustomerId);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TransactionId = c.Int(nullable: false),
                        TransactionDateTime = c.DateTime(nullable: false),
                        Amount = c.Double(nullable: false),
                        CurrencyCode = c.String(maxLength: 3),
                        Status = c.Int(nullable: false),
                        Customer_CustomerId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_CustomerId)
                .Index(t => t.Customer_CustomerId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "Customer_CustomerId", "dbo.Customers");
            DropIndex("dbo.Transactions", new[] { "Customer_CustomerId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.Customers");
        }
    }
}
