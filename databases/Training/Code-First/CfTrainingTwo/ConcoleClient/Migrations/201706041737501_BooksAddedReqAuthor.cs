namespace ConcoleClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BooksAddedReqAuthor : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            AlterColumn("dbo.Books", "Author_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Author_Id", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "Author_Id" });
            AlterColumn("dbo.Books", "Author_Id", c => c.Int());
            CreateIndex("dbo.Books", "Author_Id");
            AddForeignKey("dbo.Books", "Author_Id", "dbo.Authors", "Id");
        }
    }
}
