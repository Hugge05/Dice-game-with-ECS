using System;
using System.Collections.Generic;

namespace ECS.Entities
{
    // Entity klassen representerar en entitet inom Entity-Component-System (ECS)-arkitekturen.
    public class Entity
    {
        // Variabel för att lagra entitetens unika identifierare.
        public int Id;

        // Dictionary för att lagra komponenter som är associerade med entiteten.
        // Nyckeln är komponentens typ och värdet är instansen av komponenten.
        private Dictionary<Type, object> components = new Dictionary<Type, object>();

        // Konstruktor för att initialisera entiteten med ett unikt identifierare.
        public Entity(int id)
        {
            Id = id;
        }

        // Metod för att lägga till en komponent till entiteten.
        // Komponenten läggs till i dictionaryn med dess typ som nyckel.
        public void AddComponent<T>(T component)
        {
            components[typeof(T)] = component;
        }

        // Metod för att hämta en komponent av en specificerad typ från entiteten.
        // Om komponenten finns, returneras den; annars returneras null.
        public T GetComponent<T>() where T : class
        {
            if (components.TryGetValue(typeof(T), out var component))
            {
                return component as T;
            }
            return null;
        }
    }
}
