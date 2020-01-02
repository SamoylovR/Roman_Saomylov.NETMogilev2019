using FinanceHelper.Common;
using System;
using System.Data.SqlClient;

namespace FinanceHelper.DALdb
{
    public class Repository
    {
        SqlConnection connection = new SqlConnection(Config.connectionString);
    }
}
