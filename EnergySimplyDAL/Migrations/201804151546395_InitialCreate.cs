namespace EnergySimplyDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustID = c.Int(nullable: false),
                        CustName = c.String(maxLength: 100),
                        CustEmail = c.String(maxLength: 100),
                        PlanID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustID)
                .ForeignKey("dbo.Plan", t => t.PlanID, cascadeDelete: true)
                .Index(t => t.PlanID);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        PlanID = c.Int(nullable: false),
                        PlanName = c.String(maxLength: 50),
                        PlanFixedCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PlanVarCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PlanID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customer", "PlanID", "dbo.Plan");
            DropIndex("dbo.Customer", new[] { "PlanID" });
            DropTable("dbo.Plan");
            DropTable("dbo.Customer");
        }
    }
}
