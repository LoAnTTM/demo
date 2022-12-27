using System.Net;
using System.Xml.Linq;

namespace ASM2demo;
class Room
{
    public int id { get; set; }
    public int price { get; set; }
    public bool isAvailable { get; set; }

    public void add()
    {
        Console.Write("Input room id: ");
        id = Int32.Parse(Console.ReadLine());

        Console.Write("Input room price: ");
        price = Int32.Parse(Console.ReadLine());
        isAvailable = true;
    }

    public void edit()
    {
        Console.Write("Update price: ");
        price = Int32.Parse(Console.ReadLine());
    }

    public void book()
    {
        isAvailable = false;
    }

    public void setAvailable()
    {
        isAvailable = true;
    }

    public void display()
    {
        Console.WriteLine("Room (Id: {0}, price : {1})", id, price);
    }
}

