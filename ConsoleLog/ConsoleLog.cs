using ILogNameSpace;

namespace ConsoleLogNameSpace;

public class ConsoleLog : ILog
{
    // Метод вывода данных, по выбранному пользователем назначению (консоль).
    public void ReportOutput(string s)
    {
        Console.WriteLine(s);
    }
}