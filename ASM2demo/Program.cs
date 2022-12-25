namespace ASM2demo;
class Program
{
    static void Main(string[] args)
    {
        List<Hotel> hotels = new List<Hotel>();
        List<Customer> customers = new List<Customer>();
        List<Booking> bookings = new List<Booking>();

        Int32 choice;
        do
        {
            ShowMenu();
            choice = Int32.Parse(Console.ReadLine());
            switch(choice) {
                case 1:
                    addHotel(hotels);
                    break;
                case 2:
                    showHotel(hotels);
                    break;
                case 3:
                    {
                        Console.WriteLine("Please input customer id card:");
                        string idCard = Console.ReadLine();
                        addCustomer(customers, idCard); 
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Please input customer id card:");
                        string idCard = Console.ReadLine();
                        Customer customer = findCustomer(customers, idCard);
                        if (customer !=  null)
                        {
                            customer.show();
                        } else
                        {
                            Console.WriteLine("Customer not found");
                        }
                        break;
                    }
                case 5:
                    editCustomer(customers);
                    break;
                case 6:
                    showAvailableRoom(hotels);
                    break;
                case 7:
                    editRoom(hotels);
                    break;
                case 8:
                    bookRoom(hotels, customers, bookings);
                    break;
                case 9:
                    deleteBooking(bookings);
                    break;
                case 10:
                    checkoutRoom(hotels, bookings);
                    break;
                case 11:
                    {
                        Console.WriteLine("Exit");
                        break;
                    }
                //case 12:
                //    statistic(hotels, bookings);
                //    break;
                default:
                    Console.WriteLine("Input Failed");
                    break;
            }
            Console.WriteLine("=====================");

        } while (choice != 13);
        
    }

    //Print menu
    static void ShowMenu()
    {
        Console.WriteLine("1. Input hotel information");
        Console.WriteLine("2. Show hotel information");
        Console.WriteLine("3. Add customer");
        Console.WriteLine("4. Find customer");
        Console.WriteLine("5. Edit customer");
        Console.WriteLine("6. Show available room");
        Console.WriteLine("7. Edit room");
        Console.WriteLine("8. Book room");
        Console.WriteLine("9. Delete booking");
        Console.WriteLine("10. Check out room");
        Console.WriteLine("11. Exit");
        //Console.WriteLine("11. Statistic");
        Console.Write("Choose your action : ");
    }

    //Statistic
    //static void statistic(List<Hotel> hotels, List<Booking> bookings)
    //{
    //    foreach(Hotel hotel in hotels)
    //    {
    //        Double hotelMoney = 0;
    //        foreach(Room room in hotel.roomList)
    //        {
    //            hotelMoney += getMoneyFromBooking(bookings, room);
    //        }
    //        Console.WriteLine("Hotel {0}: total money: {1}", hotel.id, hotelMoney);
    //    }
    //}

    static Double getMoneyFromBooking(List<Booking> bookings, Room room)
    {
        Double roomMoney = 0;
        foreach (Booking booking in bookings)
        {
            if (booking.roomId == room.id && booking.inUse == true)
            {
                roomMoney += room.price * booking.checkout.Subtract(booking.checkin).TotalHours;
            }
        }
        return roomMoney;
    }

    //Edit Customer
    static void editCustomer(List<Customer> customers)
    {
        Console.Write("Please input customer id card:");
        string idCard = Console.ReadLine();
        Customer customer = findCustomer(customers, idCard);
        customer.edit();
    }

    static void editRoom(List<Hotel> hotels)
    {
        Room room = choiceRoom(hotels);
        room.edit();
    }

    static void checkoutRoom(List<Hotel> hotels, List<Booking> bookings)
    {
        Room room = choiceRoom(hotels);
        if (room.isAvailable == true)
        {
            Console.WriteLine("Room is not using");
        } else
        {
            findCheckoutBooking(bookings, room);
        }
    }

    //Delete Booking
    static void deleteBooking(List<Booking> bookings)
    {
        Booking deleteBooking = findBooking(bookings);
        if (deleteBooking == null) return;
        foreach (Booking booking in bookings.ToList())
        {
            if (booking.id == deleteBooking.id)
            {
                bookings.Remove(booking);
            }
        }
    }


