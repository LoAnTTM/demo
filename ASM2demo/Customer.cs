using System.Net;
using System.Reflection;
using System.Security.Cryptography;

namespace ASM2demo;
class Customer
{
    public string idCard { get; set; }
    public string name { get; set; }
    public string phone { get; set; }

    public void addInfo(string _idCard = "")
    {
        if(_idCard != "")
        {
            idCard = _idCard;
        } else
        {
            Console.Write("Input customer id : ");
            idCard = Console.ReadLine();

        }
        Console.Write("Input full name : ");
        name = Console.ReadLine();

        Console.Write("Input phone number : ");
        phone = Console.ReadLine();

    }

    public void edit()
    {
        Console.Write("Input full name : ");
        name = Console.ReadLine();

        Console.Write("Input phone number : ");
        phone = Console.ReadLine();

    }

    public void show()
    {
        Console.WriteLine("Customer id: ,{0} custom name: {1}, customer phone: {2}", idCard, name, phone);
    }
}

