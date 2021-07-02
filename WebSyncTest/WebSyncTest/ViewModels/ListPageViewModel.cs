using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace WebSyncTest.ViewModels
{
    public class ListPageViewModel:ViewModelBase
    {
        public ObservableCollection<string> Msgs { get; set; }
        public string ChatID { get; set; }
        public Command SubscribeChat { get; }
        public ListPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Msgs = ((App)Application.Current).Msgs; //Set initial chat msgs
            SubscribeChat = new Command(() => 
            {
                Msgs.Clear(); //On subscribing new chat, clear the msg list
                ((App)Application.Current).ChatID = ChatID;
                ((App)Application.Current).LoadChat();
                ((App)Application.Current).ConnectWebSync();
            });
        }
    }
}
