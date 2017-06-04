namespace ConcoleClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BookConstraints : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.Books", new[] { "Library_Id" });
            AlterColumn("dbo.Books", "Title", c => c.String(nullable: false, maxLength: 40));
            AlterColumn("dbo.Books", "Library_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Library_Id");
            AddForeignKey("dbo.Books", "Library_Id", "dbo.Libraries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.Books", new[] { "Library_Id" });
            AlterColumn("dbo.Books", "Library_Id", c => c.Int());
            AlterColumn("dbo.Books", "Title", c => c.String());
            CreateIndex("dbo.Books", "Library_Id");
            AddForeignKey("dbo.Books", "Library_Id", "dbo.Libraries", "Id");
        }
    }
}
