using AdventureLearn.Data;
using AdventureLearn.Models;
using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
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
	public partial class ResultsPage : ContentPage
	{
        public ResultsPage (GenerateResult generateResult, User user)
		{
			InitializeComponent ();
            float score = generateResult.GetGritScore();
        
            MessageLabel.Text = generateResult.GetGritMessage();

            // Prepare data for chart
            var entries = new[]
            {
                new Microcharts.Entry(score)
                {
                    Label = "Grit",
                    ValueLabel = score.ToString(),
                    Color = SKColor.Parse("#2c3e50")
                },
                new Microcharts.Entry(2)
                {
                    Label = "Some Stat",
                    ValueLabel = "2",
                    Color = SKColor.Parse("#77d065")
                },
                new Microcharts.Entry(3)
                {
                    Label = "Some Stat",
                    ValueLabel = "3",
                    Color = SKColor.Parse("#b455b6")
                },
                new Microcharts.Entry(4)
                {
                    Label = "Some Stat",
                    ValueLabel = "4",
                    Color = SKColor.Parse("#3498db")
                }
            };

            // Create a radar chart
            var chart = new RadarChart() { Entries = entries };

            ChartView chartView = new ChartView
            {
                HeightRequest = 140,
                Chart = chart
            };

            ResultsStack.Children.Add(chartView);

            Button doneButton = new Button
            {
                Text = "Done",
                FontSize = 16,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };

            doneButton.Clicked += async (sender, e) => {
                // Play sound effect
                var assembly = typeof(AdventureLearn).GetTypeInfo().Assembly;
                Stream audioStream = assembly.GetManifestResourceStream("AdventureLearn.Sounds." + "button.mp3");

                var player = Plugin.SimpleAudioPlayer.CrossSimpleAudioPlayer.Current;
                player.Load(audioStream);

                player.Play();

                await Navigation.PushAsync(new WelcomePage(user));
            };

            ResultsStack.Children.Add(doneButton);
        }
    }
}