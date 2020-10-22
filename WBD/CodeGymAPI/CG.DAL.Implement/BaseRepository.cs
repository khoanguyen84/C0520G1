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
            connection = new SqlConnection(@"Data Source=DESKTOP-EP3RDSG\SQLEXPRESS;Initial Catalog=CGAPI;Integrated Security=True");
        }
    }
}
