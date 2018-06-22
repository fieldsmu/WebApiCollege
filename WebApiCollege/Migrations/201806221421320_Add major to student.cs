namespace WebApiCollege.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmajortostudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "MajorId", c => c.Int(nullable: false));
            CreateIndex("dbo.Students", "MajorId");
            AddForeignKey("dbo.Students", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Students", "MajorId", "dbo.Majors");
            DropIndex("dbo.Students", new[] { "MajorId" });
            DropColumn("dbo.Students", "MajorId");
        }
    }
}
