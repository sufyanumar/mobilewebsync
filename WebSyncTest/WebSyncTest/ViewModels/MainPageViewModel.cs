using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace WebSyncTest.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public Command ShowMsgCommand { get; }
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            ShowMsgCommand = new Command(() => 
            { 
                navigationService.NavigateAsync("ListPage"); 
            });
        }
    }
}
