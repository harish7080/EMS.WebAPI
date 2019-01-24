using System;
using System.Collections.Generic;

namespace EMS.Model
{
    public class BaseAttributeModel : IDisposable
    {
        /// <summary>
        /// True - for Transaction Success, False - Not
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Hold the Exceptions
        /// </summary>
        public List<Exception> Exceptions { get; set; }

        //Status Code for API Calls
        public int StatusCode { get; set; }

        /// <summary>
        /// Call GC
        /// </summary>
        public void Dispose()
        {
            GC.Collect();
        }
    }
}