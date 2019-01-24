using System.Collections.Generic;
using System.Linq;
using EMS.Entity;
namespace EMS.Data
{
    class FileDataManager
    {
        /// <summary>
        /// Upload New Files those have Id zero
        /// </summary>
        /// <param name="files"></param>
        /// <param name="recordId"></param>
        /// <param name="context"></param>
        public static void InsertFiles(List<File> files, int recordId, EMSContext context)
        {
            if (files != null)
            {
                var fileList=(from x in files where x.FileId==0 select x).ToList();
                foreach (var file in fileList)
                {
                    file.EmpId = recordId;
                    context.File.AddRange(fileList);
                }
                context.SaveChanges();
            }

        }
      
    }
}
