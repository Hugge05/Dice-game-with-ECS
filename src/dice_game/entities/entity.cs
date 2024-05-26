using System;
using System.Collections.Generic;

namespace ECS.Entities
{
    // The Entity class represents an entity in the Entity-Component-System (ECS) architecture.
    public class Entity
    {
        // Public property to store the entity's unique identifier.
        public int Id;

        // Dictionary to store the components associated with the entity.
        // The key is the type of the component, and the value is the component instance.
        private Dictionary<Type, object> components = new Dictionary<Type, object>();

        // Constructor to initialize the entity with a unique identifier.
        public Entity(int id)
        {
            Id = id;
        }

        // Method to add a component to the entity.
        // The component is added to the dictionary with its type as the key.
        public void AddComponent<T>(T component)
        {
            components[typeof(T)] = component;
        }

        // Method to retrieve a component of a specified type from the entity.
        // If the component is found, it is returned; otherwise, null is returned.
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
