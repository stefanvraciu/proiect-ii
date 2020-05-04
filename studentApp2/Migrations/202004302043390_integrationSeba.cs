namespace studentApp2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class integrationSeba : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CourseDepartments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        CourseName = c.String(),
                        CourseYear = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
            CreateTable(
                "dbo.TeacherCourses",
                c => new
                    {
                        TeacherCoursesID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                        TeacherID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherCoursesID)
                .ForeignKey("dbo.Courses", t => t.CourseID, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.CourseID)
                .Index(t => t.TeacherID);
            
            CreateTable(
                "dbo.TeacherCoursesGroups",
                c => new
                    {
                        TeacherCoursesGroupID = c.Int(nullable: false, identity: true),
                        TeacherCoursesID = c.Int(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TeacherCoursesGroupID)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .ForeignKey("dbo.TeacherCourses", t => t.TeacherCoursesID, cascadeDelete: true)
                .Index(t => t.TeacherCoursesID)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        DepartmentID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Departments", t => t.DepartmentID, cascadeDelete: true)
                .Index(t => t.DepartmentID);
            
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentID = c.Int(nullable: false, identity: true),
                        DepartmentName = c.String(),
                    })
                .PrimaryKey(t => t.DepartmentID);
            
            AddColumn("dbo.Students", "GroupID", c => c.Int(nullable: false));
            AddColumn("dbo.Students", "YearOfStudy", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "GroupID");
            AddForeignKey("dbo.Students", "GroupID", "dbo.Groups", "GroupID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeacherCoursesGroups", "TeacherCoursesID", "dbo.TeacherCourses");
            DropForeignKey("dbo.TeacherCoursesGroups", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Students", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.CourseDepartments", "DepartmentID", "dbo.Departments");
            DropForeignKey("dbo.TeacherCourses", "TeacherID", "dbo.Teachers");
            DropForeignKey("dbo.TeacherCourses", "CourseID", "dbo.Courses");
            DropForeignKey("dbo.CourseDepartments", "CourseID", "dbo.Courses");
            DropIndex("dbo.Students", new[] { "GroupID" });
            DropIndex("dbo.Groups", new[] { "DepartmentID" });
            DropIndex("dbo.TeacherCoursesGroups", new[] { "GroupID" });
            DropIndex("dbo.TeacherCoursesGroups", new[] { "TeacherCoursesID" });
            DropIndex("dbo.TeacherCourses", new[] { "TeacherID" });
            DropIndex("dbo.TeacherCourses", new[] { "CourseID" });
            DropIndex("dbo.CourseDepartments", new[] { "DepartmentID" });
            DropIndex("dbo.CourseDepartments", new[] { "CourseID" });
            DropColumn("dbo.Students", "YearOfStudy");
            DropColumn("dbo.Students", "GroupID");
            DropTable("dbo.Departments");
            DropTable("dbo.Groups");
            DropTable("dbo.TeacherCoursesGroups");
            DropTable("dbo.TeacherCourses");
            DropTable("dbo.Courses");
            DropTable("dbo.CourseDepartments");
        }
    }
}
