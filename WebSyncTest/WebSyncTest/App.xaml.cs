using ApexChat;
using ApexChat.Core.Helpers;
using ApexChat.Enums;
using Plugin.Connectivity;
using Prism;
using Prism.Ioc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using WebSyncTest.Models;
using WebSyncTest.Services;
using WebSyncTest.ViewModels;
using WebSyncTest.Views;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

namespace WebSyncTest
{
    public partial class App
    {
        public static string Company = "sufyan1";
        public static string User = "sufyan";
        public static string Password = "123456";
        private static string Schema => "https";
        private static string Host = "staging.apexchat.com";
        public static string ServiceBaseUrl => $"{Schema}://{Host}";
        public static string WebSyncHandler => "/websync.ashx";
        public string ChatID { get; set; }
        public ObservableCollection<string> Msgs = new ObservableCollection<string>();

        public WebSyncMessageReceiverService WebSyncMessageReceiverIntsance { get; private set; }
        ApiService apiService;
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            apiService = new ApiService();
            //Initialize Websync
            WebSyncMessageReceiverIntsance = new WebSyncMessageReceiverService(ServiceBaseUrl + WebSyncHandler);
            CrossConnectivity.Current.ConnectivityChanged += Current_ConnectivityChanged;

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        private void Current_ConnectivityChanged(object sender, Plugin.Connectivity.Abstractions.ConnectivityChangedEventArgs e)
        {
            ConnectWebSync();
        }

        public void ConnectWebSync() 
        {
            if (CrossConnectivity.Current.IsConnected && !string.IsNullOrWhiteSpace(ChatID))
            {
                Msgs.Clear();
                LoadChat();

                WebSyncMessageReceiverIntsance.WebSyncConnectedHandler -= WebSyncMessageReceiverIntsance_WebSyncConnectedHandler;
                WebSyncMessageReceiverIntsance.WebSyncChannelDataHandler -= WebSyncMessageReceiverIntsance_WebSyncChannelDataHandler;

                WebSyncMessageReceiverIntsance.WebSyncConnectedHandler += WebSyncMessageReceiverIntsance_WebSyncConnectedHandler;
                WebSyncMessageReceiverIntsance.WebSyncChannelDataHandler += WebSyncMessageReceiverIntsance_WebSyncChannelDataHandler;
                WebSyncMessageReceiverIntsance.ConnectWebSync();
            }
        }
        public async void LoadChat()
        {
            if (!string.IsNullOrEmpty(ChatID))
            {
                //Fetch chat history if there is any message or greeting
                var textChatHistory = await apiService.TextChatHistoryList(ChatID);
                if (textChatHistory != null && textChatHistory.Data != null && textChatHistory.Data.Count > 0)
                {
                    //Filter only greeting or any other messages
                    var items = textChatHistory.Data.Where(c => (!c.Response.Contains("(via Submit Form") && c.Response != StringConstants.LIVE_SESSION_ENDED)).ToList();
                    if (items != null && items.Count > 0)
                    {
                        Msgs.Clear();
                        //Append each message in the list
                        foreach (var item in items)
                        {
                            Msgs.Add(item.Response);
                        }
                    }
                }
            }
        }
        private void WebSyncMessageReceiverIntsance_WebSyncChannelDataHandler(object sender, WebSyncChannelDataEventArgs args)
        {
            OnWebSyncMessageReceived(args);
        }
        public void OnWebSyncMessageReceived(WebSyncChannelDataEventArgs args)
        {
            //Received a message!. Check args.DataJson
            if (!string.IsNullOrWhiteSpace(args.DataJson))
            {
                try
                {
                    // the initial deserialize will take care of the text and sender
                    ChatLog log = FM.Json.Deserialize<ChatLog>(args.DataJson);
                    if (log != null)
                    {
                        if (log.ChatID == int.Parse(ChatID))
                        {
                            Msgs.Add(log.Text);
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
        }
        private void WebSyncMessageReceiverIntsance_WebSyncConnectedHandler(object sender, WebSyncConnectedEventArgs args)
        {
            WebSyncMessageReceiverIntsance.SubscribeWebsyncChannels(new string[] { ChatID });
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ListPage, ListPageViewModel>();
        }
    }
}
