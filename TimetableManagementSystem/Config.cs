using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableManagementSystem
{
    class Config
    {
        public static SqlConnection con = new SqlConnection(@"Server=tcp:timetablemngsysdb3.database.windows.net,1433;Initial Catalog=TimetableManageSystemDB;Persist Security Info=False;User ID=timetableadmin;Password=imb@manN0tbruce;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        /*
        Use this as
        SqlConnection con = Config.con;
        In your class
        make sure to import SqlClient as
        using System.Data.SqlClient;
        */
    }
}
