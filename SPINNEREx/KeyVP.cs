using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SPINNEREx
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme")]
    class KeyVP : AppCompatActivity
    {
        private Spinner mySpinner;
        private List<KeyValuePair<String, String>> friends;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.keypairL);


            mySpinner = FindViewById<Spinner>(Resource.Id.spinner1);
        

            friends = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("Ross","29 Years"),
                new KeyValuePair<string, string>("Rachel","25 Years"),
                new KeyValuePair<string, string>("Chandler", "25 Years"),
                new KeyValuePair<string, string>("Monica", "20 Years"),
                new KeyValuePair<string, string>("Joey", "29 Years"),
                new KeyValuePair<string, string>("Pheobe", "30 Years"),
         

            };

            List<string> friendage = new List<string>();
            foreach (var item in friends)
                friendage.Add(item.Key);

            ArrayAdapter adapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleSpinnerItem, friendage);

            mySpinner.Adapter = adapter;

            mySpinner.ItemSelected += new EventHandler<AdapterView.ItemSelectedEventArgs>(spinner_ItemSelected);




        }

        private void spinner_ItemSelected(object sender, AdapterView.ItemSelectedEventArgs e)
        {
            mySpinner = (Spinner)sender;
            string t = string.Format("Hey {0} age is {1} ",mySpinner.GetItemAtPosition(e.Position),friends[e.Position].Value);
            Toast.MakeText(Application.Context,t,ToastLength.Short).Show();

        }
    }
}