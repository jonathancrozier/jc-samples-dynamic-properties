# JC.Samples.DynamicProperties
Add properties to a C# object dynamically at runtime using code emission.

```csharp
// Create a new Type based on a 'Todo' with additional dynamic properties.
var factory      = new DynamicTypeFactory();
var extendedType = factory.CreateNewTypeWithDynamicProperties(typeof(Todo), dynamicProperties);
 
// Create an instance of the new extended Type.
var extendedObject = Activator.CreateInstance(extendedType);
```
