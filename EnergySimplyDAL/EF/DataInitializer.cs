using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergySimplyDAL.Models;
using System.Data.Entity;

namespace EnergySimplyDAL.EF
{
    public class DataInitializer: DropCreateDatabaseAlways<EnergySimplyEntities>
    {
        public override void InitializeDatabase(EnergySimplyEntities context)
        {
            context.Database.ExecuteSqlCommand(TransactionalBehavior.DoNotEnsureTransaction
                , string.Format("ALTER DATABASE [{0}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE", context.Database.Connection.Database));

            base.InitializeDatabase(context);
        }

        protected override void Seed(EnergySimplyEntities context)
        {
            //base.Seed(context);


            /* Plan:
                PlanID (int) PlanName (string) PlanFixedCost (decimal) PlanVarCost (decimal)
                123 ComEd 6 7.99 0.10
                456 Amigo 3 0 0.12
                789 Amigo 12 4.99 0.11             
            */
            var plans = new List<Plan>
            {
                new Plan { PlanID = 123, PlanName = "ComEd 6", PlanFixedCost = 7.99M, PlanVarCost = 0.10M },
                new Plan { PlanID = 456, PlanName = "Amigo 3", PlanFixedCost = 0.00M, PlanVarCost = 0.12M },
                new Plan { PlanID = 789, PlanName = "Amigo 12", PlanFixedCost = 4.99M, PlanVarCost = 0.11M }
            };

            plans.ForEach(x => context.Plans.Add(x));

            /* Customer:
                12 Anne anne@gmail.com 123
                34 Bob bob@hotmail.com 456
                56 Chris chris@yahoo.com 789
                78 David david@aol.com 123
                90 Eric eric@energysimp.ly 123             * 
             */
            var customers = new List<Customer>
             {
                 new Customer { CustID = 12, CustName = "Anne", CustEmail = "anne@gmail.com", PlanID = 123 },
                 new Customer { CustID = 34, CustName = "Bob", CustEmail = "bob@hotmail.com", PlanID = 456 },
                 new Customer { CustID = 56, CustName = "Chris", CustEmail = "chris@yahoo.com", PlanID = 789 },
                 new Customer { CustID = 78, CustName = "David", CustEmail = "david@aol.com", PlanID = 123 },
                 new Customer { CustID = 90, CustName = "Eric", CustEmail = "eric@energysimp.ly", PlanID = 123 }
             };

            customers.ForEach(x => context.Customers.Add(x));

            context.SaveChanges();
        }
    }
}
