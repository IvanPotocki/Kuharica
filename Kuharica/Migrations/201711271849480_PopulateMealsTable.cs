namespace Kuharica.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class PopulateMealsTable : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Meals (Id, Type) VALUES (1, 'Doruèak')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (2, 'Ruèak')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (3, 'Veèera')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (4, 'Kolaè')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (5, 'Varivo')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (6, 'Vegetarijansko jelo')");
            Sql("INSERT INTO Meals (Id, Type) VALUES (7, 'Razno')");
        }

        public override void Down()
        {
            Sql("DELETE FROM Meals WHERE Id IN (1,2,3,4,5,6,7)");
        }
    }
}
