using SmartCar.viewModels;

namespace SmartCar.Views;

public partial class HomePage : ContentPage
{
	public HomePage(IInfoViewModel viewModel)
	{
        InitializeComponent();

		BindingContext = viewModel;
	}
}