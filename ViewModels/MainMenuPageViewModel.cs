using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FeaturesDemo.ViewModels
{
    public  class MainMenuPageViewModel:ViewModel
    {
        private string title;
        public string Title { get => title; set { if (title != value) { title = value; OnPropertyChanged(); } } }

        public ICommand NavConnectivityCommand { get;private set; }    
        public ICommand NavSendSMSCommand { get;private set; }

        public ICommand NavTakePictureCommand { get;private set; }

        public MainMenuPageViewModel() 
        {
            Title = "תפריט בדיקות";
            NavConnectivityCommand = new Command(async () =>
            {
                await Shell.Current.DisplayAlert("יש אינטרנט?", "לאחר לחיצה על אישור נעבור לבדיקה", "אישור");
               await Shell.Current.GoToAsync("networkpage");
               
            });
            NavSendSMSCommand = new Command(async () => { await Shell.Current.GoToAsync("sendsmspage"); });
            NavTakePictureCommand = new Command(async () => { await Shell.Current.GoToAsync("takepicture"); });
        
        }  
    }
}
