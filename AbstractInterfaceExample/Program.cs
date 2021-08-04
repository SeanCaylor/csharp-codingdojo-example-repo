using System;
using System.Collections.Generic;

namespace AbstractInterfaceExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            Bunker bunker1 = new Bunker("Bunker1");
            Hero theLaw = new Hero("I AM THE LAW!", bunker1);

            Hero mepuka = new Hero("Prepare to be attacked, recursively!");

            mepuka.Attack(theLaw);
            mepuka.Attack(bunker1);

            Console.WriteLine(bunker1.Floors);
        }
    }
}
