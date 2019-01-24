using System;
using System.Web.Http;
using EMS.Model;
using EMS.WebAPI.Models;
namespace EMS.WebAPI.Controllers
{
    public class EmployeeController : BaseApiController, IDisposable
    {
        EmployeeModel model;
        public EmployeeController()
        {
            model = new EmployeeModel();
        }

        /// <summary>
        /// Insert or Update the EMployee
        /// </summary>
        /// <param name="employeeAttributeModel"></param>
        /// <returns></returns>
        [Route("api/Employee")]
        [HttpPost]
        public BaseAttributeModel Save(EmployeeAttributeModel employeeAttributeModel)
        {
            return model.InsertUpdateEmployee(employeeAttributeModel);
        }


        /// <summary>
        /// Get the Employee Details By EmpId
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [Route("api/Employee/{empId:int}")]
        [HttpGet]
        public EmployeeAttributeModel Get(int empId)
        {
            return model.GetEmployeeByEmpId(empId);
        }

        /// <summary>
        /// Get the EMployees List
        /// </summary>
        /// <returns></returns>
        [Route("api/Employee/List")]
        [HttpGet]
        public EmployeeListAttributeModel GetEmployees()
        {
            return model.GetEmployees();
        }


        /// <summary>
        /// Get the Master Data Details
        /// </summary>
        /// <returns></returns>
        [Route("api/Employee/MasterData")]
        [HttpGet]
        public MasterDataAttributeModel GetMasterData()
        {
            return model.GetMasterData();
        }

        /// <summary>
        /// Inactivate the employee instead of delete
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [Route("api/Employee/Delete/{empId:int}")]
        [HttpGet]
        public BaseAttributeModel InActiveEmployeeByEmpId(int empId)
        {
            return model.InActiveEmployeeByEmpId(empId);
        }

        protected override void Dispose(bool disposing)
        {
            model.Dispose();
            GC.Collect();
        }
	}
}