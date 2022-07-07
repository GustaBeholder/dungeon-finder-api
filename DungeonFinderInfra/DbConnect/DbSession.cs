using Microsoft.Data.SqlClient;
using System.Data;

namespace DungeonFinderInfra.DbConnect
{
    public sealed class DbSession
    {
        public IDbConnection _connection;
        public IDbTransaction _transaction;

        public DbSession()
        {
            _connection = new SqlConnection("Data Source=DESKTOP-FH8RBBG\\SQLEXPRESS;Initial Catalog=DungeonFinder;TrustServerCertificate=True;Integrated Security=True");
            //_connection = new SqlConnection("Data Source=DESKTOP-RMHUVFI\\SQLEXPRESS;Initial Catalog=DungeonFinder;User ID=sa;Password=1234;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False");

        }

        public bool OpenConnection() 
        {
            try
            {
                if (_connection == null) 
                {
                    return false;
                }
                if(_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                    return true;
                } 

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        } 
        
        public bool CloseConnection()
        {
            try
            {
                if(_transaction != null)
                {
                    return false;
                }
                if(_connection.State == ConnectionState.Open)
                {
                    _connection.Close();
                    return true;
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        
    }
}
