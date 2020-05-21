namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_product_detail : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.products", "ProductDetail", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
           
            
           
        }
    }
}
