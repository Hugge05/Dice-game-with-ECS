using NUnit.Framework;
using ECS.Components;

[TestFixture]
public class InputComponentTests
{
    [Test]
    public void TestGuessProperty()
    {
        var inputComponent = new InputComponent();
        inputComponent.Guess = 5;
        Assert.AreEqual(5, inputComponent.Guess);
    }
}

