namespace BRMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedinguser : DbMigration
    {
        public override void Up()
        {
            Sql(@" INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'0cc48722-c9f8-4913-97bd-774c9ed09ee4', N'admin@BRMS.com', 0, N'AHkm+EQkcwOEvUo2QIFdjcEkVT+OhRXY1HL4AuEg7b+sVHJwLESAmhDHxUU560xPFg==', N'0bcf2a55-e9b9-4238-9af6-d44fc420650b', NULL, 0, 0, NULL, 1, 0, N'admin@BRMS.com')
            INSERT INTO[dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'cddd0e48-08ba-40f8-bfd0-7b3a11ff2d21', N'gest@BRMS.com', 0, N'APHBf08Kcdx2a1WEbkGOuu4ulF4NVMnWiTq3t1UDWcGrG0nERlRqMin74VL+3nwESA==', N'aeff0089-723f-4cf7-ba26-4972db90f28d', NULL, 0, 0, NULL, 1, 0, N'gest@BRMS.com')
              ");

            Sql(@"INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'73b81cd3-896b-48a6-b3d7-b26463f171c8', N'CanManageMovies')
              ");

            Sql(@"  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0cc48722-c9f8-4913-97bd-774c9ed09ee4', N'73b81cd3-896b-48a6-b3d7-b26463f171c8')
              ");

        }

    public override void Down()
        {
        }
    }
}
