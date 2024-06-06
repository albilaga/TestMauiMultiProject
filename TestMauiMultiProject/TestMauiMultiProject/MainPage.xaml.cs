﻿using Microsoft.Maui.Controls.PlatformConfiguration;
using Microsoft.Maui.Controls.PlatformConfiguration.iOSSpecific;
using NavigationPage = Microsoft.Maui.Controls.NavigationPage;

namespace TestMauiMultiProject;

public partial class MainPage : ContentPage
{
    int count = 0;

    public MainPage(IRegionManager regionManager)
    {
        // On<iOS>().SetUseSafeArea(false);
        NavigationPage.SetHasNavigationBar(this, false);
        InitializeComponent();
        regionManager.RequestNavigate("TitleRegion",nameof(TitleLabel));
    }

    private void OnCounterClicked(object sender, EventArgs e)
    {
        count++;

        if (count == 1)
            CounterBtn.Text = $"Clicked {count} time";
        else
            CounterBtn.Text = $"Clicked {count} times";

        SemanticScreenReader.Announce(CounterBtn.Text);
    }
}