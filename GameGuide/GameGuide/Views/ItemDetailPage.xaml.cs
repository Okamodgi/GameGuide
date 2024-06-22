using GameGuide.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace GameGuide.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}