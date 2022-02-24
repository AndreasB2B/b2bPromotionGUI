namespace KN.Messaging.SendGrid
{
    public class EmailMessage
    {
        public User From { get; set; }
        public User To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string HtmlContent { get; set; }

        public EmailMessage(User from, User to, string subject, string content, string htmlContent = null)
        {
            From = from;
            To = to;
            Subject = subject;
            Content = content;
            HtmlContent = htmlContent;
        }
    }
}
