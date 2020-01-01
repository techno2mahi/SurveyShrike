using System.Configuration; 

namespace EHRS.Shared
{
    public   class ContextHelper
    {
        /// <summary>
        /// Gets the desired DBContext connection per institution
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static string GetConnectionString(int schoolId = 0)
        {
            const string connectionKey = "catalog=ATRM";
            string targetConnectionKey = connectionKey  + (schoolId == 0 ? "" : schoolId.ToString());

            var connectionString = ConfigurationManager.ConnectionStrings["ATRMContext"].ConnectionString;
            connectionString = connectionString.Replace(connectionKey, targetConnectionKey);
            return  connectionString;
        } 
    }
}
