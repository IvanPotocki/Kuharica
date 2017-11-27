namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateRecipeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Type = c.String(nullable: false, maxLength: 225),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Time = c.DateTime(nullable: false),
                        Name = c.String(nullable: false),
                        Chef_Id = c.String(nullable: false, maxLength: 128),
                        Meal_Id = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Chef_Id, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_Id, cascadeDelete: true)
                .Index(t => t.Chef_Id)
                .Index(t => t.Meal_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.Recipes", "Chef_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "Meal_Id" });
            DropIndex("dbo.Recipes", new[] { "Chef_Id" });
            DropTable("dbo.Recipes");
            DropTable("dbo.Meals");
        }
    }
}
