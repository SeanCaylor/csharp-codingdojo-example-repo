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

            User highMylage = new User("Myles", "W", 25);
            User james = new User("James", "A", 27);
            User echo = new User("Echo", "T", 22);
            User theLaw = new User("Lawrence", "C", 38);

            highMylage.SendMessage("I'm holding bitcoin forever, no paper hands here!", stonks);

            james.SendMessage("Lol, BTC is worth exactly zero you dummies!", stonks);
            echo.SendMessage("Aussies are my favorite kind of doggo.", doggos);
            theLaw.SendMessage("Huskies are better than Aussies. I love drama queens!", doggos);
            theLaw.SendMessage("Basenjis don't bark, they yodel.", doggos);
            theLaw.SendMessage("Eth is going to be worth more than BTC you crazy maximalists.", stonks);

            Console.WriteLine(theLaw.NumberOfMessageBoardsUsed());
            Console.WriteLine(doggos.GetMostActiveUser());
        }
    }
}
