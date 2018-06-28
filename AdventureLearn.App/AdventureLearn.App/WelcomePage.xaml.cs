using AdventureLearn.Models;
using AdventureLearn.Services;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdventureLearn.App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
		public WelcomePage (User user)
		{
			InitializeComponent ();

            WelcomeLabel.Text = "Welcome, " + user.Name + "!";

            // Populate surveys to listview
            var surveys = AsyncContext.Run(SurveyService.GetSurveys);

            var tableItems = new List<string>();
            for (var i = 0; i < surveys.Count; i++)
            {
                tableItems.Add(surveys[i].No + " " + surveys[i].Title);
            }

            SurveyListView.ItemsSource = tableItems;

            SurveyListView.ItemSelected += async (sender, e) => {
                // Play sound effect
                var assembly = typeof(AdventureLearn).GetTypeInfo().Assembly;
                Stream audioStream = assembly.GetManifestResourceStream("AdventureLearn.Sounds." + "button.mp3");

                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(audioStream);

                player.Play();

                if (e.SelectedItem == null)
                    return;
                SurveyListView.SelectedItem = null; // deselect row

                string selectedItem = (string)e.SelectedItem;
                string id = selectedItem.Split(' ')[0];

                Survey survey = await SurveyService.GetSurvey(id);
                await Navigation.PushAsync(new SurveyPage(survey, user));
            };

        }
    }
}