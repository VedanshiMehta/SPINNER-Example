using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;

namespace SPINNEREx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        public Spinner mySpinner;
       // private TextView myTextView;
        private ArrayAdapter myadpater;
        private Button myButton;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            mySpinner = FindViewById<Spinner>(Resource.Id.spinner);
            mySpinner.ItemSelected += new System.EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_itemSelected);
            myButton = FindViewById<Button>(Resource.Id.button1);
            myButton.Click += MyButton_Click;
            myadpater = ArrayAdapter.CreateFromResource(this, Resource.Array.sixfriend, Android.Resource.Layout.SimpleSpinnerDropDownItem);
            myadpater.SetDropDownViewResource(Android.Resource.Layout.SimpleSpinnerDropDownItem);
            mySpinner.Adapter = myadpater;
            
        }

        private void MyButton_Click(object sender, EventArgs e)
        {
            Intent i = new Intent(Application.Context, typeof(KeyVP));
            StartActivity(i);
        }

        private void spinner_itemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            mySpinner = (Spinner)sender;
            //string t = string.Format("Hey {0}", mySpinner.GetItemAtPosition(e.Position));
           // Toast.MakeText(this, t, ToastLength.Short).Show();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}