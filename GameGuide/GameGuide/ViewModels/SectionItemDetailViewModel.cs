using GameGuide.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

public class SectionItemDetailViewModel : BaseViewModel
{
    private readonly IGameDataStore dataStore;
    private string itemId;

    private SectionItem item;
    public SectionItem Item
    {
        get => item;
        set => SetProperty(ref item, value);
    }

    public SectionItemDetailViewModel(string itemId)
    {
        this.itemId = itemId;
        Title = "Item Details";
        dataStore = DependencyService.Get<IGameDataStore>();
        LoadItemCommand = new Command(async () => await ExecuteLoadItemCommand());
    }

    public Command LoadItemCommand { get; }

    async Task ExecuteLoadItemCommand()
    {
        IsBusy = true;

        try
        {
            Item = await dataStore.GetSectionItemAsync(itemId);
        }
        finally
        {
            IsBusy = false;
        }
    }
}
