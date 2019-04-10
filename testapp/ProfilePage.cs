using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace testapp
{
    [Activity(Label = "ProfilePage", Theme = "@style/AppTheme.NoActionBar")]
    public class ProfilePage : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.profilepage);
            Android.Support.V7.Widget.Toolbar toolbar2 = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar3);
            SetSupportActionBar(toolbar2);
            toolbar2.NavigationClick += navigateback;
        }

        private void navigateback(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }

}
