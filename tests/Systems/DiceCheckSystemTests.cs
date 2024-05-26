using NUnit.Framework;
using ECS.Systems;
using ECS.Entities;
using ECS.Components;
using System;


[TestFixture]
public class DiceCheckSystemTests
{
    [Test]
    public void DiceNumber_AssignsValueWithinRange()
    {
        // Arrange
        var entity = new Entity(1);
        var diceComponent = new DiceComponent();
        entity.AddComponent(diceComponent);
        var diceCheckSystem = new DiceCheckSystem();

        // Act
        diceCheckSystem.DiceNumber(entity);

        // Assert
        Assert.That(diceComponent.CurrentDiceValue, Is.InRange(1, 6));
    }

    [Test]
    public void DiceNumber_ThrowsException_WhenDiceComponentIsNull()
    {
        // Arrange
        var entity = new Entity(2);
        var diceCheckSystem = new DiceCheckSystem();

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => diceCheckSystem.DiceNumber(entity));
        Assert.That(ex.Message, Is.EqualTo("DiceComponent and its values must be properly initialized."));
    }

    [Test]
    public void DiceNumber_ThrowsException_WhenDiceValuesAreNull()
    {
        // Arrange
        var entity = new Entity(3);
        var diceComponent = new DiceComponent();
        // Use reflection to set the readonly DiceValues to null for testing purposes
        typeof(DiceComponent).GetField("<DiceValues>k__BackingField", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(diceComponent, null);
        entity.AddComponent(diceComponent);
        var diceCheckSystem = new DiceCheckSystem();

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => diceCheckSystem.DiceNumber(entity));
        Assert.That(ex.Message, Is.EqualTo("DiceComponent and its values must be properly initialized."));
    }

    [Test]
    public void DiceNumber_ThrowsException_WhenDiceValuesAreEmpty()
    {
        // Arrange
        var entity = new Entity(4);
        var diceComponent = new DiceComponent();
        // Use reflection to set the readonly DiceValues to an empty array for testing purposes
        typeof(DiceComponent).GetField("<DiceValues>k__BackingField", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(diceComponent, new int[0]);
        entity.AddComponent(diceComponent);
        var diceCheckSystem = new DiceCheckSystem();

        // Act & Assert
        var ex = Assert.Throws<InvalidOperationException>(() => diceCheckSystem.DiceNumber(entity));
        Assert.That(ex.Message, Is.EqualTo("DiceComponent and its values must be properly initialized."));
    }
}

