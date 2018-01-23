using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MessagingCenterDemo
{
    public class MainPageViewModel
    {
        public ObservableCollection<string> Greetings { get; set; }

        public MainPageViewModel()
        {
            Greetings = new ObservableCollection<string>();

            MessagingCenter.Subscribe<MainPage>(typeof(MainPage), "Hi", (sender) => 
            {
                Greetings.Add("Hi");
            });

            MessagingCenter.Subscribe<MainPage, string>(typeof(MainPage), "Hi", (sender, arg) => 
            {
                Greetings.Add("Hi " + arg);
            });
        }
    }
}