using System.Collections.Generic;

namespace EMS.Model
{
    public class EmployeeListAttributeModel:BaseAttributeModel
    {
        /// <summary>
        /// For the list of employees
        /// </summary>
        public List<EmployeeDetailsAttributeModel> employeeDetailsList { get; set; }
    }

    /// <summary>
    /// This class is for hold the required employee deatils for the list only
    /// </summary>
    public class EmployeeDetailsAttributeModel:BaseAttributeModel
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
    }
}