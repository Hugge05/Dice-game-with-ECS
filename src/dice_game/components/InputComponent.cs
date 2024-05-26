using System;

namespace ECS.Components
{
    // The InputComponent class represents a component that can be attached to an entity.
    // This component is used to store user input, specifically a guessed value.
    public class InputComponent
    {
        // A field to store the guessed value provided by the user.
        // The default value is initialized to 0.
        public Int32 guess = 0;
    }
}
