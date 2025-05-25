// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Configuration;

public static class ConfigManager
{
    private static readonly Dictionary<string, string> _settings = new();

    public static void Set(string key, string value) => _settings[key] = value;
    public static string Get(string key) => _settings.TryGetValue(key, out var value) ? value : null!;
}