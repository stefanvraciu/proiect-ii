namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentId1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "AppUser_Id" });
            AddColumn("dbo.Students", "UId", c => c.String(nullable: false));
            DropColumn("dbo.Students", "AppUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "AppUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Students", "UId");
            CreateIndex("dbo.Students", "AppUser_Id");
            AddForeignKey("dbo.Students", "AppUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
