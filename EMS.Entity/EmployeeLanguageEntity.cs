using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMS.Entity
{
    public class EmployeeLanguage :BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int EmpId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [Required]
        public int LanguageId { get; set; }      


        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [ForeignKey("LanguageId")]
        public virtual Language Languages { get; set; } 
    }
}
