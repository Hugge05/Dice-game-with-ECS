using ECS.Entities;
using ECS.Components;
using ECS.Systems;
using System;


namespace ECS
{


    internal class Program
    {
        static void Main(string[] args)
        {
            var player = new Entity(1);
            var diceComponent = new DiceComponent();
            var inputComponent = new InputComponent();

            player.AddComponent(diceComponent);
            player.AddComponent(inputComponent);

            var diceCheckSystem = new DiceCheckSystem();
            var inputSystem = new InputSystem();

            for (int i = 0; i < 6; i++)
            {
                Console.WriteLine("Guess a number");

                diceCheckSystem.DiceNumber(player);
                inputSystem.InputNumber(player);

                int guess = player.GetComponent<InputComponent>().guess;
                int actualDiceValue = player.GetComponent<DiceComponent>().current_dicevalue;

                if (guess == actualDiceValue)
                {
                    Console.WriteLine("Du gissade rätt!");
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("Du gissade fel, gissa igen");
                }
            }
        }
    }
}
