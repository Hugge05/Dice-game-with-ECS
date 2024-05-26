using ECS.Entities;
using ECS.Components;
using System;

namespace ECS.Systems
{
    // DiceCheckSystem klassen hanterar kontrollen av tärningsvärden.
    public class DiceCheckSystem
    {
        // Random-instans för att generera slumpmässiga tärningsvärden.
        private readonly Random rnd = new Random();

        // Metod för att generera och uppdatera det aktuella tärningsvärdet för en given entitet.
        public void DiceNumber(Entity entity)
        {
            // Hämtar DiceComponent från entiteten.
            var diceComponent = entity.GetComponent<DiceComponent>();

            // Kastar ett undantag om DiceComponent inte är korrekt initialiserad.
            if (diceComponent == null || diceComponent.DiceValues == null || diceComponent.DiceValues.Length == 0)
            {
                throw new InvalidOperationException("DiceComponent and its values must be properly initialized.");
            }

            // Genererar ett slumpmässigt tärningsvärde baserat på DiceComponent's möjliga värden och uppdaterar det aktuella tärningsvärdet.
            diceComponent.CurrentDiceValue = rnd.Next(1, diceComponent.DiceValues.Length + 1);
        }
    }
}
