using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using Mopups.Hosting;
using Prism.Controls;
using SkiaSharp.Views.Maui.Controls.Hosting;
using Syncfusion.Maui.Core.Hosting;

namespace TestMauiMultiProject;

public static class MauiProgramExtensions
{
    public static MauiAppBuilder UseSharedMauiApp(this MauiAppBuilder builder)
    {
        builder
            .UseMauiApp<App>()
            .UseMauiCompatibility()
            .UseMauiCommunityToolkit()
            .ConfigureSyncfusionCore()
            .ConfigureEssentials()
            .ConfigureMopups()
            .UsePrism(prismAppBuilder =>
                prismAppBuilder
                    .RegisterTypes(containerRegistry =>
                    {
                        containerRegistry.RegisterForNavigation<PrismNavigationPage>();
                        containerRegistry.RegisterForNavigation<MainPage>();
                        containerRegistry.RegisterForRegionNavigation<TitleLabel,TitleLabelViewModel>();
                    })
                    .OnInitialized(provider =>
                    {
                        var regionManager = provider.Resolve<IRegionManager>();
                        regionManager.RegisterViewWithRegion<TitleLabel>("TitleRegion");
                    })
                    .CreateWindow(navigationService =>
                        navigationService.NavigateAsync($"/{nameof(NavigationPage)}/{nameof(MainPage)}")))
            .UseSkiaSharp()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder;
    }
}