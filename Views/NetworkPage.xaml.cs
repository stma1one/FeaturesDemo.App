using FeaturesDemo.ViewModels;

namespace FeaturesDemo.Views;

public partial class NetworkPage : ContentPage
{
	public NetworkPage(NetworkPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}