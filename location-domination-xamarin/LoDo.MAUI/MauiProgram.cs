using CommunityToolkit.Maui;
using LoDo.MAUI.ViewModels;
using LoDo.MAUI.ViewModels.BottomViewsViewModels;
using LoDo.MAUI.ViewModels.PopupViewModels;
using LoDo.MAUI.Views.Pages;
using Maui.TouchEffect.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif
using Mopups.Hosting;
using Mopups.Interfaces;
using Mopups.Services;
using Sharpnado.Tabs;
using System.Reflection;
using epj.Expander.Maui;
using Firebase.Auth;
using Firebase.Auth.Providers;
using IeuanWalker.Maui.Switch;
using LoDo.MAUI.Properties;
using LoDo.MAUI.Services.Implementations;
using LoDo.MAUI.Services.Interfaces;
using LoDo.MAUI.Views.Popups;
using Maui.FreakyEffects;
using Maui.PancakeView;
using PanCardView;
using Refit;
using Sharpnado.MaterialFrame;
using The49.Maui.BottomSheet;
using UraniumUI;

namespace LoDo.MAUI
{
    public static class MauiProgram
    {
        static public MauiContext Context { get; private set; }
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UsePancakeViewCompat()
                .UseMauiCommunityToolkit()
                .ConfigureMopups()
                .UseExpander()
                .UseMauiTouchEffect()
                .UseMauiMaps()
                .UseUraniumUI()
                .UseUraniumUIBlurs()
                .UseCardsView()
                .UseSwitch()
                .UseBottomSheet()
                .UseUraniumUIMaterial()
                .UseSharpnadoTabs(loggerEnable: true)
                .UseSharpnadoMaterialFrame(loggerEnable: true)
                .ConfigureEffects(effects =>
                {
                    effects.InitFreakyEffects();
                })
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("Raleway-Regular.ttf", "RalewayRegular");         
                    fonts.AddMaterialIconFonts();
                }).ConfigureMauiHandlers(handlers =>
                {
#if ANDROID
                    handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, LoDo.MAUI.Renders.Handlers.CustomMapHandler>();
#elif IOS
                    handlers.AddHandler<Microsoft.Maui.Controls.Maps.Map, Platforms.iOS.Handlers.Map.CustomMapHandler>();
#endif
                });
            Microsoft.Maui.Handlers.ToolbarHandler.Mapper.AppendToMapping("CustomNavigationView", (handler, view) =>
            {
#if ANDROID
                Google.Android.Material.AppBar.MaterialToolbar materialToolbar=handler.PlatformView;
 
                materialToolbar.TitleCentered = true;
#endif
            });
            Expander.EnableAnimations();
#if ANDROID
            
            Microsoft.Maui.Handlers.ButtonHandler.Mapper.AppendToMapping("ButtonTextAlignmentCentered",
                (handler, view) =>
                {
                    if (view is Button b)
                    {
#if IOS

                        handler.PlatformView.VerticalAlignment = UIControlContentVerticalAlignment.Center;
                        handler.PlatformView.HorizontalAlignment = UIControlContentHorizontalAlignment.Center;

#elif ANDROID
                        handler.PlatformView.Gravity = Android.Views.GravityFlags.Center |
                                                       Android.Views.GravityFlags.Center;
                        handler.PlatformView.SetIncludeFontPadding(false);
#endif
                    }
                });
        
             Microsoft.Maui.Handlers.LabelHandler.Mapper.AppendToMapping("NoPadding", (h, v) =>
            {
                if ((v as Label).ClassId == "LabelNullPadding")
                {
#if ANDROID
                h.PlatformView.SetIncludeFontPadding(false);
#endif
                }
            });

            Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            });
            Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("NoUnderline", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                    Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
            });
            Microsoft.Maui.Handlers.PickerHandler.Mapper.AppendToMapping("UnderlineColor", (h, v) =>
            {
                h.PlatformView.BackgroundTintList =
                Android.Content.Res.ColorStateList.ValueOf(Android.Graphics.Color.ParseColor("#002748"));
            });
#endif
#if DEBUG
            builder.Logging.AddDebug();
