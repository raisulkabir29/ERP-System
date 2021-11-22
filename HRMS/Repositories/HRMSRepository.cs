using HRMS.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace HRMS.Repositories
{
    public class HRMSRepository
    {
        public IEnumerable<T> GetData<T>(DbContext db, string query)
        {
            List<T> results = new List<T>();
            try
            {
                results = db.Database.SqlQuery<T>(query).ToList();
            }
            catch (Exception ex)
            {
                Utility.WriteErrorLog(new ErrorLog()
                {
                    ErrorFor = "Executing Query",
                    ErrorFrom = "HRMSRepository.GetData",
                    ErrorMessage = "Exception: " + ex.Message
                });
            }
            return results;
        }
    }
}