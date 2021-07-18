using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Unity.Lifetime;
using ImageHunt.Interfaces;
using ImageHunt.Droid.Services;
using ImageHunt.Register;

namespace ImageHunt.Droid
{
    [Activity(Label = "ImageHunt", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            Bootstrapper.RegisterPlatformDependency<IToastService, ToastService>(new SingletonLifetimeManager());
            FFImageLoading.Forms.Platform.CachedImageRenderer.Init(true);

            LoadApplication(new App());
        }
    }
}