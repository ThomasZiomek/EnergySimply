using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergySimplyDAL.Models;
using System.Data.Entity;

namespace EnergySimplyDAL.Repos
{
    public class CustomerRepo: BaseRepo<Customer>, IRepo<Customer>
    {
        public CustomerRepo()
        {
            Table = Context.Customers;
        }

        public int Delete(int id)
        {
            Context.Entry(new Customer() { CustID = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Customer() { CustID = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
