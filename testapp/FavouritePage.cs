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
    [Activity(Label = "FavouritePage", Theme = "@style/AppTheme.NoActionBar")]
    public class FavouritePage : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.favourite);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar4);
            SetSupportActionBar(toolbar);
            RatingBar ratingbar = FindViewById<RatingBar>(Resource.Id.ratingbar);
            ratingbar.RatingBarChange += Ratingbar_RatingBarChange;
            
          
            toolbar.NavigationClick += navigateback;
        }

        private void Ratingbar_RatingBarChange(object sender, RatingBar.RatingBarChangeEventArgs e)
        {
            Toast.MakeText(this, "Your Rating: " + e.Rating.ToString(), ToastLength.Short).Show();
        }

        private void navigateback(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
    }
}