namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class studentteacher : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teachers",
                c => new
                    {
                        TeacherId = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherId);
            
            AddColumn("dbo.Students", "UserId", c => c.String(nullable: false));
            DropColumn("dbo.Students", "StudentName");
            DropColumn("dbo.Students", "UId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "UId", c => c.String(nullable: false));
            AddColumn("dbo.Students", "StudentName", c => c.String());
            DropColumn("dbo.Students", "UserId");
            DropTable("dbo.Teachers");
        }
    }
}
