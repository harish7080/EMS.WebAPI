using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace EMS.Entity
{
    public class BaseEntity
    {
        /// <summary>
        /// IsActive Flag For Every Table
        /// </summary>
        [DefaultValue(true)]
        [Required]
        public bool IsActive { get; set; }
    }
}
