using System;

namespace MessageBoardOOP
{
    public class Message
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public User Author { get; set; }
        public MessageBoard Board { get; set; }

        public Message(string content, MessageBoard board, User author)
        {
            Content = content;
            Board = board;
            Author = author;
        }
    }
}