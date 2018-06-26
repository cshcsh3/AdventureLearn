using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AdventureLearn.Models;
using AdventureLearn.Services;

namespace AdventureLearn.App
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        private async void OnLogin(object sender, EventArgs e)
        {
            User user = await UserService.GetUser(email.Text);

            if (user != null)
            {
                await Navigation.PushAsync(new WelcomePage(user.Name));
            }
        }
    }
}
