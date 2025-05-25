// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Configuration;

public static class EnvironmentVariableHelper
{
    public static string Get(string key) => Environment.GetEnvironmentVariable(key)!;
    public static void Set(string key, string value) => Environment.SetEnvironmentVariable(key, value);
    public static bool Exists(string key) => Environment.GetEnvironmentVariable(key) != null;
}