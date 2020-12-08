namespace KhabarYatri.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentedTimeRemoved : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Comments", "CommentedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Comments", "CommentedTime", c => c.DateTime(nullable: false));
        }
    }
}
