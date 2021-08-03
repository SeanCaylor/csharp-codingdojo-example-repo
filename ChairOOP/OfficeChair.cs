using System;
using System.Collections.Generic;

namespace ChairOOP
{
    public class OfficeChair
    {
        public bool HasLumbarSupport { get; set; }
        public List<Leg> Legs { get; set; } = new List<Leg>();
        public OfficeWorker Occupant { get; set; }

        // No constructors defined means there is an empty one with no params automatically available.

        public OfficeChair(List<Leg> legs, bool hasLumbarSupport = true)
        {
            Legs = legs;
            HasLumbarSupport = hasLumbarSupport;
        }

        public OfficeWorker EjectSwitch()
        {
            OfficeWorker temp = Occupant;

            if (Occupant == null)
            {
                Console.WriteLine("No one to eject!");
            }
            else
            {
                Console.WriteLine($"{Occupant.FullName()} has been ejected from this chair!");
                Occupant = null;
            }

            return temp;
        }
    }
}