namespace KhabarYatri.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentDateTimeChanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comments", "CommentedTime", c => c.String());
            AlterColumn("dbo.Comments", "CommentedDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Comments", "CommentedDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.Comments", "CommentedTime");
        }
    }
}
