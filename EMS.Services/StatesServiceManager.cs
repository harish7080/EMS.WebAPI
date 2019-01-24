using System.Collections.Generic;
using EMS.Data;
using EMS.Entity;
using System;
namespace EMS.Services
{
    public class StatesServiceManager
    {
        private StatesDataManager statesDataManager;

        public StatesServiceManager()
        {
            statesDataManager = new StatesDataManager();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public  List<State> GetStates()
        {
            return statesDataManager.GetStates();
        }

        /// <summary>
        ///
        /// </summary>
        public void Dispose()
        {
            //Dipose the Context
            statesDataManager.Dispose();

            // call the Garbage collector
            GC.Collect();
        }
    }
}
