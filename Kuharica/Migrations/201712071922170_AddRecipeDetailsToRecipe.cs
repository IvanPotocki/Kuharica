namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRecipeDetailsToRecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "Description", c => c.String());
            AddColumn("dbo.Recipes", "Ingredient", c => c.String());
            AddColumn("dbo.Recipes", "Serving", c => c.String());
            AddColumn("dbo.Recipes", "PreparationInstruction", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "PreparationInstruction");
            DropColumn("dbo.Recipes", "Serving");
            DropColumn("dbo.Recipes", "Ingredient");
            DropColumn("dbo.Recipes", "Description");
        }
    }
}
