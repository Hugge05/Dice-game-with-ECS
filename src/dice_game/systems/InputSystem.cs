using ECS.Entities;
using ECS.Components;
using System;

namespace ECS.Systems
{
    // InputSystem-klassen representerar ett system i Entity-Component-System (ECS) arkitekturen.
    // Detta system hanterar logiken för att läsa användarens inmatning och uppdatera en enhets inputkomponent.
    public class InputSystem
    {
        // InputNumber-metoden tar en enhet som parameter och uppdaterar dess InputComponent med användarens gissning.
        public void InputNumber(Entity entity)
        {
            // Hämtar InputComponent från den givna enheten.
            InputComponent inputComponent = entity.GetComponent<InputComponent>();
            
            // Läser en rad text från konsolen, konverterar den till ett heltal och tilldelar det till guess-fältet i InputComponent.
            inputComponent.guess = Convert.ToInt32(Console.ReadLine());
        }
    }
}
