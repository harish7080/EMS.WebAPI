using EMS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using EMS.Entity;
using EMS.Services;
using EMS.WebAPI.Constants;
namespace EMS.WebAPI.Models
{
    public class EmployeeModel : IDisposable
    {
        private EmployeeServiceManager employeeServiceManager;

        public EmployeeModel()
        {
            employeeServiceManager = new EmployeeServiceManager();
        }       

        /// <summary>
        /// For Insert and Update the Employee
        /// </summary>
        /// <param name="employeeAttributeModel"></param>
        /// <returns></returns>
        public BaseAttributeModel InsertUpdateEmployee(EmployeeAttributeModel employeeAttributeModel)
        {
            var response = new BaseAttributeModel();
            try
            {
                employeeAttributeModel.IsActive = true;
                employeeAttributeModel.EmployeeLanguages = GetEmployeeLanguageMaps(employeeAttributeModel);
                var employeeEntity = Mapper.Map<EmployeeAttributeModel, Employee>(employeeAttributeModel);
                bool flag = employeeServiceManager.InsertUpdateEmployee(employeeEntity);
                response.Success = flag;
                response.Exceptions = (flag == true) ? null : (new List<Exception> { new Exception(ExceptionMessage.SaveEmployeeErorrMsg) });
                response.StatusCode = (flag == true) ? APIErrorCodes.APISuccessCode : APIErrorCodes.APIMethodCallingErrorCode;
            }
            catch (Exception ex)
            {               
                response.Success = false;
                response.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                response.Exceptions = new List<Exception> { new Exception(ex.Message.ToString()) };

                //Here we track the Exception at WebAPI Methods

            }

            return response;
        }

        /// <summary>
        /// Map the employee and Languages from LanguageIds array comming from the View
        /// </summary>
        /// <param name="employeeAttributeModel"></param>
        /// <returns></returns>
        public List<EmployeeLanguagesAttributeModel> GetEmployeeLanguageMaps(EmployeeAttributeModel employeeAttributeModel)
        {
            var employeeLanguageMapsListAttributeModel = new List<EmployeeLanguagesAttributeModel>();
            if (employeeAttributeModel != null && employeeAttributeModel.LanguageIds!=null)
            {
                foreach (int languageId in employeeAttributeModel.LanguageIds)
                {
                    employeeLanguageMapsListAttributeModel.Add(new EmployeeLanguagesAttributeModel { Id = 0, EmpId = employeeAttributeModel.EmpId, LanguageId = languageId, IsActive = true });
                }
            }

            return employeeLanguageMapsListAttributeModel;
        }


        /// <summary>
        /// For Getting the Master Data
        /// </summary>
        /// <returns></returns>
        public MasterDataAttributeModel GetMasterData()
        {
            using (var response = new MasterDataAttributeModel())
            {
                try
                {
                    StatesServiceManager statesServiceManager = new StatesServiceManager();
                    LanguagesServiceManager languageServiceManager = new LanguagesServiceManager();
                    response.States = Mapper.Map<List<State>, List<StateAttributeModel>>(statesServiceManager.GetStates());
                    response.Languages = Mapper.Map<List<Language>, List<LanguageAttributeModel>>(languageServiceManager.GetLanguages());
                    response.StatusCode = APIErrorCodes.APISuccessCode;
                    response.Success = true;
                }
                catch (Exception ex)
                {
                    response.Success = false;
                    response.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                    response.Exceptions = new List<Exception> { new Exception(ex.Message.ToString()) };

                    //Here we track the Exception at WebAPI Methods

                }
                return response;
            }
        }

        /// <summary>
        /// For Getting the Employees
        /// </summary>
        /// <returns></returns>
        public EmployeeListAttributeModel GetEmployees()
        {
            using (var response = new EmployeeListAttributeModel())
            {
                try
                {
                    var employeeEntityList = employeeServiceManager.GetEmployees();
                    response.employeeDetailsList = Mapper.Map<List<Employee>, List<EmployeeDetailsAttributeModel>>(employeeEntityList);
                    response.StatusCode = APIErrorCodes.APISuccessCode;
                    response.Success = true;
                }
                catch(Exception ex)
                {
                    response.Success = false;
                    response.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                    response.Exceptions = new List<Exception> { new Exception(ex.Message.ToString()) };

                    //Here we track the Exception at WebAPI Methods

                }
                return response;
            }
        }


        /// <summary>
        /// For Getting the Employees By EmployeeId
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public EmployeeAttributeModel GetEmployeeByEmpId(int empId)
        {
            var response = new EmployeeAttributeModel();

            try
            {
                var employeeEntity = employeeServiceManager.GetEmployeeByEmpId(empId);
                response = Mapper.Map<Employee, EmployeeAttributeModel>(employeeEntity);
                response.LanguageIds = (from p in response.EmployeeLanguages select p.LanguageId).ToArray();
                response.EmployeeLanguages = null;
                response.StatusCode = APIErrorCodes.APISuccessCode;
                response.Success = true;
               
            }
            catch(Exception ex)
            {
                response.Success = false;
                response.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                response.Exceptions = new List<Exception> { new Exception(ex.Message.ToString()) };
                
                //Here we track the Exception at WebAPI Methods
            }

            return response;
        }

        /// <summary>
        /// Instead of Delete the Employee ,InActivate the Employee for Future purpose
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        public BaseAttributeModel InActiveEmployeeByEmpId(int empId)
        {
            var response = new BaseAttributeModel();
            try
            {
                bool flag = employeeServiceManager.InActiveEmployeeByEmpId(empId);
                response.Success = flag;
                response.Exceptions = (flag == true) ? null : (new List<Exception> { new Exception(ExceptionMessage.DeleteEmployeeByIdErrorMsg) });
                response.StatusCode = (flag == true) ? APIErrorCodes.APISuccessCode : APIErrorCodes.APIMethodCallingErrorCode;
            }
            catch (Exception ex)
            {
                response.Success = false;
                response.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                response.Exceptions = new List<Exception> { new Exception(ex.Message.ToString()) };
            }
            return response;
        }

        /// <summary>
        /// Disopose the service manager object and call the GC
        /// </summary>
        public void Dispose()
        {
            employeeServiceManager.Dispose();
            GC.Collect();
        }

    }
}