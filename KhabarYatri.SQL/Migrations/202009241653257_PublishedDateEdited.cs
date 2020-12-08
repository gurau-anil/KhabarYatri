namespace KhabarYatri.SQL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PublishedDateEdited : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Posts", "PublishedDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Posts", "PublishedDate", c => c.DateTime(nullable: false));
        }
    }
}
