using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace andreasbom_3_1_IA.Model.DAL
{
    public abstract class DALBase
    {
        private static readonly string ConnectionString;

        static DALBase()
        {
            ConnectionString = WebConfigurationManager.ConnectionStrings["WP14_ab22cw_individuellt_arbeteConnectionString"].ConnectionString;
        }

        protected SqlConnection CreateConnection()
        {
            var connection = new SqlConnection(ConnectionString);
            return connection;
        }
    }
}