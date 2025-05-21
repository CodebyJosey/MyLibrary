using MyLibrary.Validators;

namespace MyLibrary.Tests.Validators;

[TestClass]
public sealed class EmailValidatorTests
{
    private EmailValidator _validator = default!;

    [TestInitialize]
    public void Setup()
    {
        _validator = new EmailValidator();
    }

    [TestMethod]
    public void ValidEmail_ReturnsTrue()
    {
        string validEmail = "hello@world.com";
        Assert.IsTrue(_validator.IsValid(validEmail));
        validEmail = "john@doe.com";
        Assert.IsTrue(_validator.IsValid(validEmail));
        validEmail = "12345678@domain.com";
        Assert.IsTrue(_validator.IsValid(validEmail));
    }

    [TestMethod]
    public void InvalidEmail_ReturnsFalse()
    {
        string invalidEmail = "johndoe.com";
        Assert.IsFalse(_validator.IsValid(invalidEmail));
        invalidEmail = "john@doecom";
        Assert.IsFalse(_validator.IsValid(invalidEmail));
        invalidEmail = "john doe@domain.com";
        Assert.IsFalse(_validator.IsValid(invalidEmail));
    }

    public void EmptyEmail_ReturnsFalse()
    {
        string emptyEmail = string.Empty;
        Assert.IsFalse(_validator.IsValid(emptyEmail));
    }
}
