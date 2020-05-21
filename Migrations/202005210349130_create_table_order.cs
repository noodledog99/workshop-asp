namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class create_table_order : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.orderdetails",
                c => new
                    {
                        OrderId = c.Int(nullable: false),
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
                        OrderId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        Country = c.String(),
                        Province = c.String(),
                        PostalCode = c.Int(nullable: false),
                        Phone = c.Int(nullable: false),
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
