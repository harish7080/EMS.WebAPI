using System.Collections.Generic;
using EMS.Data;
using EMS.Entity;
using System;
namespace EMS.Services
{
    public class EmployeeServiceManager : IDisposable
    {
        private EmployeeDataManager employeeDataManager;
        public EmployeeServiceManager()
        {
            employeeDataManager = new EmployeeDataManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  List<Employee> GetEmployees()
        {
            return employeeDataManager.GetEmployees();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="employee"></param>
        /// <param name="employeeLanguagesList"></param>
        /// <param name="files"></param>
        /// <returns></returns>
        public  bool InsertUpdateEmployee(Employee employee)
        {
            return employeeDataManager.InsertUpdateEmployee(employee);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public bool InActiveEmployeeByEmpId(int empId)
        {
            return employeeDataManager.InActiveEmployeeByEmpId(empId);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public Employee GetEmployeeByEmpId(int empId)
        {
            return employeeDataManager.GetEmployeeByEmpId(empId);
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            //Dipose the Context
            employeeDataManager.Dispose();

            // call the Garbage collector
            GC.Collect();
        }
    }
}
