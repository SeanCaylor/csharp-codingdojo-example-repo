using System;
using System.Collections.Generic;

namespace MessageBoardOOP
{
    public class MessageBoard
    {
        public string Name { get; set; }
        public string Topic { get; set; }

        /* 
        This default value is used no matter which constructor is used. Unless the constructor overwrites this default value.
        */
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public List<Message> Messages { get; set; } = new List<Message>();

        /* 
        When adding a custom constructor method it will REPLACE the deafult.

        If you still want a parameterless constructor you must re-add.
        */
        public MessageBoard() { }

        // Constructor methods must be named the same as the class.
        public MessageBoard(string name, string topic)
        {
            Name = name;
            Topic = topic;
        }

        // When only a name is provided construct with the topic the same as name.
        public MessageBoard(string name)
        {
            Name = name;
            Topic = name;
        }

        // Based on number of messages sent.
        public User GetMostActiveUser()
        {
            // We need a count for every user who sent a message to find out
            // which user sent the most.
            Dictionary<User, int> userMessageCounts = new Dictionary<User, int>();
            int max = 0;
            User mostActive = null;

            foreach (Message msg in this.Messages)
            {
                if (userMessageCounts.ContainsKey(msg.Author))
                {
                    userMessageCounts[msg.Author]++;
                }
                else
                {
                    userMessageCounts.Add(msg.Author, 1);
                }

                if (userMessageCounts[msg.Author] > max)
                {
                    max = userMessageCounts[msg.Author];
                    mostActive = msg.Author;
                }
            }
            return mostActive;
        }
    }
}