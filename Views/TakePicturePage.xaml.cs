using FeaturesDemo.ViewModels;

namespace FeaturesDemo.Views;

public partial class TakePicturePage : ContentPage
{
	public TakePicturePage(TakePicturePageViewModel vm)
	{
		BindingContext=vm;
		InitializeComponent();
	}
}