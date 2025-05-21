using MyLibrary.Utilities;

namespace MyLibrary.Tests.Utilities;

[TestClass]
public sealed class MathTests
{
    [TestMethod]
    public void TestAdd()
    {
        Assert.AreEqual(24.5, MathUtilitities.Add(12, 12.5));
        Assert.AreEqual(-1, MathUtilitities.Add(int.MinValue, int.MaxValue));
        Assert.AreEqual(-200, MathUtilitities.Add(-100, -100));
    }

    public void TestSubtract()
    {
        Assert.AreEqual(-200, MathUtilitities.Subtract(-100, -100));
        Assert.AreEqual(0.0, MathUtilitities.Subtract(100, 100.0));
        Assert.AreEqual(-0.01, MathUtilitities.Subtract(100, 100.01));
    }
}
