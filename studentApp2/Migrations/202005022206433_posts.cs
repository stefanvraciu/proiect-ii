namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class posts : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GeneralPosts",
                c => new
                    {
                        GeneralPostID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GeneralPostID)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostID = c.Int(nullable: false, identity: true),
                        PostTitle = c.String(),
                        PostBody = c.String(),
                    })
                .PrimaryKey(t => t.PostID);
            
            CreateTable(
                "dbo.GroupPosts",
                c => new
                    {
                        GroupPostID = c.Int(nullable: false, identity: true),
                        PostID = c.Int(nullable: false),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupPostID)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.YearPosts",
                c => new
                    {
                        YearPostId = c.Int(nullable: false, identity: true),
                        YearPostYear = c.Int(nullable: false),
                        PostID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.YearPostId)
                .ForeignKey("dbo.Posts", t => t.PostID, cascadeDelete: true)
                .Index(t => t.PostID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearPosts", "PostID", "dbo.Posts");
            DropForeignKey("dbo.GroupPosts", "PostID", "dbo.Posts");
            DropForeignKey("dbo.GroupPosts", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.GeneralPosts", "PostID", "dbo.Posts");
            DropIndex("dbo.YearPosts", new[] { "PostID" });
            DropIndex("dbo.GroupPosts", new[] { "GroupId" });
            DropIndex("dbo.GroupPosts", new[] { "PostID" });
            DropIndex("dbo.GeneralPosts", new[] { "PostID" });
            DropTable("dbo.YearPosts");
            DropTable("dbo.GroupPosts");
            DropTable("dbo.Posts");
            DropTable("dbo.GeneralPosts");
        }
    }
}
