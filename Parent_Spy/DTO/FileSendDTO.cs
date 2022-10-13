using System;

namespace Parent_Spy.DTO
{
    public class FileSendDTO
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FilePath { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }       
    }
}
