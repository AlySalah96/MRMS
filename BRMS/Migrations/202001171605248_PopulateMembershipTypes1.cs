namespace BRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMembershipTypes1 : DbMigration
    {
        public override void Up()
        {
            Sql("Update  MembershipTypes set Name ='Pay as you Go' where Id =1");
            Sql("Update  MembershipTypes set Name ='monthly' where Id =2");
            Sql("Update  MembershipTypes set Name='Quarterly' where Id =3");
            Sql("Update  MembershipTypes set Name= 'annoual'  where Id =4");

        }

        public override void Down()
        {
        }
    }
}
