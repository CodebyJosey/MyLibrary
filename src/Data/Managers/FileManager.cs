// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Managers;

public sealed class FileManager
{
    private string _filePath;

    public FileManager(string fileName)
    {
        _filePath = Path.Combine("Data", "Documents", fileName);
    }

    public void WriteToFile(string content)
    {
        File.WriteAllText(_filePath, content);
    }

    public string ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }

        throw new FileNotFoundException("File was not found.", _filePath);
    }

    public void DeleteFile()
    {
        if (File.Exists(_filePath))
        {
            File.Delete(_filePath);
        }

        throw new FileNotFoundException("File was not found.", _filePath);
    }

    public bool FileExists() => File.Exists(_filePath);
}