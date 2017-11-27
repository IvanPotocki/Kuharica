namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OverrideConventionForGigsName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Name", c => c.String(nullable: false));
        }
    }
}
