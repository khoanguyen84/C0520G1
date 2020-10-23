using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CG.DAL.Implement
{
    public class BaseRepository
    {
        protected IDbConnection connection;
        public BaseRepository()
        {
            //connection = new SqlConnection(@"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=CodeGymDb;Integrated Security=True");
            connection = new SqlConnection(@"Data Source=hoang\sqlexpress;Initial Catalog=CodeGymDb;Integrated Security=True");
        }
    }
}