#endif
            RegisterSettings(builder);
            RegisterViews(builder);
            RegisterViewModels(builder);
            RegisterServices(builder);
            RegisterPopupViewModels(builder);
            var mauiapp = builder.Build();
            Context = new MauiContext(mauiapp.Services);
            return mauiapp;
        }

        private static void RegisterViews(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<AboutPage>();
            builder.Services.AddTransient<AddLocationPage>();
            builder.Services.AddScoped<SignPage>();
            builder.Services.AddScoped<LoginPage>();
            builder.Services.AddScoped<MapPage>();
            builder.Services.AddScoped<LocationsPage>();
            builder.Services.AddScoped<EventsPage>();
            builder.Services.AddScoped<LeaderBoardPage>();
            builder.Services.AddScoped<ProfilePage>();
            builder.Services.AddScoped<AboutPage>();
            builder.Services.AddScoped<SettingsPage>();
            builder.Services.AddScoped<MyGamesPage>();
            builder.Services.AddScoped<StatsPage>();
            builder.Services.AddScoped<EditProfilePage>();
            builder.Services.AddScoped<SponsorshipPage>();            
            
            builder.Services.AddScoped<NotificationBoardPopup>();
            builder.Services.AddTransient<DeleteAccountPopup>();
            builder.Services.AddTransient<LogoutPopup>();
            builder.Services.AddTransient<ChangePassPopup>();
        }

        private static void RegisterViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<AboutPageViewModel>();
            builder.Services.AddScoped<AddLocationPageViewModel>();
            builder.Services.AddScoped<MapPageViewModel>();
            builder.Services.AddScoped<LocationPageViewModel>();
            builder.Services.AddScoped<EventsPageViewModel>();
            builder.Services.AddScoped<LeaderBoardPageViewModel>();
            builder.Services.AddScoped<ProfilePageViewModel>();
            builder.Services.AddScoped<AboutPageViewModel>();
            builder.Services.AddScoped<SettingsPageViewModel>();
            builder.Services.AddScoped<MyGamesPageViewModel>();
            builder.Services.AddScoped<StatsPageViewModel>();
            builder.Services.AddScoped<SingPageViewModel>();
            builder.Services.AddScoped<EditProfilePageViewModel>();
            builder.Services.AddScoped<SponsorshipPageViewModel>();
            builder.Services.AddScoped<LoginPageViewModel>();
        }

        private static void RegisterBottomViewsViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<MapBottomIViewViewModel>();
        }

        private static void RegisterPopupViewModels(MauiAppBuilder builder)
        {
            builder.Services.AddScoped<DeleteAccountPopupViewModel>();
            builder.Services.AddScoped<FastChangePassPopupViewModel>();
            builder.Services.AddScoped<GamesFilterPopupViewModel>();
            builder.Services.AddScoped<NotificationBoardPopupViewModel>();

        }

        private static void RegisterServices(MauiAppBuilder builder)
        {
            // builder.Services.AddTransient<ILocale, LocaleService>();
            var settings = builder.Configuration.GetSection("FirebaseSettings").Get<FirebaseConfig>();
            builder.Services.AddSingleton(new FirebaseAuthClient(new FirebaseAuthConfig
            {
                ApiKey = settings.apiKey,
                AuthDomain = settings.apiDomain,
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
               {
                new EmailProvider()
               }
            }));
            builder.Services.AddSingleton<IPopupNavigation>(MopupService.Instance);
            builder.Services.AddSingleton<ISettings,LodoSettings>();
            builder.Services.AddRefitClient<ILoDoApi>().ConfigureHttpClient(c =>
            {
                c.BaseAddress = new Uri("http://app.ldomination.com:8081/api");
            });
            builder.Services.AddSingleton<CacheService>();
            builder.Services.AddSingleton<ApiService>();
        }

        private static void RegisterSettings(MauiAppBuilder builder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("LoDo.MAUI.appsettings.json");

            var config = new ConfigurationBuilder()
                         .AddJsonStream(stream)
                         .Build();
            builder.Configuration.AddConfiguration(config);
        }

    }
}
