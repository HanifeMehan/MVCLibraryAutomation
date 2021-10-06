namespace DataAccesLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Abouts",
                c => new
                    {
                        AboutID = c.Int(nullable: false, identity: true),
                        AboutDetails1 = c.String(),
                        AboutDetails2 = c.String(),
                        AboutImage1 = c.String(),
                        AboutImage2 = c.String(),
                    })
                .PrimaryKey(t => t.AboutID);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminUserName = c.String(maxLength: 50),
                        AdminPasswoed = c.String(maxLength: 50),
                        AdminRole = c.String(maxLength: 1),
                    })
                .PrimaryKey(t => t.AdminID);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryID = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                        CategoryDescription = c.String(maxLength: 500),
                        CategoryStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CategoryID);
            
            CreateTable(
                "dbo.Headings",
                c => new
                    {
                        HeadingID = c.Int(nullable: false, identity: true),
                        HeadingName = c.String(maxLength: 50),
                        HeadingDate = c.DateTime(nullable: false),
                        HeadingStatus = c.Boolean(nullable: false),
                        CategoryID = c.Int(nullable: false),
                        WriterId = c.Int(nullable: false),
                        Rezervation_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.HeadingID)
                .ForeignKey("dbo.Categories", t => t.CategoryID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterId, cascadeDelete: true)
                .ForeignKey("dbo.Rezervations", t => t.Rezervation_UserID)
                .Index(t => t.CategoryID)
                .Index(t => t.WriterId)
                .Index(t => t.Rezervation_UserID);
            
            CreateTable(
                "dbo.Contents",
                c => new
                    {
                        ContentID = c.Int(nullable: false, identity: true),
                        ContentValue = c.String(maxLength: 1000),
                        ContentTime = c.DateTime(nullable: false),
                        ContentStatus = c.Boolean(nullable: false),
                        HeadingID = c.Int(nullable: false),
                        WriterID = c.Int(),
                    })
                .PrimaryKey(t => t.ContentID)
                .ForeignKey("dbo.Headings", t => t.HeadingID, cascadeDelete: true)
                .ForeignKey("dbo.Writers", t => t.WriterID)
                .Index(t => t.HeadingID)
                .Index(t => t.WriterID);
            
            CreateTable(
                "dbo.Writers",
                c => new
                    {
                        WriterID = c.Int(nullable: false, identity: true),
                        WriterName = c.String(maxLength: 50),
                        WriterSurname = c.String(maxLength: 50),
                        WriterImage = c.String(maxLength: 250),
                        WriterMail = c.String(maxLength: 200),
                        WriterPassword = c.String(maxLength: 200),
                        WriterAbout = c.String(maxLength: 100),
                        WriterTitle = c.String(maxLength: 50),
                        WriterStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.WriterID);
            
            CreateTable(
                "dbo.Rezervations",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(maxLength: 50),
                        HeadingStatus = c.Boolean(nullable: false),
                        HeadingId = c.Int(nullable: false),
                        HeadingName = c.String(),
                        Heading_HeadingID = c.Int(),
                    })
                .PrimaryKey(t => t.UserID)
                .ForeignKey("dbo.Headings", t => t.Heading_HeadingID)
                .Index(t => t.Heading_HeadingID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Headings", "Rezervation_UserID", "dbo.Rezervations");
            DropForeignKey("dbo.Rezervations", "Heading_HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Headings", "WriterId", "dbo.Writers");
            DropForeignKey("dbo.Contents", "WriterID", "dbo.Writers");
            DropForeignKey("dbo.Contents", "HeadingID", "dbo.Headings");
            DropForeignKey("dbo.Headings", "CategoryID", "dbo.Categories");
            DropIndex("dbo.Rezervations", new[] { "Heading_HeadingID" });
            DropIndex("dbo.Contents", new[] { "WriterID" });
            DropIndex("dbo.Contents", new[] { "HeadingID" });
            DropIndex("dbo.Headings", new[] { "Rezervation_UserID" });
            DropIndex("dbo.Headings", new[] { "WriterId" });
            DropIndex("dbo.Headings", new[] { "CategoryID" });
            DropTable("dbo.Rezervations");
            DropTable("dbo.Writers");
            DropTable("dbo.Contents");
            DropTable("dbo.Headings");
            DropTable("dbo.Categories");
            DropTable("dbo.Admins");
            DropTable("dbo.Abouts");
        }
    }
}
