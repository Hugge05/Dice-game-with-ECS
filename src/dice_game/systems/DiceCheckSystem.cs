using ECS.Entities;
using System;
using ECS.Components;
namespace ECS.Systems
{
    public class DiceCheckSystem
    {
        public void DiceNumber(Entity entity)
        {
            var diceComponent = entity.GetComponent<DiceComponent>();
            Random rnd = new Random();
            diceComponent.current_dicevalue = rnd.Next(1, diceComponent.dicevalues.Length + 1);
        }
    }
}


