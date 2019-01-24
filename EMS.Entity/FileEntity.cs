using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EMS.Entity
{
    public class File:BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FileId { get; set; }

        [Required]
        public int EmpId { get; set; }

        [MaxLength(50)]
        [Required]
        public string FileUId { get; set; }

        [MaxLength(200)]
        [Required]
        public string FileName { get; set; }

        [MaxLength(400)]
        [Required]
        public string FilePath { get; set; }

        [ForeignKey("EmpId")]
        public virtual Employee Employee { get; set; }       
    }
}
