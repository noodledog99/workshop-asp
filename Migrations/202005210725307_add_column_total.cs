namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_column_total : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.orders", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.orders", "Total");
        }
    }
}
