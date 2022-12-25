using System.Numerics;
using System.Xml.Linq;

namespace ASM2demo;
class Booking
{
    public int id { get; set; }
    public int roomId { get; set; }
    public string customerIdCard { get; set; }
    public bool inUse { get; set; }
    public DateTime checkin { get; set; }
    public DateTime checkout { get; set; }

    public void book(int _id, Room _room, string _customerIdCard)
    {
        id = _id;
        roomId = _room.id;
        customerIdCard = _customerIdCard;
        checkin = DateTime.Now;
        checkout = DateTime.Now;
        inUse = true;
        _room.book();
    }

    public void checkoutRoom(Room _room)
    {
        checkout = DateTime.Now;
        inUse = false;
        _room.setAvailable();
        Double roomMoney = Math.Round(_room.price * checkout.Subtract(checkin).TotalHours,0 );
        Console.WriteLine("Total bill: {0}", roomMoney);
    }

    public void show()
    {
        Console.WriteLine("Booking id: {0}, room id: {1}, customer id: {2}", id, roomId, customerIdCard);
    }
}

