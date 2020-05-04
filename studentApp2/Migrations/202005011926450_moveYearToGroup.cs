namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class moveYearToGroup : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Groups", "YearOfStudy", c => c.Int(nullable: false));
            AlterColumn("dbo.Groups", "GroupName", c => c.String(nullable: false));
            DropColumn("dbo.Students", "YearOfStudy");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "YearOfStudy", c => c.Int());
            AlterColumn("dbo.Groups", "GroupName", c => c.String());
            DropColumn("dbo.Groups", "YearOfStudy");
        }
    }
}
