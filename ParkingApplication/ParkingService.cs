using System;
using System.Net.Sockets;
using System.Runtime.CompilerServices;
using Microsoft.VisualBasic;

namespace ParkingApplication;

public class Parking
{   

    public int MaxSlots { get; set; }
    public Parking(int maxSlots)
    {
        MaxSlots = maxSlots;
    }
    
    

    public List<ParkedCar> ListOfParkedCar = new List<ParkedCar> { new ParkedCar(1, "Bogdan",  "abc"), new ParkedCar(2, "Andrei",  "abcde")};

    public void AddToParking(int id, string userName,string? carNumber = null)
    {
        if(ListOfParkedCar.Count < MaxSlots && carNumber != null)
        {
                var Car = new ParkedCar(id, userName, carNumber);
                ListOfParkedCar.Add(Car);
        }
    }

}

    