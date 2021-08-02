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
    }
}