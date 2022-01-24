using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication1.CustomClass
{
    public class Connection
    {
        public SqlConnection connection;
        public SqlCommand sqlCommand;
        public SqlDataReader sqlDataReader;
        public Connection()
        {
            //connection = new SqlConnection(@"Data Source=omni-sql011.ad.nobelbiz.org;Initial Catalog=EVOLUTIONDB;User Id=NCADMIN;Password=ADMN1cr@;");
connection = new SqlConnection(WebConfigurationManager.AppSettings["connection"]);
        }
    }
}