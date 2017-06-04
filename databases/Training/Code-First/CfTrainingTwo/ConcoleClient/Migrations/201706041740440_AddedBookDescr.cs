namespace ConcoleClient.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBookDescr : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Description", c => c.String(storeType: "ntext"));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Description");
        }
    }
}
