using GameGuide.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

public class MainPageViewModel : BaseViewModel
{
    private readonly IGameDataStore dataStore;

    public ObservableCollection<Game> Games { get; }

    public MainPageViewModel()
    {
        Title = "Games";
        Games = new ObservableCollection<Game>();
        dataStore = DependencyService.Get<IGameDataStore>();
        LoadGamesCommand = new Command(async () => await ExecuteLoadGamesCommand());
    }

    public Command LoadGamesCommand { get; }

    async Task ExecuteLoadGamesCommand()
    {
        IsBusy = true;

        try
        {
            Games.Clear();
            var games = await dataStore.GetGamesAsync();
            foreach (var game in games)
            {
                Games.Add(game);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
