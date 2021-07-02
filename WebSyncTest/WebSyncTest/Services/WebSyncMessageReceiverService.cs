using FM.WebSync;
using System;
using System.Linq;

namespace WebSyncTest.Services
{
    public class WebSyncMessageReceiverService
    {
        public Client WebSyncClient { get; private set; }

        public WebSyncMessageReceiverService(string websyncUrl)
        {
            Init(websyncUrl);
        }

        public void Init(string websyncUrl)
        {
            //initialize websync client
            WebSyncClient = new Client(websyncUrl);
        }

        public delegate void WebSyncConnectedEventHandler(object sender, WebSyncConnectedEventArgs args);
        public event WebSyncConnectedEventHandler WebSyncConnectedHandler;

        protected virtual void OnWebSyncConnected(WebSyncConnectedEventArgs e)
        {
            WebSyncConnectedEventHandler handler = WebSyncConnectedHandler;
            if (handler != null)
            {
                // Invokes the delegates.
                handler(this, e);
            }
        }

        /// <summary>
        /// connect to websync
        /// </summary>
        public void ConnectWebSync()
        {
            if (WebSyncClient == null)
            {
                //websync client is not initialized
                return;
            }
            if (!IsWebSyncConnected())
            {
                WebSyncClient.Connect(new ConnectArgs()
                {
                    OnStreamFailure = (streamFailureArgs) =>
                    {
                        //Websync connect Stream failure 
                    },
                    OnFailure = (connectFailureArgs) =>
                    {
                        //Could not connect to Apex 
                    },
                    OnSuccess = (connectSuccessArgs) =>
                    {
                        //Connected to WebSync Client
                        OnWebSyncConnected(new WebSyncConnectedEventArgs(true));
                    }

                });
            }
            else
            {
                //Connected to WebSync Client
                OnWebSyncConnected(new WebSyncConnectedEventArgs(true));
            }
        }

        public delegate void WebSyncChannelDataEventHandler(object sender, WebSyncChannelDataEventArgs args);
        public event WebSyncChannelDataEventHandler WebSyncChannelDataHandler;

        protected virtual void OnWebSyncChannelDataReceived(WebSyncChannelDataEventArgs e)
        {
            WebSyncChannelDataEventHandler handler = WebSyncChannelDataHandler;
            if (handler != null)
            {
                // Invokes the delegates.
                handler(this, e);
            }
        }

        public void SubscribeWebsyncChannels(string[] chatIds)
        {
            if (WebSyncClient == null)
            {
                //websync client is not initialized
                return;
            }
            if (!IsWebSyncConnected())
            {
                //Not connected to websync
                return;
            }
            //Connected to WebSync Client
            var boundRecord = WebSyncClient.GetBoundRecords();
            //string chatRoomChannel = GetChatRoomChannel(chatId);
            string[] chatRoomChannels = new string[chatIds.Length];
            for (int i = 0; i < chatIds.Length; i++)
            {
                chatRoomChannels[i] = GetChatRoomChannel(chatIds[i]);
            }
            var subscribedChannelArgs = new SubscribeArgs(chatRoomChannels);
            subscribedChannelArgs.OnFailure = OnWebSyncChannelSubscriptionFailed;
            subscribedChannelArgs.OnSuccess = OnWebSyncChannelSubscribed;
            subscribedChannelArgs.OnReceive = OnWebSyncMessageReceived;
            SubscribeWebsyncChannels(chatIds, subscribedChannelArgs);
        }
        public void SubscribeWebsyncChannels(string chatId)
        {
            SubscribeWebsyncChannels(new string[] { chatId });
        }

        private void SubscribeWebsyncChannels(string[] chatRoomChannels, SubscribeArgs subscribedArgs)
        {
            if (WebSyncClient == null)
            {
                //websync client is not initialized
                return;
            }
            if (!IsWebSyncConnected())
            {
                //Not connected to websync
                return;
            }

            WebSyncClient.Subscribe(subscribedArgs);
        }
        public void OnWebSyncChannelSubscribed(SubscribeSuccessArgs args)
        {
            //log info
        }
        public void OnWebSyncMessageReceived(SubscribeReceiveArgs args)
        {
            OnWebSyncChannelDataReceived(new WebSyncChannelDataEventArgs(args.Channel, args.DataJson));
        }

        public void OnWebSyncChannelSubscriptionFailed(FM.WebSync.SubscribeFailureArgs args)
        {
            //log failure reason
        }

        public static string GetChatRoomChannel(string chatId)
        {
            //return $"/messagetodevice/{chatId}";
            return $"/chatroom/{chatId}";
        }
        public bool IsWebSyncConnected()
        {
            if (WebSyncClient == null)
            {
                //websync client is not initialized
                return false;
            }
            return WebSyncClient.IsConnected;
        }
        public static bool IsChannelSubscribed(string channel, string[] channels)
        {
            return channels != null && channels.Contains(channel);
        }
        private void UnsubscribeWebsyncChannels()
        {
            var channels = WebSyncClient.GetSubscribedChannels();
            if (channels.Length > 0)
            {
                // ensure clean data
                channels = channels.Where(c => c != null && c.StartsWith("/")).ToArray();
                //Unsubscribing from channels
                try
                {
                    WebSyncClient.Unsubscribe(new UnsubscribeArgs(channels)
                    {
                        Synchronous = true,
                        Channels = channels,
                        OnFailure = (errorArgs) =>
                        {
                            //Unsubscribe Failure

                        },
                        OnSuccess = (successArgs) =>
                        {
                            //Unsubscribed from Channels
                        }
                    });
                }
                catch (Exception ex)
                {
                    //log error
                }
            }
        }

        /// <summary>
        /// disconnect from websync
        /// </summary>
        public void DisconnectWebSync()
        {
            if (WebSyncClient == null)
            {
                //websync client is not initialized
                return;
            }
            if (IsWebSyncConnected())
            {
                UnsubscribeWebsyncChannels();
                WebSyncClient.Disconnect(new DisconnectArgs()
                {
                    OnComplete = (completEventArgs) =>
                    {
                        //disconnected from websync
                    }
                });
            }
        }
    }
}
