namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drop_table : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.orderdetails", "ProductId", "dbo.products");
            DropForeignKey("dbo.orders", "UserId", "dbo.users");
            DropIndex("dbo.orderdetails", new[] { "ProductId" });
            DropIndex("dbo.orders", new[] { "UserId" });
            DropTable("dbo.orderdetails");
            DropTable("dbo.orders");
        }
        
        public override void Down()
        {
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
                        PostalCode = c.String(maxLength: 5),
                        Phone = c.String(maxLength: 10),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
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
                .PrimaryKey(t => new { t.OrderId, t.ProductId });
            
            CreateIndex("dbo.orders", "UserId");
            CreateIndex("dbo.orderdetails", "ProductId");
            AddForeignKey("dbo.orders", "UserId", "dbo.users", "UserId");
            AddForeignKey("dbo.orderdetails", "ProductId", "dbo.products", "ProductId", cascadeDelete: true);
        }
    }
}
