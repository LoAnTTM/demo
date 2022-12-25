using System;

namespace ASM2demo;
class Hotel
{
    public int id { get; set; }
    public string name { get; set; }
    public string address { get; set; }
    public List<Room> roomList = new List<Room>();

    public void addInfo()
    {
        Console.Write("Input hotel id: ");
        id = Int32.Parse(Console.ReadLine());

        Console.Write("Input hotel name: ");
        name = Console.ReadLine();

        Console.Write("Input hotel address: ");
        address = Console.ReadLine();

        Console.Write("Input number of rooms: ");
        int numberOfRoom = Int32.Parse(Console.ReadLine());

        for (int i = 0; i < numberOfRoom; i++)
        {
            Room room = new Room();
            room.add();
            roomList.Add(room);
        }
    }

    public void edit()
    {
        Console.Write("Input hotel name: ");
        name = Console.ReadLine();

        Console.Write("Input hotel address: ");
        address = Console.ReadLine();
    }

    public void display()
    {
        Console.WriteLine("### Hotel (Id: {0}, Hotel'name : {1}, address : {2}, numberOfRoom : {3}", id, name, address, roomList.Count);
    }

    public void displayRoom()
    {
        foreach(Room room in roomList)
        {
            Console.WriteLine("Room (Id: {0}, Price: {1}, is availble : {2}", room.id, room.price, room.isAvailable);
        }
    }

    public void displayAvailableRoom()
    {
        int numberAvailableRoom = 0;
        foreach (Room room in roomList)
        {
            if (room.isAvailable)
            {
                ++numberAvailableRoom;
                Console.WriteLine("Room (Id: {0}, Price: {1}, is availble : {2}", room.id, room.price, room.isAvailable);
            }
        }
        Console.WriteLine("====> Total available rooms: {0}", numberAvailableRoom);
    }
}

