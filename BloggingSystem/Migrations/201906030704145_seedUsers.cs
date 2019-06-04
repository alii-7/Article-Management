namespace BloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'10b72958-6330-432d-afd1-e1cbf1320dad', N'admin@gmail.com', 0, N'ALWAww3JOSccLKZFmp1dSlM9ojpVk3PDqQfz6m5mOIm82+pz5GnC+Ott0fGK+gDBpw==', N'3efb5def-06fc-49ea-a700-1dfca11652e5', NULL, 0, 0, NULL, 1, 0, N'admin@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed44cb55-41b5-4c48-a182-8e6873c3f92d', N'guest@gmail.com', 0, N'AD/foStO7zmca5t2hmSKfIhH+hTEmSElGR+ksWabPH4UPjY2OolLJOyAICOkKuxQTw==', N'b2c8f666-b11c-4902-a843-d77ba6f5c395', NULL, 0, 0, NULL, 1, 0, N'guest@gmail.com')

                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'daf3c353-5587-4255-ac39-2a37b2694109', N'CanManageArticles')

                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'10b72958-6330-432d-afd1-e1cbf1320dad', N'daf3c353-5587-4255-ac39-2a37b2694109')

                ");
        }
        
        public override void Down()
        {
        } 
    }
}
