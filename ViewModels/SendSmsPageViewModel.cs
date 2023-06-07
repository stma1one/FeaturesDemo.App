using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace FeaturesDemo.ViewModels
{
    public class SendSmsPageViewModel : ViewModel
    {
        public ObservableCollection<string> Recipients { get; set; }
        private string phoneNumber;
        public string PhoneNumber { get => phoneNumber; set { phoneNumber = value; OnPropertyChanged(); } }
        public ICommand SendCommand { get; private set; }
        public ICommand AddNumber { get;private set; }  


        public SendSmsPageViewModel()
        {
            Recipients = new ObservableCollection<string>();
            AddNumber = new Command(async () => { if (Validate()) Recipients.Add(PhoneNumber); else await Shell.Current.DisplayAlert("X שגיאה", "סלולרי רק בן 10 ספרות", "אישור"); PhoneNumber = string.Empty; } );
            SendCommand = new Command<string>(async (x)=>
           { if (Sms.Default.IsComposeSupported)
               {
                   var message = new SmsMessage(x, Recipients);
                   await Sms.Default.ComposeAsync(message);
               }
               else await Shell.Current.DisplayAlert("הרשאות", "אין הרשאות מתאימות", "אישור");
           
           });
        }

        private bool Validate()
        {
            return (PhoneNumber.Length == 10 && PhoneNumber.StartsWith("05"));
        }
    }
}
