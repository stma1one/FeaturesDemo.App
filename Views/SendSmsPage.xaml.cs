using FeaturesDemo.ViewModels;

namespace FeaturesDemo.Views;

public partial class SendSmsPage : ContentPage
{


	public SendSmsPage(SendSmsPageViewModel vm)
	{
		BindingContext=vm;
		InitializeComponent();
	}
}