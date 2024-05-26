using ECS.Entities;
using ECS.Components;
using System;

namespace ECS.Systems
{
    // InputSystem klassen hanterar inmatning av nummer från användaren.
    public class InputSystem
    {
        // Metod för att hantera inmatning av nummer från användaren för en given entitet.
        public void InputNumber(Entity entity)
        {
            // Hämtar InputComponent från entiteten.
            InputComponent inputComponent = entity.GetComponent<InputComponent>();

            // Kastar ett undantag om InputComponent inte finns på entiteten.
            if (inputComponent == null)
            {
                throw new InvalidOperationException("InputComponent is required but was not found on the entity.");
            }

            // Ber användaren att ange ett nummer.
            Console.WriteLine("Please enter a number:");

            // Läser in användarens inmatning från konsolen.
            string input = Console.ReadLine();

            // Försöker konvertera användarens inmatning till ett heltal och uppdatera gissningsvärdet i InputComponent.
            try
            {
                inputComponent.Guess = Convert.ToInt32(input);
            }
            catch (FormatException)
            {
                // Fångar FormatException om användaren anger en ogiltig inmatning.
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            catch (OverflowException)
            {
                // Fångar OverflowException om det angivna numret är för stort eller för litet för att konverteras till ett heltal.
                Console.WriteLine("The number entered is too large or too small.");
            }
        }
    }
}
