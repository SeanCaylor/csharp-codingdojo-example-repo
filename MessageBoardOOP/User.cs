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
            Message message = new Message(content, board, this);
            board.Messages.Add(message);

            this.Messages.Add(message);
        }

        public int NumberOfMessageBoardsUsed()
        {
            // We could use either a Set or a Dictionary or HashMap, etc.
            Dictionary<MessageBoard, bool> seenBoardsTable = new Dictionary<MessageBoard, bool>();
            HashSet<MessageBoard> seenBoardsSet = new HashSet<MessageBoard>();

            foreach (Message msg in this.Messages)
            {
                if (!seenBoardsTable.ContainsKey(msg.Board))
                {
                    seenBoardsTable.Add(msg.Board, true);
                }

                // A set (by default won't add duplicates) is easier for this.
                seenBoardsSet.Add(msg.Board);
            }

            return seenBoardsTable.Count;
            // return seenBoardsSet.Count;
        }
    }
}