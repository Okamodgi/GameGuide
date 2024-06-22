using GameGuide.ViewModels;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

public class SectionItemsViewModel : BaseViewModel
{
    private readonly IGameDataStore dataStore;
    private string sectionId;

    public ObservableCollection<SectionItem> SectionItems { get; }

    public SectionItemsViewModel(string sectionId)
    {
        this.sectionId = sectionId;
        Title = "Section Items";
        SectionItems = new ObservableCollection<SectionItem>();
        dataStore = DependencyService.Get<IGameDataStore>();
        LoadSectionItemsCommand = new Command(async () => await ExecuteLoadSectionItemsCommand());
    }

    public Command LoadSectionItemsCommand { get; }

    async Task ExecuteLoadSectionItemsCommand()
    {
        IsBusy = true;

        try
        {
            SectionItems.Clear();
            var items = await dataStore.GetSectionItemsAsync(sectionId);
            foreach (var item in items)
            {
                SectionItems.Add(item);
            }
        }
        finally
        {
            IsBusy = false;
        }
    }
}
