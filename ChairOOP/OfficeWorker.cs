namespace ChairOOP
{
    public class OfficeWorker
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public OfficeWorker(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FullName()
        {
            // this. is optional, it is automatically implied.
            return FirstName + " " + this.LastName;
        }
    }
}