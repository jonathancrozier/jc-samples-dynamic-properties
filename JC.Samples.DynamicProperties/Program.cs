using JC.Samples.DynamicProperties.Factories;
using JC.Samples.DynamicProperties.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;

namespace JC.Samples.DynamicProperties
{
    /// <summary>
    /// Main Program class.
    /// </summary>
    class Program
    {
        #region Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments passed to the program</param>
        static void Main(string[] args)
        {
            // Read the todos, dynamic property definitions and values from the JSON content files.
            var todos             = JsonSerializer.Deserialize<IList<Todo>>(File.ReadAllText(@"Content\todos.json"));
            var dynamicProperties = JsonSerializer.Deserialize<IList<DynamicProperty>>(File.ReadAllText(@"Content\dynamic-properties.json"));
            var dynamicTodoValues = JsonSerializer.Deserialize<IList<TodoDynamicValue>>(File.ReadAllText(@"Content\todo-dynamic-values.json"));

            // Create a new Type based on a 'Todo' with additional dynamic properties.
            var factory      = new DynamicTypeFactory();
            var extendedType = factory.CreateNewTypeWithDynamicProperties(typeof(Todo), dynamicProperties);

            // Get all read/write properties for the extended Type.
            var properties = extendedType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                                         .Where(p => p.CanRead && p.CanWrite);
            
            // Populate a list of objects of the extended Type and display the property names and values.
            object extendedObject = null;

            for (int i = 0; i < todos.Count(); i++)
            {
                extendedObject = Activator.CreateInstance(extendedType);

                string todoHeading = $"Todo {i + 1}";
                Console.WriteLine(todoHeading);
                Console.WriteLine("".PadLeft(todoHeading.Length, '='));
                Console.WriteLine();

                extendedType.GetProperty($"{nameof(Todo.Id)}")
                            .SetValue(extendedObject, todos[i].Id, null);

                extendedType.GetProperty($"{nameof(Todo.UserId)}")
                            .SetValue(extendedObject, todos[i].UserId, null);

                extendedType.GetProperty($"{nameof(Todo.Title)}")
                            .SetValue(extendedObject, todos[i].Title, null);

                extendedType.GetProperty($"{nameof(Todo.Completed)}")
                            .SetValue(extendedObject, todos[i].Completed, null);

                // NOTE: The dynamic property names are prefixed to mitigate against name collision.
                extendedType.GetProperty($"{nameof(DynamicProperty)}_{nameof(TodoDynamicValue.Important)}")
                            .SetValue(extendedObject, dynamicTodoValues[i].Important, null);

                extendedType.GetProperty($"{nameof(DynamicProperty)}_{nameof(TodoDynamicValue.Notes)}")
                            .SetValue(extendedObject, dynamicTodoValues[i].Notes, null);

                foreach (PropertyInfo property in properties)
                {
                    Console.WriteLine($"{property.Name}: {property.GetValue(extendedObject, null)}");
                }

                Console.WriteLine();
            }

            Console.ReadKey();
        }

        #endregion
    }
}