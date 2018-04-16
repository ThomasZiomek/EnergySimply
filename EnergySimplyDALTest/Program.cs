using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EnergySimplyDAL.EF;
using static System.Console;
using EnergySimplyDAL.Repos;
using EnergySimplyDAL.Models;

namespace EnergySimplyDALTest
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Beginning db seed...");
            Database.SetInitializer(new DataInitializer());

            WriteLine("Testing EnergySimplyDAL...");

            var cust1 = new Customer() { CustID = 201, CustName = "Tom", CustEmail = "tom@yahoo.com", PlanID = 123 };
            var cust2 = new Customer() { CustID = 202, CustName = "Tom2", CustEmail = "tom2@yahoo.com", PlanID = 456 };
            var cust3 = new Customer() { CustID = 203, CustName = "Tom3", CustEmail = "tom3@yahoo.com", PlanID = 789 };
            AddNewRecord(cust1);
            AddNewRecords(new List<Customer> { cust2, cust3 });

            WriteLine("Customer list:");
            PrintAllCustomers();

            //WriteLine($"Updating customer {cust3.CustName}:");
            //UpdateRecord(cust3.CustID);
            //PrintAllCustomers();

            WriteLine("DB Initialization complete. Press any key to exit...");
            ReadKey();
        }

        private static void PrintAllCustomers()
        {
            using (var repo = new CustomerRepo())
            {
                WriteLine("CustID\tCustName\tCustEmail\t\tPlanName\t\tFixedCost\tVarCost");

                foreach (Customer c in repo.GetAll())
                {
                    WriteLine($"{c.CustID}\t{c.CustName}\t{c.CustEmail}\t\t{c.Plan.PlanName}\t\t{c.Plan.PlanFixedCost}\t{c.Plan.PlanVarCost}");
                }
            }
        }

        private static void AddNewRecord(Customer cust)
        {
            using (var repo = new CustomerRepo())
            {
                repo.Add(cust);
            }
        }

        private static void AddNewRecords(IList<Customer> customers)
        {
            using (var repo = new CustomerRepo())
            {
                repo.AddRange(customers);
            }
        }

        private static void UpdateRecord(int custID)
        {
            using (var repo = new CustomerRepo())
            {
                var custToUpdate = repo.GetOne(custID);

                if (custToUpdate != null)
                {
                    WriteLine($"Before update: { repo.Context.Entry(custToUpdate).State }");
                    custToUpdate.CustEmail = "updated@email.com";
                    WriteLine($"After update: { repo.Context.Entry(custToUpdate).State}");
                    repo.Save(custToUpdate);
                    WriteLine($"After save: {repo.Context.Entry(custToUpdate).State}");
                }
            }
        }
    }
}
