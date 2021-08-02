using System;
using System.Collections.Generic;

namespace MessageBoardOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            // DataType varName = startingValue

            // Using the default constructor
            // MessageBoard stonks = new MessageBoard()
            // {
            //     Name = "Stonks",
            //     Topic = "Everything Stonks, buy low sell high!",
            //     CreatedAt = DateTime.Now
            // };

            MessageBoard stonks = new MessageBoard("Stonks", "Everything Stonks, buy low sell high!");

            MessageBoard doggos = new MessageBoard("Doggos");

            Console.WriteLine(stonks.Name);
            Console.WriteLine(stonks.Topic);
            Console.WriteLine(stonks.CreatedAt);

            Console.WriteLine(doggos.Topic);
        }
    }
}
