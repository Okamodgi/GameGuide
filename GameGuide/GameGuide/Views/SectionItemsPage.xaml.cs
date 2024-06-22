using Xamarin.Forms;

public partial class SectionItemsPage : ContentPage
{
    SectionItemsViewModel viewModel;

    public SectionItemsPage(string sectionId)
    {
        InitializeComponent();

        BindingContext = viewModel = new SectionItemsViewModel(sectionId);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (viewModel.SectionItems.Count == 0)
            viewModel.LoadSectionItemsCommand.Execute(null);
    }

    async void OnSectionItemSelected(object sender, SelectionChangedEventArgs args)
    {
        var item = args.CurrentSelection.FirstOrDefault() as SectionItem;
        if (item == null)
            return;

        await Navigation.PushAsync(new SectionItemDetailPage(item.Id));

        // Manually deselect item.
        ((CollectionView)sender).SelectedItem = null;
    }
}
