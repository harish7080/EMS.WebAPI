using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EMS.Model
{
    public class EmployeeAttributeModel : BaseAttributeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int EmpId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int Gender { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int StateId { get; set; }

        /// <summary>
        /// Instead of sending the list employeelanguages  maps we extract only LanguageIds from the list
        /// </summary>
        public int[] LanguageIds { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<EmployeeLanguagesAttributeModel> EmployeeLanguages { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public List<FileAttributeModel> Files { get; set; }
    }
}