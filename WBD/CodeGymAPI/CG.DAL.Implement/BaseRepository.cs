﻿using System;
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
            connection = new SqlConnection(@"Data Source=DESKTOP-M2RQ9DH\SQLEXPRESS;Initial Catalog=CodeGymDb;Integrated Security=True");
        }
    }
}
