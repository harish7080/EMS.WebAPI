using EMS.Model;
using EMS.WebAPI.Models;
using System.Web.Http;
namespace EMS.WebAPI.Controllers.API
{
    public class FilesController :BaseApiController
    {
        FileModel model;
        public FilesController()
        {
            model = new FileModel();
        }

        /// <summary>
        /// Insert or Update the EMployee
        /// </summary>
        /// <param name="employeeAttributeModel"></param>
        /// <returns></returns>
        [Route("api/Files")]
        [HttpPost]
        public FileAttributeModel UploadFile(FileAttributeModel fileAttributeModel)
        {
            return model.UploadFile(fileAttributeModel);
        }


    }
}