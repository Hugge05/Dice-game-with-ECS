namespace ECS
{
    /// <summary>
    /// The Program class is the entry point of the application.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The Main method is the entry point of the application.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        static void Main(string[] args)
        {
            // Creates a new entity for the player.
            var player = new Entity(1);

            // Creates a new DiceComponent and InputComponent.
            var diceComponent = new DiceComponent();
            var inputComponent = new InputComponent();

            // Adds the DiceComponent and InputComponent to the player entity.
            player.AddComponent(diceComponent);
            player.AddComponent(inputComponent);

            // Creates a new DiceCheckSystem and InputSystem.
            var diceCheckSystem = new DiceCheckSystem();
            var inputSystem = new InputSystem();

            // Loops 6 times to simulate 6 rounds of guessing.
            for (int i = 0; i < 6; i++)
            {
                // Prompts the user to guess a number.
                Console.WriteLine("Guess a number");

                // Generates a random dice value for the player.
                diceCheckSystem.DiceNumber(player);

                // Handles the user's input for the player.
                inputSystem.InputNumber(player);

                // Retrieves the user's guess and the actual dice value.
                int guess = player.GetComponent<InputComponent>().Guess;
                int actualDiceValue = player.GetComponent<DiceComponent>().CurrentDiceValue;

                // Checks if the user's guess matches the actual dice value.
                if (guess == actualDiceValue)
                {
                    // If the guess is correct, informs the user and exits the application.
                    Console.WriteLine("Du gissade rätt!");
                    Environment.Exit(0);
                }
                else
                {
                    // If the guess is incorrect, informs the user and continues to the next round.
                    Console.WriteLine("Du gissade fel, gissa igen");
                }
            }
        }
    }
}