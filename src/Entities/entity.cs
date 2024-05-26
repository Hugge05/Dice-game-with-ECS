using System;
using System.Collections.Generic;

namespace ECS.Entities
{
    /// <summary>
    /// The Entity class represents an entity within the Entity-Component-System (ECS) architecture.
    /// </summary>
    public class Entity
    {
        /// <summary>
        /// Variable to store the unique identifier of the entity.
        /// </summary>
        public int Id;

        /// <summary>
        /// Dictionary to store components associated with the entity.
        /// The key is the component's type and the value is the instance of the component.
        /// </summary>
        private Dictionary<Type, object> components = new Dictionary<Type, object>();

        /// <summary>
        /// Constructor to initialize the entity with a unique identifier.
        /// </summary>
        /// <param name="id">The unique identifier for the entity.</param>
        public Entity(int id)
        {
            Id = id;
        }

        /// <summary>
        /// Method to add a component to the entity.
        /// The component is added to the dictionary with its type as the key.
        /// </summary>
        /// <param name="component">The component to be added to the entity.</param>
        public void AddComponent<T>(T component)
        {
            components[typeof(T)] = component;
        }

        /// <summary>
        /// Method to retrieve a component of a specified type from the entity.
        /// If the component exists, it is returned; otherwise, null is returned.
        /// </summary>
        /// <returns>The component of the specified type, or null if it does not exist.</returns>
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