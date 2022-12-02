using PriceListNameSpace;

namespace InterfaceNameSpace
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PriceList priceList = new PriceList();
            Interface interface1 = new Interface(ref priceList);
            interface1.MainMenu();
        }
    }
}