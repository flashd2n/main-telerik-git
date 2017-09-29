namespace ATM.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTransactionModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        CheckingAccountId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CheckingAccounts", t => t.CheckingAccountId, cascadeDelete: true)
                .Index(t => t.CheckingAccountId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "CheckingAccountId", "dbo.CheckingAccounts");
            DropIndex("dbo.Transactions", new[] { "CheckingAccountId" });
            DropTable("dbo.Transactions");
        }
    }
}
