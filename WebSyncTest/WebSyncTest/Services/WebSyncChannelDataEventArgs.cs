using WebSyncTest.Models;
using System;

namespace WebSyncTest.Services
{
    public class WebSyncChannelDataEventArgs : EventArgs
    {
        public string Channel { get; }
        public string DataJson { get; }
        public WebSyncChannelDataEventArgs(string channel, string dataJson)
        {
            Channel = channel;
            DataJson = dataJson;
        }

        public ChatLog GetChatLogData
        {
            get
            {
                if (string.IsNullOrWhiteSpace(DataJson))
                {
                    return null;
                }
                ChatLog log = FM.Json.Deserialize<ChatLog>(DataJson);
                return log;
            }
        }

    }
}
