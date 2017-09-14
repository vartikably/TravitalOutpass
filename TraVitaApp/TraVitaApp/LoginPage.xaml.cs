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
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private async Task Button_Clicked(object sender, EventArgs e)
        {
            Int64 val = Int64.Parse(MobileNo.Text);
            Student userDetail = App.Database.GetItem(val, RegId.Text);

            if (userDetail != null)
            {
                if (val != userDetail.MobileNo && RegId.Text != userDetail.regID)
                {
                    await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
                }
                else
                {
                    await DisplayAlert("Registrtion", "Login Success ...  ", "OK");
                    await Navigation.PushModalAsync(new FrontPage());
                }
            }
            else
            {
                await DisplayAlert("Login", "Login failed .. Please try again ", "OK");
            }

        }
        private bool _canClose = true;

        protected override bool OnBackButtonPressed()
        {
            if (_canClose)
            {
                ShowExitDialog();
            }
            return _canClose;
        }

        private async void ShowExitDialog()
        {
            var answer = await DisplayAlert("Exit", "Do you wan't to exit the App?", "Yes", "No");
            if (answer)
            {
                _canClose = false;
                OnBackButtonPressed();
            }
        }
    }
}