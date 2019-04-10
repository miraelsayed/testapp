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
    [Activity(Label = "SearchActivity", Theme = "@style/AppTheme.NoActionBar")]
    public class SearchActivity : AppCompatActivity
    {
        private ListView lv;
        private CustomAdapter adapter;
        private List<Spacecraft> spacecrafts;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            SetContentView(Resource.Layout.search);
            Android.Support.V7.Widget.Toolbar toolbar2 = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar2);
           SetSupportActionBar(toolbar2);
            toolbar2.NavigationClick += navigateback;
            lv = FindViewById<ListView>(Resource.Id.lv);
            //BIND ADAPTER
            adapter = new CustomAdapter(this, GetSpacecrafts());

            lv.Adapter = adapter;

            lv.ItemClick += lv_ItemClick;

        }

        private void navigateback(object sender, Android.Support.V7.Widget.Toolbar.NavigationClickEventArgs e)
        {
            var intent = new Intent(this, typeof(MainActivity));
            StartActivity(intent);
        }
        void lv_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, spacecrafts[e.Position].Name, ToastLength.Short).Show();
        }

        /*
         * DATA SOURCE 
         */
        private List<Spacecraft> GetSpacecrafts()
        {
            spacecrafts = new List<Spacecraft>();

            Spacecraft s;

            s = new Spacecraft("Enterprise", Resource.Drawable.enterprise);
            spacecrafts.Add(s);

            s = new Spacecraft("Hubble", Resource.Drawable.hubble);
            spacecrafts.Add(s);

            s = new Spacecraft("Kepler", Resource.Drawable.kepler);
            spacecrafts.Add(s);

            s = new Spacecraft("Spitzer", Resource.Drawable.spitzer);
            spacecrafts.Add(s);

            s = new Spacecraft("Rosetter", Resource.Drawable.rosetta);
            spacecrafts.Add(s);

            s = new Spacecraft("Voyager", Resource.Drawable.voyager);
            spacecrafts.Add(s);

            s = new Spacecraft("Opportunity", Resource.Drawable.opportunity);
            spacecrafts.Add(s);

            s = new Spacecraft("Pioneer", Resource.Drawable.pioneer);
            spacecrafts.Add(s);

            s = new Spacecraft("Challenger", Resource.Drawable.challenger);
            spacecrafts.Add(s);

            s = new Spacecraft("WMAP", Resource.Drawable.wmap);
            spacecrafts.Add(s);

            s = new Spacecraft("Columbia", Resource.Drawable.columbia);
            spacecrafts.Add(s);



            return spacecrafts;

        }
    }
}