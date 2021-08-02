using System.Collections.Generic;

namespace MessageBoardOOP
{
    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();

        public User(string firstName, string lastName, int age)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
        }

        public string FullName()
        {
            return FirstName + " " + LastName;
        }

        public void SendMessage(string content, MessageBoard board)
        {
            Message message = new Message(content, this);
            board.Messages.Add(message);
        }
    }
}