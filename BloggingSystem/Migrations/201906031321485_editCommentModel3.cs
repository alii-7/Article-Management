namespace BloggingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editCommentModel3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "User_Id" });
            DropColumn("dbo.Comments", "UserID");
            RenameColumn(table: "dbo.Comments", name: "User_Id", newName: "UserID");
            AlterColumn("dbo.Comments", "UserID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Comments", "UserID", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Comments", "UserID");
            AddForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "UserID", "dbo.AspNetUsers");
            DropIndex("dbo.Comments", new[] { "UserID" });
            AlterColumn("dbo.Comments", "UserID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "UserID", newName: "User_Id");
            AddColumn("dbo.Comments", "UserID", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "User_Id");
            AddForeignKey("dbo.Comments", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
