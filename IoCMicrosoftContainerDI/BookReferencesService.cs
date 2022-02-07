namespace IoCMicrosoftContainerDI;

public class BookReferencesService : IReferencesService
{
    public void MostImportantLinks()
    {
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("SOLID: The First 5 Principles of Object Oriented Design");
        Console.WriteLine("C# 9.0 in a Nutshell: The Definitive Reference");
        Console.WriteLine("Design Patterns: Elements of Reusable Object-Oriented Software");
    }
}