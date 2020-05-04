namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Students", "appUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Students", new[] { "appUser_Id" });
            AddColumn("dbo.Students", "UId", c => c.String());
            DropColumn("dbo.Students", "appUser_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "appUser_Id", c => c.String(maxLength: 128));
            DropColumn("dbo.Students", "UId");
            CreateIndex("dbo.Students", "appUser_Id");
            AddForeignKey("dbo.Students", "appUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
