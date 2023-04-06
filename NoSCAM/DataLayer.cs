using NoSCAM.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vista.DatabaseConnector;

namespace DatabaseTestApp
{
    public class DataLayer
    {
        public string ConnectionString { get; set; }

        public DataLayer(string connectionString)
        {
            this.ConnectionString = connectionString;
        }

        public List<Course> GetCourses()
        {
            //List<Customer> data = SqlServerDb.LoadData<Customer, dynamic>("SELECT * FROM Customer", new {}, this.ConnectionString);
            List<Course> data = MySqlDb.LoadData<Course, dynamic>("SELECT * FROM Course", new {}, this.ConnectionString);

            return data;
        }

        public User GetByEmail(string email)
        {
            return MySqlDb.LoadData<User, dynamic>("SELECT * FROM user WHERE email = @email", new { email }, this.ConnectionString).First();
        }
    }
}
