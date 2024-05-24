using ECS.Entities;
using ECS.Components;
using System;
namespace ECS.Systems
{
    public class InputSystem
    {
        public void InputNumber(Entity entity)
        {
            InputComponent inputComponent = entity.GetComponent<InputComponent>();
            inputComponent.guess = Convert.ToInt32(Console.ReadLine());
        }
    }
}
    
