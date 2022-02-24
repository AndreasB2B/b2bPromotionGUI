using KN.Messaging.SendGrid;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace KN.B2B.Tests
{
    [TestClass]
    public class EmailTests
    {
        [TestMethod]
        public async Task SendTestEmail()
        {
            //Arrange
            var subject = "Hey Hey, look at that.";
            var html = "Because the emails are working. <br> <b> And it's probably the user. </b>";
            var email = new EmailMessage(
                new User("[deleted]", "Name"),
                new User("[deleted]", "Name"),
                subject,
                "",
                html);
            var service = new EmailSender("[deleted]");

            //Act
            var response = await service.Send(email);

            //Assert
            Assert.IsTrue(response.IsSuccessStatusCode);
        }

        [TestMethod]
        public async Task SendTestEmail2()
        {
            //Arrange
            var service = new EmailSender(
                "[deleted]",
                "[deleted]",
                "B2B Web Service");

            //Act
            await service.SendEmailAsync("[deleted]", "Test test", "<b>Working?</b>");

            //Assert
            Assert.IsTrue(true);
        }

        //static async Task Execute()
        //{
        //    var apiKey = Environment.GetEnvironmentVariable("NAME_OF_THE_ENVIRONMENT_VARIABLE_FOR_YOUR_SENDGRID_KEY");
        //    var client = new SendGridClient(apiKey);
        //    var from = new EmailAddress("test@example.com", "Example User");
        //    var subject = "Sending with SendGrid is Fun";
        //    var to = new EmailAddress("test@example.com", "Example User");
        //    var plainTextContent = "and easy to do anywhere, even with C#";
        //    var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
        //    var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
        //    var response = await client.SendEmailAsync(msg);
        //}
    }
}
