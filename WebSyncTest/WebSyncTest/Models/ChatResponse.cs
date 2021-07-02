using ApexChat.Models;
using ApexChat.Helpers.Extensions;
using System;
namespace ApexChat.Models
{
    public class ChatResponse
    {
        private const int ResponseLength = 42;
        public int ChatLogId { get; set; }
        public bool IsUnread { get; set; }
        public string Response { get; set; }
        public int UserId { get; set; }
        public int ParticipantId { get; set; }
        public string ParticipantName { get; set; }
        public DateTime CreatedOn { get; set; }

        public string TranscriptString { get { return string.Format("[{0}] {1}: {2}", CreatedOn.ToLocalTimeZone(), ParticipantName, Response); } }
        public override string ToString()
        {
            var log = Response;//string.Format("{0} : {1}", ParticipantName, Response);
            return string.Format("{0}", log.Length> ResponseLength ? log.Truncate(ResponseLength) : log);            
        }

    }
}