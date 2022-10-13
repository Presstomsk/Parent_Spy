using System;

namespace Parent_Spy.DTO
{
    public class SiteSendDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Url { get; set; }
        public DateTime Date { get; set; }
        public string Host { get; set; }
    }
}
