using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coachella
{
    public class SingleMinded
    {
        private DbProviderFactory _providerFactory;
        private DbConnection _connection;

        public void OpenConnection(String provider, String connString)
        {
            _providerFactory = DbProviderFactories.GetFactory(provider);

            _connection = _providerFactory.CreateConnection();
            _connection.ConnectionString = connString;
            _connection.Open();
        }

        public DataTable GetAllRecords(String tableName)
        {
            DataTable resultingTable = new DataTable(tableName);
            using (DbCommand cmd = _providerFactory.CreateCommand())
            {
                cmd.CommandText = $"select * from {tableName}";
                cmd.Connection = _connection;
                using (DbDataAdapter da = _providerFactory.CreateDataAdapter())
                {
                    da.SelectCommand = cmd;
                    da.Fill(resultingTable);
                }
            }
            return resultingTable;
        }

        public void CloseConnection()
        {
            _connection?.Close();
        }
    }
}
