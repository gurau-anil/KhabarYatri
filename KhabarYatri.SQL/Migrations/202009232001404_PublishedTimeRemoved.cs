namespace KhabarYatri.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishedTimeRemoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Posts", "PostTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Posts", "PostBody", c => c.String(nullable: false));
            DropColumn("dbo.Posts", "PublishedTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PublishedTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Posts", "PostBody", c => c.String());
            AlterColumn("dbo.Posts", "PostTitle", c => c.String());
        }
    }
}
