namespace TaskRobo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AppUsers",
                c => new
                    {
                        EmailId = c.String(nullable: false, maxLength: 128),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EmailId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryTitle = c.String(nullable: false),
                        EmailId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.CategoryId)
                .ForeignKey("dbo.AppUsers", t => t.EmailId)
                .Index(t => t.EmailId);
            
            CreateTable(
                "dbo.UserTasks",
                c => new
                    {
                        TaskId = c.Int(nullable: false, identity: true),
                        TaskTitle = c.String(nullable: false),
                        TaskContent = c.String(),
                        TaskStatus = c.String(),
                        EmailId = c.String(maxLength: 128),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TaskId)
                .ForeignKey("dbo.AppUsers", t => t.EmailId)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.EmailId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserTasks", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.UserTasks", "EmailId", "dbo.AppUsers");
            DropForeignKey("dbo.Categories", "EmailId", "dbo.AppUsers");
            DropIndex("dbo.UserTasks", new[] { "CategoryId" });
            DropIndex("dbo.UserTasks", new[] { "EmailId" });
            DropIndex("dbo.Categories", new[] { "EmailId" });
            DropTable("dbo.UserTasks");
            DropTable("dbo.Categories");
            DropTable("dbo.AppUsers");
        }
    }
}
