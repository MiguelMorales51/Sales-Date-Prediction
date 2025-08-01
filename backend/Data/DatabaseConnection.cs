using System.Reflection;
using Microsoft.Data.SqlClient;

namespace backend.Data;

public class DatabaseConnection : IDisposable
{
    private string? _connectionString
    {
        get => GetConnectionString();
    }

    public DatabaseConnection()
    {
    }

    private string? GetConnectionString() {
        string path = Directory.GetCurrentDirectory();
        if (!path.Contains("backend"))
            path = Path.Combine(path, "backend");

        IConfiguration config = new ConfigurationBuilder()
            .SetBasePath(path) // ruta del archivo
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddEnvironmentVariables()
            .Build();

        string? cs = config.GetConnectionString("DefaultConnection");
        if (string.IsNullOrWhiteSpace(cs))
            throw new NotImplementedException("No se ha configurado conexión a la base de datos.");
        return cs;
    }

    public async Task<List<T>> Select<T>(string? query, Dictionary<string, dynamic>? dic = null) where T : new()
    {
        var lst = new List<T>();
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        using var cmd = new SqlCommand(query, con);
        if (dic != null)
        {
            if (dic.Count > 0)
            {
                foreach (var key in dic)
                {
                    var param = new SqlParameter();
                    param.ParameterName = key.Key;
                    param.Value = key.Value;
                    cmd.Parameters.Add(param);
                }
            }
        }
        using var reader = await cmd.ExecuteReaderAsync();
        var columns = new List<string>();
        for (int i = 0; i < reader.FieldCount; i++)
            columns.Add(reader.GetName(i));
        var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

        while (await reader.ReadAsync())
        {
            var obj = new T();
            foreach (var prop in props)
            {
                if (columns.Contains(prop.Name) && !reader.IsDBNull(reader.GetOrdinal(prop.Name)))
                {
                    object val = reader[prop.Name];
                    Type? tn = Nullable.GetUnderlyingType(prop.PropertyType);
                    prop.SetValue(obj, Convert.ChangeType(val, tn ?? prop.PropertyType));
                }
            }
            lst.Add(obj);
        }
        return lst;
    }

    public async Task<bool> Insert(string? query, Dictionary<string, dynamic?>? dic = null)
    {
        using var con = new SqlConnection(_connectionString);
        await con.OpenAsync();
        using var cmd = new SqlCommand(query, con);
        if (dic != null)
        {
            if (dic.Count > 0)
            {
                foreach (var key in dic)
                {
                    var param = new SqlParameter();
                    param.ParameterName = key.Key;
                    param.Value = key.Value;
                    cmd.Parameters.Add(param);
                }
            }
        }
        var rows = await cmd.ExecuteNonQueryAsync();
        return rows > 0;
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}