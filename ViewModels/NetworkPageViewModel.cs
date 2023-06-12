using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FeaturesDemo.ViewModels
{
    public class NetworkPageViewModel:ViewModel
    {
        private string displayText;
        public string DisplayText { get => displayText; set { displayText = value; OnPropertyChanged(); } }
        public NetworkPageViewModel() 
        {
            if (Connectivity.Current.ConnectionProfiles != null)
            {
                DisplayText = @$"כרגע מחוברים ב {Connectivity.Current.ConnectionProfiles.ToList()[0]} : 
                            - כדי לבדוק מה קורה כשאין חיבוריות העבירו למצב טיסה";
                //אירוע המופעל כאשר יש שינוי בחיבוריות האינטרנט
                Connectivity.Current.ConnectivityChanged += AlertOnConnection;
            }
        }

        private void AlertOnConnection(object sender, ConnectivityChangedEventArgs e)
        {
            if (e.NetworkAccess != NetworkAccess.Internet)
            {
                Shell.Current.DisplayAlert("צרות בגן עדן", "אלוהים! מה עושים החיים עכשיו??!?!?!?", "הצילו");
                DisplayText = @"בטלו את מצב הטיסה כדי לראות שהכל מסתדר";
            }
            else
            {
                Shell.Current.DisplayAlert("חזרה למסלול", "מזל!!!", "תודה");
                if(Connectivity.Current.ConnectionProfiles!=null)
                DisplayText = @$"כרגע מחוברים ב {Connectivity.Current.ConnectionProfiles.ToList()[0]} : 
                            - כדי לבדוק מה קורה כשאין חיבוריות העבירו למצב טיסה";
            }
        }
    }
}
