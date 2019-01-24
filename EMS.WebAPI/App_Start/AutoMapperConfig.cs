using AutoMapper;
using EMS.Entity;
using EMS.Model;
using System.Configuration;
namespace EMS.WebAPI.App_Start
{
    public static class AutoMapperConfig
    {
        public static void autoRegisterMappings()
        {
            //Config the Auto Mapper with Entity and AttributeModel at the time of Application loading
            //Call this Method at global.ascx
            string webAPIURL = ConfigurationManager.AppSettings["WebAPIUrl"];

            Mapper.CreateMap<Employee, EmployeeAttributeModel>();
            Mapper.CreateMap<EmployeeAttributeModel, Employee>();

            Mapper.CreateMap<EmployeeLanguage, EmployeeLanguagesAttributeModel>();
            Mapper.CreateMap<EmployeeLanguagesAttributeModel, EmployeeLanguage>();

            //Add Full Path including the URL to FilePath
            Mapper.CreateMap<File, FileAttributeModel>()
                 .ForMember(d => d.FilePathURL, x => x.MapFrom(c => (webAPIURL + c.FilePath)));

            Mapper.CreateMap<FileAttributeModel, File>();

            Mapper.CreateMap<State, StateAttributeModel>();

            Mapper.CreateMap<Language, LanguageAttributeModel>();

            Mapper.CreateMap<Employee, EmployeeDetailsAttributeModel>();
        }
    }
}