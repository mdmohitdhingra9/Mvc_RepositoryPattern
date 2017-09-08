using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Dal;
using Architect.Models.Models;

namespace Architect.DAL.Log
{
    public sealed class Logger
    {
        #region Singelton
        //private static Logger log = null;
        //private static readonly object objLock = new object();
        //private Logger()
        //{
        //    if (log != null)
        //        throw new Exception("Can not create an object of logger");
        //}

        //public static Logger Log()
        //{
        //    if (log == null)
        //    {
        //        lock (objLock)
        //        {
        //            if (log == null)
        //            {
        //                log = new Logger();
        //            }
        //        }
        //    }
        //    return log;
        //}
        #endregion
        private static ApplicationDbContext context;
        
        public static void Log(LogException exception)
        {
            if (context == null)
                context = new ApplicationDbContext();
            context.LogExceptions.Add(exception);
            context.SaveChanges();
        }

    }
}
