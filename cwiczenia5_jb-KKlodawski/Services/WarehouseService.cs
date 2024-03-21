using System.Data.SqlClient;

namespace Zadanie5.Services
{
    public class WarehouseService : IWarehouseService
    {
        private readonly IConfiguration _configuration;

        public WarehouseService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void AddProduct()
        {
            var connectionString = _configuration.GetConnectionString("Database");
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    using (SqlCommand command = new SqlCommand())
                    {

                        command.Connection = connection;
                        command.Transaction = transaction;

                        command.CommandText = "SELECT COUNT(*) FROM WAREHOUSE WHERE IdWarehouse = 1";

                        var result = (int)command.ExecuteScalar();

                        if (result == 0)
                        {
                            transaction.Rollback();
                            return;
                        }

                        transaction.Commit();
                    }
                }
                catch (Exception)
                {
                    transaction.Rollback();

                }
                finally
                {
                    connection.Close();
                }
            }
        }
    }
}
