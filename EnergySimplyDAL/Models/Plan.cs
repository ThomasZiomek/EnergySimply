using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergySimplyDAL.Models
{
    [Table("Plan")]
    public partial class Plan
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Required]
        public int PlanID { get; set; }

        [StringLength(50),Required]
        public string PlanName { get; set; }

        [Required]
        public decimal PlanFixedCost { get; set; }

        [Required]
        public decimal PlanVarCost { get; set; }

        public virtual ICollection<Customer> CustPlans { get; set; } = new HashSet<Customer>();
    }
}
