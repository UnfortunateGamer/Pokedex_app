using Pokedex_app.Services;

namespace Pokedex_app;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
		DatabaseService.Init();
	}
}
