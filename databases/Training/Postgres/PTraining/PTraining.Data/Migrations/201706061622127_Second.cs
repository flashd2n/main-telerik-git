namespace PTraining.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Second : DbMigration
    {
        public override void Up()
        {
            MoveTable(name: "dbo.Blogs", newSchema: "public");
            MoveTable(name: "dbo.Posts", newSchema: "public");
        }
        
        public override void Down()
        {
            MoveTable(name: "public.Posts", newSchema: "dbo");
            MoveTable(name: "public.Blogs", newSchema: "dbo");
        }
    }
}
