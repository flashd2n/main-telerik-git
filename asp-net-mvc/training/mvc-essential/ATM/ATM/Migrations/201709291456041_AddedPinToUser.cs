namespace ATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPinToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "Pin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "Pin");
        }
    }
}
