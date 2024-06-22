using GameGuide.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

public class SectionsViewModel : BaseViewModel
{
    private readonly IGameDataStore dataStore;
    private string gameId;

    public ObservableCollection<Section> Sections { get; }

    public SectionsViewModel(string gameId)
    {
        this.gameId = gameId;
        Title = "Sections";
        Sections = new ObservableCollection<Section>();
        dataStore = DependencyService.Get<IGameDataStore>();
        LoadSectionsCommand = new Command(async () => await ExecuteLoadSectionsCommand());
    }

    public Command LoadSectionsCommand { get; }

    async Task ExecuteLoadSectionsCommand()
    {
        IsBusy = true;

        try
        {
            Sections.Clear();
            var sections = await dataStore.GetSectionsAsync(gameId);
            foreach (var section in sections)
            {
                Sections.Add(section);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
