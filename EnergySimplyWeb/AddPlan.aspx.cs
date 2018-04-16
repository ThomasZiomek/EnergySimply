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
    public partial class AddPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //gridViewPlans.Visible = false;
            panelDisplayPlans.Visible = false;
        }

        protected void Wizard1_FinishButtonClick(object sender, WizardNavigationEventArgs e)
        {
            //var plan = new Plan
            //{
            //    PlanName = txtPlanName.Text,
            //    PlanFixedCost = Decimal.Parse(txtPlanFixedCost.Text),
            //    PlanVarCost = Decimal.Parse(txtPlanVarCost.Text)
            //};

            //var repo = new PlanRepo();

            //try
            //{
            //    int returnVal = repo.Add(plan);
            //    gridViewPlans.Visible = true;
            //    Wizard1.Visible = false;
            //    lblPlanInstructions.Visible = false;
            //    lblShowPlans.Text = "Plan successfully added. Here is the updated list:";
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IEnumerable<Plan> GridViewPlans_GetData() => new PlanRepo().GetAll();

        protected void btnAddPlan_Click(object sender, EventArgs e)
        {
            var plan = new Plan
            {
                PlanName = txtPlanName.Text,
                PlanFixedCost = Decimal.Parse(txtPlanFixedCost.Text),
                PlanVarCost = Decimal.Parse(txtPlanVarCost.Text)
            };

            var repo = new PlanRepo();

            try
            {
                int returnVal = repo.Add(plan);
                panelDisplayPlans.Visible = true;
                gridViewPlans.Visible = true;
                //Wizard1.Visible = false;
                //lblPlanInstructions.Visible = false;
                panelAddPlan.Visible = false;
                lblShowPlans.Text = "Plan successfully added. Here is the updated list:";
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}