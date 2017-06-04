namespace ConcoleClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedLibrary : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Libraries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Library_Id", c => c.Int());
            CreateIndex("dbo.Books", "Library_Id");
            AddForeignKey("dbo.Books", "Library_Id", "dbo.Libraries", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Library_Id", "dbo.Libraries");
            DropIndex("dbo.Books", new[] { "Library_Id" });
            DropColumn("dbo.Books", "Library_Id");
            DropTable("dbo.Libraries");
        }
    }
}
