namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class edit_colme_product_detail : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.products", "ProductDetail", c => c.String(maxLength: 300));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.products", "ProductDetail", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
