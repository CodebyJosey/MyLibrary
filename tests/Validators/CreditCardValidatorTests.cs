// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
using CodeByJosey.MyLibrary.Validators;

namespace CodeByJosey.MyLibrary.Tests.Validators;

[TestClass]
public sealed class CreditCardValidatorTests
{
    private CreditCardValidator _validator = default!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new CreditCardValidator();
    }

    [TestMethod]
    public void ValidCreditCard_ReturnsTrue()
    {
        string validCardNumber = "4532015112830366";
        Assert.IsTrue(_validator.IsValid(validCardNumber));
    }

    [TestMethod]
    public void InvalidCrediCard_ReturnsFalse()
    {
        string invalidCardNumber = "1234567890123456";
        Assert.IsFalse(_validator.IsValid(invalidCardNumber));
    }

    [TestMethod]
    public void EmptyCardNumber_ReturnsFalse()
    {
        string emptyCardNumber = string.Empty;
        Assert.IsFalse(_validator.IsValid(emptyCardNumber));
    }

    [TestMethod]
    public void CardNumberTooShort_ReturnsFalse()
    {
        string shortCardNumber = "123";
        Assert.IsFalse(_validator.IsValid(shortCardNumber));
    }

    [TestMethod]
    public void CardNumberTooLong_ReturnsFalse()
    {
        string longCardNumber = "12345678901234567890";
        Assert.IsFalse(_validator.IsValid(longCardNumber));
    }
}
