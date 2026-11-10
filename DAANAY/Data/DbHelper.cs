using Microsoft.Data.SqlClient;

namespace DAANAY.Data;

// Simple ADO.NET helper for future product, cart, and order operations.
// Identity uses Entity Framework Core; other modules should use this class.
public class DbHelper
{
    private readonly string _connectionString;

    public DbHelper(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")
            ?? throw new InvalidOperationException("Connection string 'DefaultConnection' was not found.");
    }

    public SqlConnection GetConnection()
    {
        return new SqlConnection(_connectionString);
    }
}
