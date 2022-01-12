/*When to use records
Consider using a record in place of a class or struct in the following scenarios:

You want to define a data model that depends on value equality.
You want to define a type for which objects are immutable.

Value equality

For records, value equality means that two variables of a record type are equal if the types match and all property and field values match. For other reference types such as classes, equality means reference equality. That is, two variables of a class type are equal if they refer to the same object. Methods and operators that determine equality of two record instances use value equality.
Not all data models work well with value equality. For example, Entity Framework Core depends on reference equality to ensure that it uses only one instance of an entity type for what is conceptually one entity. For this reason, record types aren't appropriate for use as entity types in Entity Framework Core.

Immutability

An immutable type is one that prevents you from changing any property or field values of an object after it's instantiated. Immutability can be useful when you need a type to be thread-safe or you're depending on a hash code remaining the same in a hash table. Records provide concise syntax for creating and working with immutable types.
Immutability isn't appropriate for all data scenarios. Entity Framework Core, for example, doesn't support updating with immutable entity types.*/

/*How records differ from classes and structs
The same syntax that declares and instantiates classes or structs can be used with records. Just substitute the class keyword with the record, or use record struct instead of struct. Likewise, the same syntax for expressing inheritance relationships is supported by record classes. Records differ from classes in the following ways:

You can use positional parameters to create and instantiate a type with immutable properties.
The same methods and operators that indicate reference equality or inequality in classes (such as Object.Equals(Object) and ==), indicate value equality or inequality in records.
You can use a with expression to create a copy of an immutable object with new values in selected properties.
A record's ToString method creates a formatted string that shows an object's type name and the names and values of all its public properties.
A record can inherit from another record. A record can't inherit from a class, and a class can't inherit from a record.
Record structs differ from structs in that the compiler synthesizes the methods for equality, and ToString. The compiler synthesizes a Deconstruct method for positional record structs.
*/
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/statements-expressions-operators/equality-comparisons#value-equality
Console.WriteLine("Hello, World!");
https://docs.microsoft.com/en-us/dotnet/csharp/language-reference/keywords/class