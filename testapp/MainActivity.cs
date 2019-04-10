using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Renderscripts;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;


namespace testapp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
       RenderScript renderScript;
        ImageView backGroundImage;
        
        public DateTime mytime { get; set; }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);
            var TimetextView = FindViewById<TextView>(Resource.Id.time);
             TimeZone zone = TimeZone.CurrentTimeZone;
            mytime = zone.ToLocalTime(DateTime.Now);
            renderScript = RenderScript.Create(this);
            TimetextView.Text= mytime.ToShortTimeString();
            backGroundImage = FindViewById<ImageView>(Resource.Id.background_image);
            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.btn_search);
            fab.Click += FabOnClick;
            FloatingActionButton profile = FindViewById<FloatingActionButton>(Resource.Id.btn_user);
            profile.Click += profile_click;
            FloatingActionButton favourite = FindViewById<FloatingActionButton>(Resource.Id.btn_fav);
            favourite.Click += Favourite_Click; 
            var blurbutton = FindViewById<Button>(Resource.Id.btn_send);
            blurbutton.Click += blurimage;
            FloatingActionButton close = FindViewById<FloatingActionButton>(Resource.Id.btn_close);
            close.Click += Close_Click;
            FloatingActionButton home = FindViewById<FloatingActionButton>(Resource.Id.btn_home);
            home.Click += Close_Click;
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Bitmap originalBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.imagebackground);
            backGroundImage.SetImageBitmap(originalBitmap);
        }

        private void Favourite_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FavouritePage));
            StartActivity(intent);
        }

        private void profile_click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(ProfilePage));
            StartActivity(intent);
        }

        private void blurimage(object sender, EventArgs e)
        {
             DisplayBlurredImage(24);
           // blur(this.conte);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            var intent = new Intent(this, typeof(SearchActivity));
            StartActivity(intent);
        }
        Bitmap CreateBlurredImage(int radius)
        {
          


            Bitmap originalBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.imagebackground);
            Bitmap blurredBitmap = Bitmap.CreateBitmap(originalBitmap);
            ScriptIntrinsicBlur script = ScriptIntrinsicBlur.Create(renderScript, Element.U8_4(renderScript));
            Allocation input = Allocation.CreateFromBitmap(renderScript, originalBitmap, Allocation.MipmapControl.MipmapFull, AllocationUsage.Script);
            script.SetInput(input);
            script.SetRadius(radius);
            Allocation output = Allocation.CreateTyped(renderScript, input.Type);
            script.ForEach(output);
            output.CopyTo(blurredBitmap);
            output.Destroy();
            input.Destroy();
            script.Destroy();
            return blurredBitmap;
        }
      
        void DisplayBlurredImage(int radius)
        {
                Bitmap bmp = CreateBlurredImage(radius);
            backGroundImage.SetImageBitmap(bmp);
        }
    }
}

