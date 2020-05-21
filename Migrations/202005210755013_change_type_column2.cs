namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_column2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orderdetails",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 128),
                        ProductId = c.Int(nullable: false),
                        UnitPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Quantity = c.Int(nullable: false),
                        Discount = c.Int(nullable: false),
                        SubTotal = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.OrderId, t.ProductId })
                .ForeignKey("dbo.products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.orders",
                c => new
                    {
                        OrderId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        PostalCode = c.String(maxLength: 5),
                        Phone = c.String(maxLength: 10),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.users", t => t.UserId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.orders", "UserId", "dbo.users");
            DropForeignKey("dbo.orderdetails", "ProductId", "dbo.products");
            DropIndex("dbo.orders", new[] { "UserId" });
            DropIndex("dbo.orderdetails", new[] { "ProductId" });
            DropTable("dbo.orders");
            DropTable("dbo.orderdetails");
        }
    }
}
