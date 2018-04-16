using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnergySimplyDAL.Models;
using EnergySimplyDAL.Repos;

namespace EnergySimplyWeb
{
    public partial class ListCustomersAndPlans : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<CustomersAndPlans> GridViewCustomersAndPlans_GetData()
        {
            List<CustomersAndPlans> customerPlans = new List<CustomersAndPlans>();

            var customers = new CustomerRepo().GetAll();
            foreach (var c in customers)
            {
                var planInfo = new PlanRepo().GetOne(c.PlanID);
                customerPlans.Add(new CustomersAndPlans
                {
                    CustID = c.CustID,
                    CustName = c.CustName,
                    CustEmail = c.CustEmail,
                    PlanName = planInfo.PlanName,
                    PlanFixedCost = planInfo.PlanFixedCost,
                    PlanVarCost = planInfo.PlanVarCost
                });
            }

            return customerPlans;
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        //public IQueryable<EnergySimplyDAL.Models.Customer> GridViewCustomersPlans_GetData()
        // TODO: Do above for sorting!!
        //public IEnumerable<Customer> GridViewCustomersPlans_GetData() => new CustomerRepo().GetAll();
        //public IList<string>
    }
}