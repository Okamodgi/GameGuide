using Xamarin.Forms;

public partial class SectionItemDetailPage : ContentPage
{
    SectionItemDetailViewModel viewModel;

    public SectionItemDetailPage(string itemId)
    {
        InitializeComponent();

        BindingContext = viewModel = new SectionItemDetailViewModel(itemId);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.LoadItemCommand.Execute(null);
    }
}
