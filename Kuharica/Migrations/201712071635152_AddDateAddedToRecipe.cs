namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDateAddedToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "DateAdded", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "DateAdded");
        }
    }
}
