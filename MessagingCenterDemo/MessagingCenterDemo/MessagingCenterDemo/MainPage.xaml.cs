using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MessagingCenterDemo
{
    public partial class MainPage : ContentPage
    {
        Entry entry1;
        public MainPage()
        {
            BindingContext = new MainPageViewModel();

            // Send messages when buttons are pressed
            var button1 = new Button
            {
                Text = "Say Hi",
                BackgroundColor = Color.CadetBlue
            };
            button1.Clicked += (sender, e) =>
            {
                 MessagingCenter.Send<MainPage,string>(this, "Hi", entry1.Text);
               
            };
            var button2 = new Button
            {
                Text = "Say Hi to Json",
                BackgroundColor = Color.DarkCyan
            };
            button2.Clicked += (sender, e) =>
            {
                MessagingCenter.Send<MainPage, string>(this, "Hi", "John");
            };

            var button3 = new Button
            {
                Text = "Unsubscribe from alert",
                BackgroundColor = Color.DarkGreen
            };
             entry1 = new Entry
            {
                Placeholder = "Enter the text",
                BackgroundColor = Color.Firebrick

            };
            button3.Clicked += (sender, e) =>
            {
                MessagingCenter.Unsubscribe<MainPage, string>(this, "Hi");
                DisplayAlert("Unsubscribed",
                    "This page has stopped listening, so no more alerts; however the ViewModel is still receiving messages.",
                    "OK");
            };

            // Subscribe to a message (which the ViewModel has also subscribed to) to pop up an Alert
            MessagingCenter.Subscribe<MainPage, string>(this, "Hi", (sender, arg) =>
            {
                DisplayAlert("Message Received", "arg=" + arg, "OK");
            });

            var listView = new ListView();
            listView.SetBinding(ListView.ItemsSourceProperty, "Greetings");

            Content = new StackLayout
            {
                Padding = new Thickness(0, 20, 0, 0),
                Children = {  button1, entry1, button2, button3, listView }
            };
        }
    }
}
