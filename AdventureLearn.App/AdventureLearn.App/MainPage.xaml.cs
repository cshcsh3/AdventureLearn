using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AdventureLearn.Models;
using AdventureLearn.Services;
using System.Reflection;
using System.IO;

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
            var assembly = typeof(AdventureLearn).GetTypeInfo().Assembly;
           
            Stream audioStream = assembly.GetManifestResourceStream("AdventureLearn.Sounds." + "button.mp3");
            
            var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
            player.Load(audioStream);

            player.Play();

            User user = await UserService.GetUser("joe@test.com");

            if (user != null)
            {
                await Navigation.PushAsync(new WelcomePage(user.Name));
            }
        }
    }
}
