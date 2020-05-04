namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameUsers : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Firstname", c => c.String(nullable: false));
            AddColumn("dbo.AspNetUsers", "Lastname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Lastname");
            DropColumn("dbo.AspNetUsers", "Firstname");
        }
    }
}