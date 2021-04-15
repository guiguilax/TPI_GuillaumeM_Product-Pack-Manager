using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Dapper;

namespace Product_Pack_Manager
{
    class Sql
    {
        string connetionString;
        SqlConnection cnn;
        SqlCommand command;
        SqlDataReader dataReader;
        String sql;
        string error;

        public Sql()
        {
            connetionString = @"Data Source=sql-pp-01.vtx-pp.ch;Initial Catalog=vtxclients; Integrated Security=true";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
        }
    }
}