using ECS.Entities;
using System;
using ECS.Components;

namespace ECS.Systems
{
    // DiceCheckSystem-klassen representerar ett system i Entity-Component-System (ECS) arkitekturen.
    // Detta system hanterar logiken för att slumpmässigt generera ett nytt tärningsvärde för en enhet.
    public class DiceCheckSystem
    {
        // DiceNumber-metoden tar en enhet som parameter och uppdaterar dess tärningskomponents aktuella värde.
        public void DiceNumber(Entity entity)
        {
            // Hämtar DiceComponent från den givna enheten.
            var diceComponent = entity.GetComponent<DiceComponent>();
            
            // Skapar en ny instans av Random-klassen för att generera slumpmässiga tal.
            Random rnd = new Random();
            
            // Genererar ett nytt slumpmässigt värde för tärningen och tilldelar det till current_dicevalue.
            // rnd.Next(1, diceComponent.dicevalues.Length + 1) genererar ett tal mellan 1 och 6 (inklusive).
            diceComponent.current_dicevalue = rnd.Next(1, diceComponent.dicevalues.Length + 1);
        }
    }
}
