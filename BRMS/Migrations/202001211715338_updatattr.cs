namespace BRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatattr : DbMigration
    {
        public override void Up()
        {
            Sql("Update Moveis set NumberAvailable = NumberInStock");

            //to intiall the values of NumberAvailable
        }

        public override void Down()
        {
        }
    }
}
