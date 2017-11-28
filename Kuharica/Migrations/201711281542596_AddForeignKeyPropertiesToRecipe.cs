namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddForeignKeyPropertiesToRecipe : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Recipes", name: "Chef_Id", newName: "ChefId");
            RenameColumn(table: "dbo.Recipes", name: "Meal_Id", newName: "MealId");
            RenameIndex(table: "dbo.Recipes", name: "IX_Chef_Id", newName: "IX_ChefId");
            RenameIndex(table: "dbo.Recipes", name: "IX_Meal_Id", newName: "IX_MealId");
            DropPrimaryKey("dbo.Recipes");
            AlterColumn("dbo.Recipes", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Recipes", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Recipes");
            AlterColumn("dbo.Recipes", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Recipes", "Id");
            RenameIndex(table: "dbo.Recipes", name: "IX_MealId", newName: "IX_Meal_Id");
            RenameIndex(table: "dbo.Recipes", name: "IX_ChefId", newName: "IX_Chef_Id");
            RenameColumn(table: "dbo.Recipes", name: "MealId", newName: "Meal_Id");
            RenameColumn(table: "dbo.Recipes", name: "ChefId", newName: "Chef_Id");
        }
    }
}
