using ECS.Entities;
using ECS.Components;
using ECS.Systems;
using System;

namespace ECS
{
    // Programklassen innehåller Main-metoden och fungerar som ingångspunkten för programmet.
    internal class Program
    {
        // Main-metoden körs när programmet startar.
        static void Main(string[] args)
        {
            // Skapar en ny entitet för spelaren med identifieraren 1.
            var player = new Entity(1);

            // Skapar en ny instans av DiceComponent för att representera tärningen.
            var diceComponent = new DiceComponent();

            // Skapar en ny instans av InputComponent för att hantera användarens inmatning.
            var inputComponent = new InputComponent();

            // Lägger till DiceComponent och InputComponent till spelar-entiteten.
            player.AddComponent(diceComponent);
            player.AddComponent(inputComponent);

            // Skapar ett nytt DiceCheckSystem för att kontrollera tärningsvärden.
            var diceCheckSystem = new DiceCheckSystem();

            // Skapar ett nytt InputSystem för att hantera användarinmatning.
            var inputSystem = new InputSystem();

            // Utför loopen sex gånger för att låta spelaren gissa sex gånger.
            for (int i = 0; i < 6; i++)
            {
                // Skriver ut meddelande för användaren att gissa ett nummer.
                Console.WriteLine("Gissa ett nummer");

                // Anropar DiceNumber-metoden i DiceCheckSystem för att uppdatera tärningsvärdet.
                diceCheckSystem.DiceNumber(player);

                // Anropar InputNumber-metoden i InputSystem för att läsa användarens gissning.
                inputSystem.InputNumber(player);

                // Hämtar användarens gissning och det faktiska tärningsvärdet från entiteten.
                int guess = player.GetComponent<InputComponent>().guess;
                int actualDiceValue = player.GetComponent<DiceComponent>().current_dicevalue;

                // Jämför användarens gissning med det faktiska tärningsvärdet och skriver ut lämpligt meddelande.
                if (guess == actualDiceValue)
                {
                    Console.WriteLine("Du gissade rätt!");
                    // Avslutar programmet om användaren gissade rätt.
                    Environment.Exit(0);
                }
                else
                { 
                    // Om man gissar fel så får man veta det och programmet loopas om.
                    Console.WriteLine("Du gissade fel, gissa igen");
                }
            }
        }
    }
}
