using FeaturesDemo.ViewModels;

namespace FeaturesDemo.Views;

public partial class MainMenuPage : ContentPage
{
	public MainMenuPage(MainMenuPageViewModel vm)
	{
		BindingContext = vm;
		InitializeComponent();
	}
}