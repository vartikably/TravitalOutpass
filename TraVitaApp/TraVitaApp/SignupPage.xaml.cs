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
    public partial class SignupPage : ContentPage
    {
        /*public StudentDB _studentdb;
        public Student student;*/
        public SignupPage()
        {
            InitializeComponent();
        }

        private async Task Signup_Clicked(object sender, EventArgs e)
        { 
             Int64 value = Int64.Parse(phone.Text);
             if (regId != null)
             {
                 Student fileexist = App.Database.GetItem(value);
                 if (fileexist == null)
                 {
                     if (firstName.Text != "" && lastName.Text != "" && address.Text != "" && parent_Phone.Text != "")
                     {
                         Student OReg = new Student();
                         OReg.FirstName = firstName.Text;
                         OReg.LastName = lastName.Text;
                         OReg.Address = address.Text;
                         OReg.MobileNo = value;
                         OReg.ParentsMob = parent_Phone.Text;
                         Int64 i = App.Database.SaveItem(OReg);
                         if (i > 0)
                         {
                             await DisplayAlert("Registrtion", "Registrtion Success ... Login and Edit profile ", "OK");
                             await Navigation.PushAsync(new FrontPage());
                         }
                         else
                         {
                             await DisplayAlert("Registrtion", "Registrtion Fail .. Please try again ", "OK");
                         }
                     }
                 }
                 else
                 {
                     await DisplayAlert("Registrtion Failed", "username already exist .. Please try differnt user name ", "OK");

                 }
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