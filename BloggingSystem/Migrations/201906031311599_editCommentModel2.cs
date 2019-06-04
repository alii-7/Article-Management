namespace BloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCommentModel2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comments", "UserID");
        }
    }
}
