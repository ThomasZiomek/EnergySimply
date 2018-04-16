using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EnergySimplyDAL.Models
{
    [Table("Customer")]
    public partial class Customer
    {
        [Key, Required, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //[Key, Required]
        public int CustID { get; set; }

        [StringLength(100),Required]
        public string CustName { get; set; }

        [StringLength(100),Required]
        public string CustEmail { get; set; }

        [Required]
        public int PlanID { get; set; }

        [ForeignKey("PlanID")]
        public virtual Plan Plan { get; set; }
    }
}
