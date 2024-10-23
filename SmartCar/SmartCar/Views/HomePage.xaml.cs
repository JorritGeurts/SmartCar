using SmartCar.viewModels;

namespace SmartCar.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IHomeViewModel viewModel)
	{
        InitializeComponent();

		BindingContext = viewModel;
	}
}