using ECS.Entities;
using ECS.Components;
using System;

namespace ECS.Systems
{
    /// <summary>
    /// The DiceCheckSystem class represents a system that handles the dice check functionality.
    /// </summary>
    public class DiceCheckSystem
    {
        /// <summary>
        /// A Random object used to generate random numbers.
        /// </summary>
        private readonly Random rnd = new Random();

        /// <summary>
        /// Method to generate a random dice value for a given entity.
        /// </summary>
        /// <param name="entity">The entity for which a random dice value is to be generated.</param>
        public void DiceNumber(Entity entity)
        {
            // Retrieves the DiceComponent from the entity.
            var diceComponent = entity.GetComponent<DiceComponent>();

            // Throws an exception if the DiceComponent or its values are not properly initialized.
            if (diceComponent == null || diceComponent.DiceValues == null || diceComponent.DiceValues.Length == 0)
            {
                throw new InvalidOperationException("DiceComponent and its values must be properly initialized.");
            }

            // Generates a random dice value and updates the CurrentDiceValue in DiceComponent.
            diceComponent.CurrentDiceValue = rnd.Next(1, diceComponent.DiceValues.Length + 1);
        }
    }
}