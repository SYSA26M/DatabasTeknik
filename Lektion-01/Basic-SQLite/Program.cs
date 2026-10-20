using Microsoft.Data.Sqlite;

namespace Basic_SQLite;

class Program
{
    static void Main()
    {
        var connectionString = "Data Source=runstore.db";
        using var connection = new SqliteConnection(connectionString);
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Customers";

        // Öppna databasen(anslutningen...)
        connection.Open();
        // Ställ frågan...
        using var reader = command.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine("Hämtar data: {0} {1} {2} {3}",
                reader.GetInt32(0), reader.GetString(1),
                reader.GetString(2), reader.GetString(3));
        }
    }
}
