// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Validators;

namespace CodeByJosey.MyLibrary.Tests.Validators;

[TestClass]
public sealed class DateValidatorTests
{
    private DateValidator _validator = default!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new DateValidator();
    }

    [TestMethod]
    public void ValidDate_ReturnsTrue()
    {
        string validDate = "21-05-2025";
        Assert.IsTrue(_validator.IsValid(validDate));
    }

    [TestMethod]
    public void InvalidDate_ReturnsFalse()
    {
        string invalidDate = "21 d 2025";
        Assert.IsFalse(_validator.IsValid(invalidDate));
    }

    [TestMethod]
    public void EmptyDate_ReturnsFalse()
    {
        string emptyDate = string.Empty;
        Assert.IsFalse(_validator.IsValid(emptyDate));
    }
}
