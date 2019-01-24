using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
namespace EMS.Entity
{
    public class Language:BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LanguageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MaxLength(50)]
        [Required]
        public string LanguageName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public virtual List<EmployeeLanguage> EmployeeLanguages { get; set; }
    }
}
