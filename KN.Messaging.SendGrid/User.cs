namespace KN.Messaging.SendGrid
{
    public class User
    {
        public string Name { get; set; }
        public string EmailAddress { get; set; }

        public User(string emailAddress, string name = null)
        {
            Name = name;
            EmailAddress = emailAddress;
        }
    }
}
