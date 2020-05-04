namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "AppUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Students", "AppUser_Id");
            AddForeignKey("dbo.Students", "AppUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Students", "UId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "UId", c => c.String());
            DropForeignKey("dbo.Students", "AppUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "AppUser_Id" });
            DropColumn("dbo.Students", "AppUser_Id");
        }
    }
}
