
using UIChallenge.Models;
using UIChallenge.Service;
using Microsoft.Maui.Controls;
using AlohaKit.Animations;

namespace UIChallenge.Views;

public partial class PlanetsPage : ContentPage
{
    private const uint AnimationDuration = 800u;

    public PlanetsPage()
    {
        InitializeComponent();
    }


    protected override void OnAppearing()
    {
        base.OnAppearing();

        lstPopularPlanets.ItemsSource = PlanetService.GetFeaturedPlanets();
        lstAllPlanets.ItemsSource = PlanetService.GetAllPlanets();
    }

    async void Planets_SelectionChanged(System.Object sender, SelectionChangedEventArgs e)
    {
        await Navigation.PushAsync(new PlanetsDetailPage(e.CurrentSelection.First() as Planets));
    }

    async void ProfilePic_Clicked(System.Object sender, System.EventArgs e)
    {

        await Navigation.PushAsync(new StartPage());
        //// Reveal our menu and move the main content out of the view
        //await (_ = MainContentGrid.TranslateTo(-this.Width * 0.5, this.Height * 0.1, AnimationDuration, Easing.CubicIn));
        //await MainContentGrid.ScaleTo(0.8, AnimationDuration);
        //_ = MainContentGrid.FadeTo(0.8, AnimationDuration);
    }

    async void GridArea_Tapped(System.Object sender, System.EventArgs e)
    {
        await CloseMenu();
    }

    private async Task CloseMenu()
    {
        //Close the menu and bring back back the main content
        _ = MainContentGrid.FadeTo(1, AnimationDuration);
        _ = MainContentGrid.ScaleTo(1);
        await MainContentGrid.TranslateTo(0, 0, AnimationDuration, Easing.CubicIn);
    }

    private void GridArea_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {

    }

    private void OnSearchButtonPressed(object sender, EventArgs e)
    {
        SearchBar search = sender as SearchBar;
        lstAllPlanets.ItemsSource = PlanetService.GetSearchedPlanet(search.Text);
        lstPopularPlanets.ItemsSource = PlanetService.GetSearchedPlanet(search.Text).Take(2);

    }
}