using System;
using System.Collections.Generic;

namespace ChairOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            OfficeWorker james = new OfficeWorker("James", "A");

            OfficeChair chair1 = new OfficeChair(
                new List<Leg>()
                {
                    new Leg("Recycled Pizza Box", "Pepperoni Brown", new Wheel("Sausage", "Gray")),
                    new Leg("Recycled Pizza Box", "Pepperoni Brown", new Wheel("Sausage", "Gray")),
                    new Leg("Recycled Pizza Box", "Pepperoni Brown", new Wheel("Sausage", "Gray")),
                    new Leg("Recycled Pizza Box", "Pepperoni Brown", new Wheel("Sausage", "Gray")),
                    new Leg("Recycled Pizza Box", "Pepperoni Brown", new Wheel("Sausage", "Gray")),
                }
            );

            chair1.EjectSwitch();
            chair1.Occupant = james;
            chair1.EjectSwitch();

            Console.WriteLine(
                chair1.Legs[0].NeedsReplacement()
            );
        }
    }
}
