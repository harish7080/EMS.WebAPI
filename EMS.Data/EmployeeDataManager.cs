using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Entity;
namespace EMS.Data
{
    public class EmployeeDataManager : IDisposable
    {

        private EMSContext context;

        public  EmployeeDataManager()
        {
            context = new EMSContext();
        }

        /// <summary>
        /// For Getting Active Employee List
        /// </summary>
        /// <returns>list of active employees</returns>
        public List<Employee> GetEmployees()
        {
            //Set LazyLoading false for eliminate the unwanted data
            context.Configuration.LazyLoadingEnabled = false;
            var employeesList = context.Employee.Where(x=>x.IsActive==true).OrderBy(x=>x.FirstName).ToList();
            return employeesList;
        }

        /// <summary>
        /// Inactivate the old EmployeeLanguages Mapping Insert New
        /// </summary>
        /// <param name="employeeId">EmployeeId</param>
        /// <param name="employeeLanguagesList">Newly Inserted EmployeeLanguages Mapping</param>
        /// <param name="context">Employee Context</param>
        public void InsertEmployeeLanguages(int employeeId, List<EmployeeLanguage> employeeLanguagesList, EMSContext context)
        {
            //Remove old Employee Language Mappings
            var employeeLanguagesListExisted = context.EmployeeLanguage.Where(x => x.EmpId == employeeId).ToList();
            context.EmployeeLanguage.RemoveRange(employeeLanguagesListExisted);

            //Insert New Employee Language Mappings
            context.EmployeeLanguage.AddRange(employeeLanguagesList);

            context.SaveChanges();
        }

        /// <summary>
        /// For Insert or Update the Employee based on Employee Id(incliding the EmployeeLanguages Maps and Files)
        /// </summary>
        /// <param name="employee">Employee</param>
        /// <param name="employeeLanguagesList">employeeLanguages Maps List</param>
        /// <param name="files">Files Uploaded</param>
        /// <returns>True is for successfully transaction done , flase is not</returns>
        public bool InsertUpdateEmployee(Employee employee)
        {
            var flag = false;
            using (context)
            {
                //Begin the Transaction for Mutiple Table Data Isertion
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        if (employee.EmpId == 0)
                        {
                            employee = context.Employee.Add(employee);
                            context.SaveChanges();
                        }
                        else
                        {
                            //Insert Employee Landuage Mappings
                            InsertEmployeeLanguages(employee.EmpId, employee.EmployeeLanguages, context);


                            //Insert New Files 
                            FileDataManager.InsertFiles(employee.Files, employee.EmpId, context);

                            //Update Employee
                            context.Entry(employee).State = System.Data.Entity.EntityState.Modified;
                            context.SaveChanges();
                        }                    
                      
                        dbContextTransaction.Commit();
                        flag = true;
                    }
                    catch
                    {
                        dbContextTransaction.Rollback();
                        flag = false;

                        //Here we trace the Exception in DB
                    }                    
                }
            }
            return flag;
        }

        /// <summary>
        /// For Get Employee Details by EmployeeId including the Active EmployeeLanguagesMaps and Active Files
        /// </summary>
        /// <param name="empId">EmployeeId</param>
        /// <returns>Employee Object</returns>
        public Employee GetEmployeeByEmpId(int empId)
        {
            Employee employee = null;
            try
            {
                //Set LazyLoading false for eliminate the unwanted data
                context.Configuration.LazyLoadingEnabled=false;
                
                //Get the Employee Details by EmployeeId
                employee = context.Employee.Where(x => x.EmpId == empId && x.IsActive == true).FirstOrDefault();

                //Get the Employee Languages by EmployeeId
                employee.EmployeeLanguages = context.EmployeeLanguage.Where(x => x.EmpId == empId && x.IsActive == true).ToList();

                //Get the Files  by EmployeeId
                employee.Files = context.File.Where(x => x.EmpId == empId && x.IsActive == true).ToList();                
            }
            catch(Exception ex)
            {
                //Here we trace the Exception in DB
            }            

            return employee;
        }
        

        /// <summary>
        /// InActive the Employee instead of Delete by EmployeId
        /// </summary>
        /// <param name="empId">EmployeeId</param>
        /// <returns>True for successfully deleted , Flase - not</returns>
        public bool InActiveEmployeeByEmpId(int empId)
        {
            var flag = false;
            try
            {
                var meeting = context.Employee.Where(x => x.EmpId == empId).FirstOrDefault();
                meeting.IsActive = false;
                context.Entry(meeting).State = System.Data.Entity.EntityState.Modified;
                context.SaveChanges();
                flag = true;
            }
            catch (Exception ex)
            {
                flag = false;

                //Here we trace the Exception

            }           
            return flag;
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            //Dipose the Context
            context.Dispose();

            // call the Garbage collector
            GC.Collect();
        }
    } 
}
