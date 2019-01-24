
namespace EMS.Model
{
    public class FileAttributeModel  :BaseAttributeModel
    {
        /// <summary>
        /// 
        /// </summary>
        public int FileId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int EmpId { get; set; }

        /// <summary>
        /// This is for maintin the uniqueid for every file
        /// </summary>
        public string FileUId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FileName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FilePath { get; set; }

        /// <summary>
        /// this is for maintain the Index for every file at the time of uploading
        /// </summary>
        public int FileIndex { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool IsActive { get; set; }

        /// <summary>
        /// File ByteArray
        /// </summary>
        public byte[] byteArray{ get; set; }

        /// <summary>
        /// FilePath URL
        /// </summary>
        public string FilePathURL { get; set; }


    }
}