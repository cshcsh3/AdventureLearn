using AdventureLearn.Data;
using AdventureLearn.Models;
using AsNum.XFControls;
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
	public partial class SurveyPage : ContentPage
	{
        private readonly Survey survey;
        Dictionary<int, RadioGroup> selectedRadioGroups = new Dictionary<int, RadioGroup>();
        Dictionary<int, String> selectedOptions = new Dictionary<int, String>();

        public SurveyPage (Survey survey)
		{
			InitializeComponent ();
            this.survey = survey;

            TitleLabel.Text = survey.Title;

            for (int i = 0; i < survey.Questions.Length; i++)
            {
                Label qns = new Label
                {
                    Text = survey.Questions[i].Qns,
                    FontSize = 16,
                    Margin = new Thickness(5, 5, 5, 7)
                };

                SurveyStack.Children.Add(qns);

                RadioGroup radioGroup = new RadioGroup
                {
                    Orientation = StackOrientation.Vertical,
                    ItemsSource = survey.Questions[i].Options
                };

                selectedRadioGroups.Add(i, radioGroup);

                SurveyStack.Children.Add(radioGroup);
            }
        }

        async void OnSurveySubmit(object sender, EventArgs e)
        {
            // Converts RadioGroup to String as a dictionary
            foreach (KeyValuePair<int, RadioGroup> entry in selectedRadioGroups)
            {
                if (entry.Value.SelectedItem == null) {
                    await DisplayAlert("Oops", "Please select an option for all questions!", "OK");
                    return;

                } else {
                    selectedOptions.Add(entry.Key, entry.Value.SelectedItem.ToString());
                }
            }

            GenerateResult generateResult = new GenerateResult(selectedOptions);
            await Navigation.PushAsync(new ResultsPage(generateResult.GetGritScore()));
        }
    }
}