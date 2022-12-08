using PriceListNameSpace;

namespace InterfaceNameSpace;

internal class Program
{
    private static void Main(string[] args)
    {
        var priceList = new PriceList();
        var interface1 = new Interface(ref priceList);
        interface1.MainMenu();
    }
}