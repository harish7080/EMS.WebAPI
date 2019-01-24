using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMS.Entity
{
    public class State : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string StateName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<Employee> Employee { get; set; }
    }
}
