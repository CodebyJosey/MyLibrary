// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Validators;

public class ValidationResult
{
    public List<string> Errors { get; }
    public ValidationResult(List<string> errors)
    {
        Errors = errors;
    }

    public bool IsValid => Errors.Count == 0;
}