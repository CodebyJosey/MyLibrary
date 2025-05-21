using Microsoft.Data.Sqlite;
using Dapper;

namespace MyLibrary.Data.Managers;

public sealed class DatabaseManager<T>
{
    private readonly string _connectionString;

    public DatabaseManager()
    {
        string nameOfDatabase = typeof(T).Name;
        nameOfDatabase += nameOfDatabase.EndsWith("ss") ? "es" : nameOfDatabase.EndsWith("s") ? "" : "s";
        string filePath = Path.Combine("Data", "Databases", nameOfDatabase);
        _connectionString = $"Data Source={filePath}.db;";
        this.InitDatabase();
    }

    public DatabaseManager(string nameOfDatabase)
    {
        string filePath = Path.Combine("Data", "Databases", nameOfDatabase);
        _connectionString = $"Data Source={filePath}.db;";
        this.InitDatabase();
    }

    private void InitDatabase()
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string tableName = typeof(T).Name;
            var createTableQuery = GenerateTableQuery(tableName);

            using (var command = new SqliteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    private string GenerateTableQuery(string tableName)
    {
        var properties = typeof(T).GetProperties();
        var columns = new List<string>();

        foreach (var prop in properties)
        {
            string columnType = prop.PropertyType == typeof(double) ? "REAL" : "TEXT";
            if (prop == properties[0]) columns.Add($"{prop.Name} {columnType} UNIQUE");
            else columns.Add($"{prop.Name} {columnType}");
        }
        return $"CREATE TABLE IF NOT EXISTS {tableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT, {string.Join(", ", columns)})";
    }

    public void Insert(T model)
    {
        using (var connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string tableName = typeof(T).Name;
            string insertQuery = GenerateInsertQuery(tableName, model);

            using (var command = new SqliteCommand(insertQuery, connection))
            {
                foreach (var prop in typeof(T).GetProperties()) command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(model));
                command.ExecuteNonQuery();
            }
        }
    }

    private string GenerateInsertQuery(string tableName, T model)
    {
        var properties = typeof(T).GetProperties();
        var columns = string.Join(", ", properties.Select(p => p.Name));
        var parameters = string.Join(", ", properties.Select(p => "@" + p.Name));
        return $"INSERT OR IGNORE INTO {tableName} ({columns}) VALUES ({parameters})";
    }

    public T? GetById(int id)
    {
        string tableName = typeof(T).Name;
        string sql = $"SELECT * FROM {tableName} WHERE Id = @Id";
        using (var connection = new SqliteConnection(_connectionString)) return connection.QueryFirstOrDefault<T>(sql, new { Id = id });
    }
}