// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using Microsoft.Data.Sqlite;
using Dapper;
using System.Reflection;
using CodeByJosey.MyLibrary.Data.Repositories;

namespace CodeByJosey.MyLibrary.Data.Managers;

public sealed class DatabaseManager<T>
{
    private readonly string _connectionString;
    private readonly string _tableName = typeof(T).Name;
    private readonly PropertyInfo[] _properties = typeof(T).GetProperties();

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
        using (SqliteConnection connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string createTableQuery = GenerateTableQuery();

            using (SqliteCommand command = new SqliteCommand(createTableQuery, connection))
            {
                command.ExecuteNonQuery();
            }
        }
    }

    private string GenerateTableQuery()
    {
        List<string> columns = new List<string>();

        foreach (PropertyInfo prop in _properties)
        {
            string columnType = GetSQLiteType(prop.PropertyType);
            if (prop == _properties[0]) columns.Add($"{prop.Name} {columnType} UNIQUE");
            else columns.Add($"{prop.Name} {columnType}");
        }
        return $"CREATE TABLE IF NOT EXISTS {_tableName} (Id INTEGER PRIMARY KEY AUTOINCREMENT, {string.Join(", ", columns)})";
    }

    private string GetSQLiteType(Type type)
    {
        if (type == typeof(int) || type == typeof(long) || type == typeof(bool))
            return "INTEGER";
        else if (type == typeof(double) || type == typeof(float))
            return "REAL";
        else if (type == typeof(string) || type == typeof(DateTime))
            return "TEXT";
        else if (type == typeof(byte[]))
            return "BLOB";
        else
            return "TEXT"; // fallback
    }

    public void Insert(T model)
    {
        using (SqliteConnection connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string insertQuery = GenerateInsertQuery();

            using (SqliteCommand command = new SqliteCommand(insertQuery, connection))
            {
                foreach (PropertyInfo prop in _properties) command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(model));
                command.ExecuteNonQuery();
            }
        }
    }

    private string GenerateInsertQuery()
    {
        string columns = string.Join(", ", _properties.Select(p => p.Name));
        string parameters = string.Join(", ", _properties.Select(p => "@" + p.Name));
        return $"INSERT OR IGNORE INTO {_tableName} ({columns}) VALUES ({parameters})";
    }

    public T? GetById(int id)
    {
        string sql = $"SELECT * FROM {_tableName} WHERE Id = @Id";
        using (SqliteConnection connection = new SqliteConnection(_connectionString)) return connection.QueryFirstOrDefault<T>(sql, new { Id = id });
    }

    public void Update(T model)
    {
        using (SqliteConnection connection = new SqliteConnection(_connectionString))
        {
            connection.Open();
            string setClause = string.Join(", ", _properties.Select(p => $"{p.Name} = @{p.Name}"));

            // Identificeer de unieke sleutel
            PropertyInfo? uniqueProperty = _properties.FirstOrDefault(p => Attribute.IsDefined(p, typeof(UniqueAttribute)));
            if (uniqueProperty == null) throw new InvalidOperationException("No unique key defined.");

            object? uniqueValue = uniqueProperty.GetValue(model);
            string updateQuery = $"UPDATE {_tableName} SET {setClause} WHERE {uniqueProperty.Name} = @uniqueValue";

            using (SqliteCommand command = new SqliteCommand(updateQuery, connection))
            {
                foreach (PropertyInfo prop in _properties)
                {
                    command.Parameters.AddWithValue("@" + prop.Name, prop.GetValue(model));
                }
                command.Parameters.AddWithValue("@uniqueValue", uniqueValue);

                command.ExecuteNonQuery();
            }
        }
    }
}