namespace EnergySimplyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identities : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customer", "CustName", c => c.String(nullable: false, maxLength: 100));
            AlterColumn("dbo.Plan", "PlanName", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Plan", "PlanName", c => c.String(maxLength: 50));
            AlterColumn("dbo.Customer", "CustName", c => c.String(maxLength: 100));
        }
    }
}
