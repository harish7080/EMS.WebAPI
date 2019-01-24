using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Entity;
namespace EMS.Data
{
    public class LanguagesDataManager : IDisposable
    {
        private EMSContext context;

        public LanguagesDataManager()
        {
            context = new EMSContext();
        }


        /// <summary>
        /// Get the Languages
        /// </summary>
        /// <returns></returns>
        public  List<Language> GetLanguages()
        {
            var languagesList = context.Language.Where(x => x.IsActive == true).OrderBy(x=>x.LanguageName).ToList();
            return languagesList;
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
