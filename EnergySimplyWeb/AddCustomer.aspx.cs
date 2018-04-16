using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using EnergySimplyDAL.Repos;
using EnergySimplyDAL.Models;

namespace EnergySimplyWeb
{
    public partial class AddCustomer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            panelDisplayCustomers.Visible = false;
        }

        protected void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var selectedPlan = new PlanRepo().GetAll().Where(x => x.PlanName == cboPlan.SelectedValue).FirstOrDefault();
            //var plan = new PlanRepo().ExecuteQuery($"select planID from plan where planname = {cboPlan.SelectedValue};");


            var customer = new Customer
            {
                CustName = txtCustomerName.Text,
                CustEmail = txtCustomerEmail.Text,
                PlanID = selectedPlan.PlanID
            };

            var repo = new CustomerRepo();

            int returnVal = repo.Add(customer);
            panelDisplayCustomers.Visible = true;
            gridViewCustomers.Visible = true;
            panelAddCustomer.Visible = false;
            lblShowCustomers.Text = "Customer successfully added. Here is the updated list:";
        }

        public IEnumerable GetPlans() =>
            new PlanRepo().GetAll().Select(x => new { x.PlanName }).Distinct();

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Customer> gridViewCustomers_GetData() => new CustomerRepo().GetAll();
    }
}