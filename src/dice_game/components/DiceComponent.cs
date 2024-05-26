namespace ECS.Components
{
    // The DiceComponent class represents a component that can be attached to an entity.
    // This component simulates a dice with fixed values and stores the current dice value.
    public class DiceComponent
    {
        // An array representing the possible values of the dice.
        // This is a read-only property initialized with values 1 through 6.
        public int[] dicevalues { get; } = { 1, 2, 3, 4, 5, 6 };

        // A field to store the current value of the dice.
        // This can be modified to represent the result of a dice roll.
        public int current_dicevalue = 1;
    }
}
