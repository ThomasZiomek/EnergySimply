namespace EnergySimplyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustEmailRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "CustEmail", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customer", "CustEmail", c => c.String(maxLength: 100));
        }
    }
}
