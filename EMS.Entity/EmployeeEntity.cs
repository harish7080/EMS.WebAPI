using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMS.Entity
{
    public class Employee : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmpId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int StateId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("StateId")]
        public virtual State States { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<File> Files { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
