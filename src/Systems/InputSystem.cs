using ECS.Entities;
using ECS.Components;
using System;

namespace ECS.Systems
{
    /// <summary>
    /// The InputSystem class represents a system that handles the user's input.
    /// </summary>
    public class InputSystem
    {
        /// <summary>
        /// Method to handle the user's input for a given entity.
        /// </summary>
        /// <param name="entity">The entity for which the user's input is to be handled.</param>
        public void InputNumber(Entity entity)
        {
            // Retrieves the InputComponent from the entity.
            InputComponent inputComponent = entity.GetComponent<InputComponent>();

            // Throws an exception if the InputComponent is not found on the entity.
            if (inputComponent == null)
            {
                throw new InvalidOperationException("InputComponent is required but was not found on the entity.");
            }

            // Prompts the user to enter a number.
            Console.WriteLine("Please enter a number:");

            // Reads the user's input.
            string input = Console.ReadLine();

            // Tries to convert the user's input to an integer and store it in the Guess property of the InputComponent.
            try
            {
                inputComponent.Guess = Convert.ToInt32(input);
            }
            // Catches a FormatException if the user's input is not a valid integer.
            catch (FormatException)
            {
                // Informs the user that their input was invalid.
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            // Catches an OverflowException if the user's input is too large or too small to be stored as an integer.
            catch (OverflowException)
            {
                // Informs the user that their input was too large or too small.
                Console.WriteLine("The number entered is too large or too small.");
            }
        }
    }
}