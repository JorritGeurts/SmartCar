using SmartCar.viewModels;

namespace SmartCar.Views;

public partial class InfoPage : ContentPage
{
    public InfoPage(IInfoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
       
    }
}
