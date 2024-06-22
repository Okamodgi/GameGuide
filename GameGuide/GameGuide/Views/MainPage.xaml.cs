using Xamarin.Forms;
using System.Linq;


public partial class MainPage : ContentPage
{
    MainPageViewModel viewModel;

    public MainPage()
    {
        InitializeComponent();
        BindingContext = new MainPageViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (viewModel.Games.Count == 0)
            viewModel.LoadGamesCommand.Execute(null);
    }

    async void OnGameSelected(object sender, SelectionChangedEventArgs args)
    {
        var game = args.CurrentSelection.FirstOrDefault() as Game;
        if (game == null)
            return;

        await Navigation.PushAsync(new SectionsPage(game.Id));
        ((CollectionView)sender).SelectedItem = null;
    }
}
