namespace IoCMicrosoftContainerDI;

public class WebsiteReferencesService : IReferencesService
{
    
    public void MostImportantLinks()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("https://eif.viko.lt");
        Console.WriteLine("https://google.lt");
        Console.WriteLine("https://viko.source.code.lt");
    }
}