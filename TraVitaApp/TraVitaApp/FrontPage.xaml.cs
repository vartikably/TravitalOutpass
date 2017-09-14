using Plugin.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TraVitaApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FrontPage : ContentPage
    {
        //Student mSelfStudent;
      
        

        public FrontPage()
        {
            InitializeComponent();
          
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var smsMessenger = CrossMessaging.Current.SmsMessenger;
            if (smsMessenger.CanSendSms)
                smsMessenger.SendSms("Papa", "I am coming home Today. If you agree Reply Yes otherwise No");
        }

        private void Reason_SelectedIndexChanged(object sender, EventArgs e)
        {
            var reason = Reason.Items[Reason.SelectedIndex];
        }


        //async void Click_Login(object sender, EventArgs e)
        //{
        //    await Navigation.PushModalAsync(new MainPage());

        //}

    }
}