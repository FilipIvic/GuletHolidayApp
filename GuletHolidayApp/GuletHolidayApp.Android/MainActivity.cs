using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PCLAppConfig;
using System.Reflection;

namespace GuletHolidayApp.Droid
{
    [Activity(Label = "GuletHolidayApp", Icon = "@mipmap/Appicon", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            global::Xamarin.Forms.FormsMaterial.Init(this, savedInstanceState);
            //Assembly assembly = typeof(App).GetTypeInfo().Assembly;
            //ConfigurationManager.Initialise(assembly.GetManifestResourceStream("GuletHolidayApp.App.config"));
            TransparentStatusBar();
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
        private void TransparentStatusBar()
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                // for covering the full screen in android..
                //Window.SetFlags(WindowManagerFlags.LayoutNoLimits, WindowManagerFlags.LayoutNoLimits);

                // clear FLAG_TRANSLUCENT_STATUS flag:
                //Window.ClearFlags(WindowManagerFlags.TranslucentStatus);

                //Window.SetStatusBarColor(Android.Graphics.Color.Rgb(112, 41, 175));
                //Window.SetStatusBarColor(Android.Graphics.Color.Black);

                Window.AddFlags(WindowManagerFlags.TranslucentNavigation);
                Window.SetBackgroundDrawableResource(Resource.Drawable.NavigationBarTransparent);
                SetStatusBarColor(Android.Graphics.Color.Black);

                //Window.AddFlags(WindowManagerFlags.LayoutNoLimits);
                //Window.AddFlags(WindowManagerFlags.LayoutInScreen);
                //Window.DecorView.SetFitsSystemWindows(true);

            }
        }
    }
}