using CG.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CG.DAL.Implement
{
    public class BaseRepository
    {
        protected IDbConnection conn;
        public BaseRepository()
        {
            conn = new SqlConnection(Common.ConnectionString);
        }
    }
}
