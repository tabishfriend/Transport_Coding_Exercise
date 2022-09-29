using Transport.Core.Interfaces;

namespace Transport.Core;

public class PrintConsoleService : IPrintService
{
    public void Print(List<string> data)
    {
        foreach (var row in data)
        {
            Console.WriteLine(row);
        }
    }
}
