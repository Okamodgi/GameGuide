using Xamarin.Forms;

public partial class GamesPage : ContentPage
{
    GamesViewModel viewModel;

    public GamesPage()
    {
        InitializeComponent();

        BindingContext = viewModel = new GamesViewModel();
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

        // Manually deselect item.
        ((CollectionView)sender).SelectedItem = null;
    }
}
