namespace ECS.Components
{
    /// <summary>
    /// The DiceComponent class represents a component that simulates a dice with fixed values.
    /// </summary>
    public class DiceComponent
    {
        /// <summary>
        /// Variable to store the current value of the dice.
        /// </summary>
        public int CurrentDiceValue { get; set; } = 1;

        /// <summary>
        /// Array to store the possible values of the dice.
        /// </summary>
        public int[] DiceValues { get; } = { 1, 2, 3, 4, 5, 6 };
    }
}