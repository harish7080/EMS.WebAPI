using EMS.Model;
using EMS.WebAPI.Constants;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;

namespace EMS.WebAPI.Models
{
    public class FileModel : IDisposable
    {
        /// <summary>
        /// Files Upload Folder NAme
        /// </summary>
        string uploadFilePath = ConfigurationManager.AppSettings["uploadFileFolder"];

        /// <summary>
        /// WebAPI Url , Send along with file path for open the file at view side 
        /// </summary>
        string webAPIURL = ConfigurationManager.AppSettings["WebAPIUrl"];


        /// <summary>
        /// Covert the byte Array to file And Save in Specifed Folder and return the file details with success code
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public FileAttributeModel UploadFile(FileAttributeModel files)
        {
            try
            {
                var root = HttpContext.Current.Server.MapPath(uploadFilePath);
                string uniqueId = DateTime.Now.ToString("yyyyMMddHHmmssfff");
                string uniqueFileName = uniqueId + "_" + files.FileName;
                string filePath = root + "/" + uniqueFileName;
                if (files.byteArray != null)
                {
                    File.WriteAllBytes(filePath, files.byteArray);
                    files.FileUId = uniqueId;
                    files.StatusCode = APIErrorCodes.APISuccessCode;
                    files.Success = true;
                    files.IsActive = true;
                    files.FilePath = uploadFilePath.Replace("~/","") + "/" + uniqueFileName;
                    files.FilePathURL = webAPIURL + files.FilePath;
                    files.byteArray = null;
                }
            }
            catch
            {
                files.Success = false;
                files.StatusCode = APIErrorCodes.APIMethodCallingErrorCode;
                files.Exceptions = new List<Exception> { new Exception(ExceptionMessage.uploadFileErrorMsg) };
            }

            return files;
        }

              

        /// <summary>
        /// call the GC
        /// </summary>
        public void Dispose()
        {
            GC.Collect();
        }
    }
}