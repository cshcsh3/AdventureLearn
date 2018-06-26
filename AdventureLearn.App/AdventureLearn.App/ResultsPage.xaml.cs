using Microcharts;
using Microcharts.Forms;
using SkiaSharp;
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
	public partial class ResultsPage : ContentPage
	{
        private readonly float score;

		public ResultsPage (float score)
		{
			InitializeComponent ();
            this.score = score;

            MessageLabel.Text = GetGritMessage(score);

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

        }

        private string GetGritMessage(double gritScore)
        {
            if (gritScore > 4.5)
            {
                return "The power of the grit is within you!";
            }
            else if (gritScore > 4.0 && gritScore < 4.5)
            {
                return "You have a great grit on things!";
            }
            else if (gritScore > 3.5 && gritScore < 4.0)
            {
                return "You have a good grit on things!";
            }
            else if (gritScore > 3.0 && gritScore < 3.5)
            {
                return "You have a grit on things!";
            }
            else if (gritScore > 2.0 && gritScore < 3.0)
            {
                return "The grit is there, but needs a bit more...";
            }
            else
            {
                return "Missing a lot of grittiness!";
            }
        }
    }
}