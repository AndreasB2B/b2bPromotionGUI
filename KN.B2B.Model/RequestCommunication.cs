using System;

namespace KN.B2B.Model
{
    public class RequestCommunication
    {
        public int Id { get; set; }
        public Request Request { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string Recipient { get; set; }
    }
}
