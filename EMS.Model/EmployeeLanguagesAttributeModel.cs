
namespace EMS.Model
{
    public class EmployeeLanguagesAttributeModel : BaseAttributeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EmpId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int LanguageId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }
    }
}