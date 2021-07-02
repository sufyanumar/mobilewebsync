using System;

namespace WebSyncTest.Services
{
    public class WebSyncConnectedEventArgs : EventArgs
    {
        public bool IsConnected { get; }

        public WebSyncConnectedEventArgs(bool isConnected)
        {
            IsConnected = isConnected;
        }
    }
}
