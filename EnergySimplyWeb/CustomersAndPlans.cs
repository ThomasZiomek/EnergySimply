using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EnergySimplyWeb
{
    public class CustomersAndPlans
    {
        public int CustID { get; set; }
        public string CustName { get; set; }
        public string CustEmail { get; set; }
        public string PlanName { get; set; }
        public decimal PlanFixedCost { get; set; }
        public decimal PlanVarCost { get; set; }
    }


}