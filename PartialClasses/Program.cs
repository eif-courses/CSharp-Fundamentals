// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");



/*It is possible to split the definition of a class, a struct, an interface or a method over two or more source files. Each source file contains a section of the type or method definition, and all parts are combined when the application is compiled.

Partial Classes
There are several situations when splitting a class definition is desirable:

When working on large projects, spreading a class over separate files enables multiple programmers to work on it at the same time.
When working with automatically generated source, code can be added to the class without having to recreate the source file. Visual Studio uses this approach when it creates Windows Forms, Web service wrapper code, and so on. You can create code that uses these classes without having to modify the file created by Visual Studio.
When using source generators to generate additional functionality in a class.
To split a class definition, use the partial keyword modifier, as shown here:*/
https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/partial-classes-and-methods