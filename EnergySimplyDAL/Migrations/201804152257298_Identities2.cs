namespace EnergySimplyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Identities2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Customer", "PlanID", "dbo.Plan");
            DropPrimaryKey("dbo.Customer");
            DropPrimaryKey("dbo.Plan");
            AlterColumn("dbo.Customer", "CustID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Plan", "PlanID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Customer", "CustID");
            AddPrimaryKey("dbo.Plan", "PlanID");
            AddForeignKey("dbo.Customer", "PlanID", "dbo.Plan", "PlanID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "PlanID", "dbo.Plan");
            DropPrimaryKey("dbo.Plan");
            DropPrimaryKey("dbo.Customer");
            AlterColumn("dbo.Plan", "PlanID", c => c.Int(nullable: false));
            AlterColumn("dbo.Customer", "CustID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Plan", "PlanID");
            AddPrimaryKey("dbo.Customer", "CustID");
            AddForeignKey("dbo.Customer", "PlanID", "dbo.Plan", "PlanID", cascadeDelete: true);
        }
    }
}
