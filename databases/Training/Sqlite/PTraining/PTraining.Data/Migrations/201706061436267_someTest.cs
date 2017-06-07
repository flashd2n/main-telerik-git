namespace PTraining.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class someTest : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "public.Blogs", newSchema: "dbo");
            MoveTable(name: "public.Posts", newSchema: "dbo");
        }
        
        public override void Down()
        {
            MoveTable(name: "dbo.Posts", newSchema: "public");
            MoveTable(name: "dbo.Blogs", newSchema: "public");
        }
    }
}
