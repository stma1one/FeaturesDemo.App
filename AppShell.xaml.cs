using FeaturesDemo.Views;

namespace FeaturesDemo;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute("networkpage", typeof(NetworkPage));
        Routing.RegisterRoute("sendsmspage", typeof(SendSmsPage));
		Routing.RegisterRoute("takepicture",typeof(TakePicturePage));	
    }
}
