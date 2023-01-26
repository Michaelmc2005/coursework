using _2022_09_27_Coursework_1st_Draft.objects;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace _2022_09_27_Coursework_1st_Draft.dbAccess
{
    class serviceDBAccess
    {
        private Database db;

        public serviceDBAccess(Database db)
        {
            this.db = db;
        }
        public List<service> getAllServices()
        {
            List<service> results = new List<service>();
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "SELECT * FROM service";
            db.Rdr = db.Cmd.ExecuteReader();
            while (db.Rdr.Read())
            {
                results.Add(getServiceFromReader(db.Rdr));
            }
            db.Rdr.Close();
            return results;
        }
        public int AutoServiceID()
        {
            int result = 1;
            int MaxID = 0;
            List<service> id = new List<service>();
            id = getAllServices();
            foreach (service service in id)
            {
                if (result == service.ServiceID)
                {
                    MaxID = service.ServiceID;
                    result += 1;
                }
                else
                {
                    MaxID = service.ServiceID;
                }

            }
            if (result == MaxID)
            {
                result += 1;
            }
            return result;

        }
        public service getServiceFromReader(SqlDataReader reader)
        {
            service newService = new service();
            newService.ServiceID = reader.GetInt32(0);
            newService.ServiceName = reader.GetString(1);
            newService.ServicePrice = reader.GetInt32(2);
            newService.Duration = reader.GetInt32(3);
            return newService;
        }
        public void insertService(int serviceID, string serviceName, int servicePrice, string Duration)
        {
            db.Cmd = db.Conn.CreateCommand();
            db.Cmd.CommandText = "INSERT INTO service (serviceID, serviceName, servicePrice, Duration ) "
                + "VALUES (" + serviceID + ", '" + serviceName + "', " + servicePrice + ", " + Duration + ")";
            db.Cmd.ExecuteNonQuery();
        }

    }
}
