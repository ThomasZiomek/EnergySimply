using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnergySimplyDAL.Models;
using System.Data.Entity;

namespace EnergySimplyDAL.Repos
{
    public class PlanRepo : BaseRepo<Plan>, IRepo<Plan>
    {
        public PlanRepo()
        {
            Table = Context.Plans;
        }

        public int Delete(int id)
        {
            Context.Entry(new Plan() { PlanID = id }).State = EntityState.Deleted;
            return SaveChanges();
        }

        public Task<int> DeleteAsync(int id)
        {
            Context.Entry(new Plan() { PlanID = id }).State = EntityState.Deleted;
            return SaveChangesAsync();
        }
    }
}
