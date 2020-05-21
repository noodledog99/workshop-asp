namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_order_status : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "OrderStatus", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.orders", "OrderStatus");
        }
    }
}
