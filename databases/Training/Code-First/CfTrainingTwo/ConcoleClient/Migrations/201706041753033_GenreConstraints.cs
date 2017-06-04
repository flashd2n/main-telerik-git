namespace ConcoleClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GenreConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Name", c => c.String(nullable: false, maxLength: 40));
            CreateIndex("dbo.Genres", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Genres", new[] { "Name" });
            AlterColumn("dbo.Genres", "Name", c => c.String());
        }
    }
}
