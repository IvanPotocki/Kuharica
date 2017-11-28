namespace Kuharica.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeDateTimeNullableInRecipesTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Recipes", "Time", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Recipes", "Time", c => c.DateTime(nullable: false));
        }
    }
}
