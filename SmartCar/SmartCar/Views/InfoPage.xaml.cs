using SmartCar.viewModels;

namespace SmartCar.Views;

public partial class InfoPage : ContentPage
{
    public InfoPage(IInfoViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
        Console.WriteLine("BindingContext ingesteld"); // Debug output
    }
}
