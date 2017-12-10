namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameOfMealTableToRecipeCategoryTable : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Meals", newName: "RecipeCategory");
            RenameColumn(table: "dbo.RecipeCategory", name: "Type", newName: "Name");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.RecipeCategory", name: "Name", newName: "Type");
            RenameTable(name: "dbo.RecipeCategory", newName: "Meals");
        }
    }
}
