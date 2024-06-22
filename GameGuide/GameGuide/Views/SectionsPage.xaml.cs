using Xamarin.Forms;

public partial class SectionsPage : ContentPage
{
    SectionsViewModel viewModel;

    public SectionsPage(string gameId)
    {
        InitializeComponent();

        BindingContext = viewModel = new SectionsViewModel(gameId);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        if (viewModel.Sections.Count == 0)
            viewModel.LoadSectionsCommand.Execute(null);
    }

    async void OnSectionSelected(object sender, SelectionChangedEventArgs args)
    {
        var section = args.CurrentSelection.FirstOrDefault() as Section;
        if (section == null)
            return;

        await Navigation.PushAsync(new SectionItemsPage(section.Id));

        // Manually deselect item.
        ((CollectionView)sender).SelectedItem = null;
    }
}
