using System.Collections.Generic;
using EMS.Data;
using EMS.Entity;
using System;
namespace EMS.Services
{
    public class LanguagesServiceManager : IDisposable
    {
        private LanguagesDataManager languagesDataManager;

        public LanguagesServiceManager()
        {
            languagesDataManager = new LanguagesDataManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Language> GetLanguages()
        {
            return languagesDataManager.GetLanguages();
        }


        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            //Dipose the Context
            languagesDataManager.Dispose();

            // call the Garbage collector
            GC.Collect();
        }
    }
}