    static void findCheckoutBooking(List<Booking> bookings, Room room)
    {
        foreach(Booking booking in bookings)
        {
            if (booking.roomId == room.id && booking.inUse == true)
            {
                booking.checkoutRoom(room);
            }
        }
    }

    //Find Booking
    static Booking findBooking(List<Booking> bookings)
    {
        foreach (Booking booking in bookings)
        {
            booking.show();
        }
        Console.Write("Choice booking id: ");
        int bookingId = Int32.Parse(Console.ReadLine());
        foreach(Booking booking in bookings)
        {
            if (booking.id == bookingId)
            {
                return booking;
            }
        }
        return null;
    }

    //Add Hotel
    static void addHotel(List<Hotel> hotels)
    {
        Hotel hotel = new Hotel();
        hotel.addInfo();
        hotels.Add(hotel);
    }

    //Show Hotel
    static void showHotel(List<Hotel> hotels)
    {
        foreach(Hotel hotel in hotels)
        {
            hotel.display();
        }
    }

    static Customer findOrAddCustomer(List<Customer> customers, string idCard)
    {
        foreach (Customer customer in customers)
        {
            if (customer.idCard.Equals(idCard))
            {
                return customer;
            }
        }

        return addCustomer(customers, idCard);
    }

    static Customer findCustomer(List<Customer> customers, string idCard)
    {
        foreach (Customer customer in customers)
        {
            if (customer.idCard.Equals(idCard))
            {
                return customer;
            }
        }

        return null;
    }

    static Customer addCustomer(List<Customer> customers, string idCard = "")
    {
        if(findCustomer(customers, idCard) != null)
        {
            Console.WriteLine("Customer is exists");
            return null;
        }
        Customer newCustomer = new Customer();
        newCustomer.addInfo(idCard);
        customers.Add(newCustomer);
        return newCustomer;
    }

    static Hotel findHotel(List<Hotel> hotels, int hotelId)
    {
        foreach (Hotel hotel in hotels)
        {
            if (hotel.id.Equals(hotelId))
            {
                return hotel;
            }
        }
        return null;

    }

    static void showAvailableRoom(List<Hotel> hotels)
    {
        foreach (Hotel hotel in hotels)
        {
            hotel.display();
            hotel.displayAvailableRoom();
        }
    }

    static Room findRoom(List<Room> rooms)
    {
        Console.Write("Please input room id: ");
        int roomId = Int32.Parse(Console.ReadLine());
        foreach (Room room in rooms)
        {
            if (room.id.Equals(roomId))
            {
                return room;
            }
        }
        return null;

    }

    static Room choiceRoom(List<Hotel> hotels)
    {
        // Display list hotels
        foreach (Hotel hotel in hotels)
        {
            hotel.display();
        }

        // Allow to chose hotel
        Hotel chosedHotel = null;
        do
        {
            Console.Write("Please choice hotel: ");
            int hotelId = Int32.Parse(Console.ReadLine());
            chosedHotel = findHotel(hotels, hotelId);
        } while (chosedHotel == null);
        chosedHotel.displayRoom();


        // Allow to chose room
        Room chosedRoom = null;
        do
        {
            chosedRoom = findRoom(chosedHotel.roomList);

        } while (chosedRoom == null);
        chosedRoom.display();

        return chosedRoom;
    }

    static void bookRoom(List<Hotel> hotels, List<Customer> customers, List<Booking> bookings)
    {
        Console.Write("Please input customer id card: ");
        string customerId = Console.ReadLine();
        Customer customer = findOrAddCustomer(customers, customerId);
        Room room = null;
        do
        {
            room = choiceRoom(hotels);
        } while (room == null || room.isAvailable == false);
        Booking booking = new Booking();
        Console.Write("Input booking id: ");
        int bookingId = Int32.Parse(Console.ReadLine());
        booking.book(bookingId, room, customer.idCard);;
        bookings.Add(booking);
    }

}

