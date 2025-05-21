namespace MyLibrary.Configuration;

public static class EnvironmentVariableHelper
{
    public static string Get(string key) => Environment.GetEnvironmentVariable(key)!;
    public static void Set(string key, string value) => Environment.SetEnvironmentVariable(key, value);
    public static bool Exists(string key) => Environment.GetEnvironmentVariable(key) != null;
}