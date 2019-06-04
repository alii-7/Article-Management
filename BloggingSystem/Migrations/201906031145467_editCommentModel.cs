namespace BloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCommentModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentText", c => c.String(nullable: false));
            DropColumn("dbo.Comments", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            DropColumn("dbo.Comments", "CommentText");
        }
    }
}
