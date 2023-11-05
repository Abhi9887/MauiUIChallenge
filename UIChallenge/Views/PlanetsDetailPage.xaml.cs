using UIChallenge.Models;

namespace UIChallenge.Views;

public partial class PlanetsDetailPage : ContentPage
{
	public PlanetsDetailPage(Planets planets)
	{
		InitializeComponent();
		this.BindingContext = planets;
	}
    async void BackButton_Clicked(System.Object sender, System.EventArgs e)
    {
        await Navigation.PopAsync();
    }


}