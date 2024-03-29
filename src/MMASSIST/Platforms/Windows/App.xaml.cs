﻿using Microsoft.Maui.Controls.Handlers.Items;
using Microsoft.UI.Xaml;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MMASSIST.WinUI;

/// <summary>
/// Provides application-specific behavior to supplement the default Application class.
/// </summary>
public partial class App : MauiWinUIApplication
{
	/// <summary>
	/// Initializes the singleton application object.  This is the first line of authored code
	/// executed, and as such is the logical equivalent of main() or WinMain().
	/// </summary>
	public App()
	{
		this.InitializeComponent();

		// Below is code to make Headers work for CollectionView for windows. Also works for footers.

		// All credit is due to MegaEgorik https://github.com/dotnet/maui/issues/14557#issuecomment-1651575327
        CollectionViewHandler.Mapper.AppendToMapping("HeaderAndFooterFix", (_, collectionView) =>
        {
            collectionView.AddLogicalChild(collectionView.Header as Element);
            collectionView.AddLogicalChild(collectionView.Footer as Element);
        });
	}

	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}

