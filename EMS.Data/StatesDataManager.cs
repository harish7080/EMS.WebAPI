using System;
using System.Collections.Generic;
using System.Linq;
using EMS.Entity;
namespace EMS.Data
{
    public class StatesDataManager : IDisposable
    {
        private EMSContext context;

        public StatesDataManager()
        {
            context = new EMSContext();
        }

        /// <summary>
        /// Get the States
        /// </summary>
        /// <returns></returns>
        public  List<State> GetStates()
        {            
            var states = context.State.Where(x => x.IsActive == true).OrderBy(x=>x.StateName).ToList();
            return states;
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
