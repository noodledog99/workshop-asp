namespace workshop_asp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class change_type_column : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.orders", "PostalCode", c => c.String(maxLength: 5));
            AlterColumn("dbo.orders", "Phone", c => c.String(maxLength: 10));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.orders", "Phone", c => c.Int(nullable: false));
            AlterColumn("dbo.orders", "PostalCode", c => c.Int(nullable: false));
        }
    }
}
