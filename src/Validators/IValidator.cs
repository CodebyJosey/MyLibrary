// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Validators;

public interface IValidator<T>
{
    bool IsValid(T input);
    IEnumerable<string> GetErrors();
}