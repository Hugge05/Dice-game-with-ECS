using ECS.Entities;
using ECS.Components;
using ECS.Systems;
using System;

namespace ECS
{
    // Program klassen representerar huvudprogrammet för ECS-applikationen.
    internal class Program
    {
        // Main metoden är den första metoden som körs när programmet startar.
        static void Main(string[] args)
        {
            // Skapar en ny entitet för spelaren med ID 1.
            var player = new Entity(1);

            // Skapar en instans av DiceComponent för att representera tärningen.
            var diceComponent = new DiceComponent();

            // Skapar en instans av InputComponent för att representera användarens inmatning.
            var inputComponent = new InputComponent();

            // Lägger till DiceComponent och InputComponent till spelaren.
            player.AddComponent(diceComponent);
            player.AddComponent(inputComponent);

            // Skapar en instans av DiceCheckSystem för att hantera tärningskontrollen.
            var diceCheckSystem = new DiceCheckSystem();

            // Skapar en instans av InputSystem för att hantera användarens inmatning.
            var inputSystem = new InputSystem();

            // Loopar sex gånger för att låta spelaren gissa tärningsvärdet.
            for (int i = 0; i < 6; i++)
            {
                // Ber användaren gissa ett nummer.
                Console.WriteLine("Guess a number");

                // Genererar ett nytt tärningsvärde för spelaren.
                diceCheckSystem.DiceNumber(player);

                // Hanterar användarens inmatning.
                inputSystem.InputNumber(player);

                // Hämtar spelarens gissning och det faktiska tärningsvärdet.
                int guess = player.GetComponent<InputComponent>().Guess;
                int actualDiceValue = player.GetComponent<DiceComponent>().CurrentDiceValue;

                // Jämför spelarens gissning med det faktiska tärningsvärdet och skriver ut resultatet.
                if (guess == actualDiceValue)
                {
                    // Om man har rätt så får man veta det
                    Console.WriteLine("Du gissade rätt!");
                    // Om man har rätt så avslutas programmet.
                    Environment.Exit(0);
                }
                else
                {
                    // Om man har fel så får man ett meddelande, och man loopas om igen.
                    Console.WriteLine("Du gissade fel, gissa igen");
                }
            }
        }
    }
}
