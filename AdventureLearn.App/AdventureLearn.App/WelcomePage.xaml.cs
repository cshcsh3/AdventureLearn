using AdventureLearn.Models;
using AdventureLearn.Services;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AdventureLearn.App
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class WelcomePage : ContentPage
	{
        private readonly String name;

		public WelcomePage (String name)
		{
			InitializeComponent ();
            this.name = name;

            WelcomeLabel.Text = "Welcome, " + name + "!";

            // Populate surveys to listview
            var surveys = AsyncContext.Run(SurveyService.GetSurveys);

            var tableItems = new List<string>();
            for (var i = 0; i < surveys.Count; i++)
            {
                tableItems.Add(surveys[i].No + " " + surveys[i].Title);
            }

            SurveyListView.ItemsSource = tableItems;

            SurveyListView.ItemSelected += async (sender, e) => {
                if (e.SelectedItem == null)
                    return;
                SurveyListView.SelectedItem = null; // deselect row

                string selectedItem = (string)e.SelectedItem;
                string no = selectedItem.Split(' ')[0];

                Survey survey = await SurveyService.GetSurvey(no);
                await Navigation.PushAsync(new SurveyPage(survey));
            };

        }
    }
}