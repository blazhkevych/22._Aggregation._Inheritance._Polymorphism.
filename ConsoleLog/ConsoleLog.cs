using System.Data.SqlTypes;
using ILogNameSpace;
using StorageNameSpace;

namespace ConsoleLogNameSpace
{
    public class ConsoleLog : ILog
    {
        // Метод вывода данных, по выбранному пользователем назначению (консоль).
        public void ReportOutput(String s) => Console.WriteLine(s);
    }
}