using System;
using System.Collections.Generic;

namespace ECS.Entities
{
    // Entity-klassen representerar en enhet i Entity-Component-System (ECS)-arkitekturen.
    public class Entity
    {
        // Offentlig egenskap för att lagra entitetens unika identifierare.
        public int Id;

        // Dictionary för att lagra de komponenter som är associerade med entiteten.
        // Nyckeln är typen av komponenten, och värdet är instansen av komponenten.
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
        // Om komponenten hittas, returneras den; annars returneras null.
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
