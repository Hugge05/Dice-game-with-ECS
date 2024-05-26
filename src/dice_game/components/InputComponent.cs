using System;

namespace ECS.Components
{
    // InputComponent-klassen representerar en komponent som kan fästas vid en entitet.
    // Denna komponent används för att lagra användarens inmatning, specifikt en gissning.
    public class InputComponent
    {
        // Ett fält för att lagra användarens gissning.
        // Standardvärdet är initialiserat till 0.
        public Int32 guess = 0;
    }
}
