using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Widget;
using AndroidX.AppCompat.App;
using System;
using System.Net;
using System.IO;
using Android.Content;
using AlertDialog = Android.App.AlertDialog;
using System.Text.Json;
using System.Collections.Generic;

namespace Group3_IT123P_A55
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        Button btnCode, btnTask, btnAdd, btnAll;
        ListView listView;
        ImageView img;
        ViewClass viewSearch = new ViewClass();

        protected override void OnCreate(Bundle savedInstanceState)
        {
            try
            {
                base.OnCreate(savedInstanceState);
                Xamarin.Essentials.Platform.Init(this, savedInstanceState);
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.activity_main);

                btnCode = FindViewById<Button>(Resource.Id.button1);
                btnTask = FindViewById<Button>(Resource.Id.button2);
                btnAdd = FindViewById<Button>(Resource.Id.button3);
                btnAll = FindViewById<Button>(Resource.Id.button4);
                img = FindViewById<ImageView>(Resource.Id.imageView1);
                img.SetImageResource(Resource.Drawable.SCHOOLISTER);

                listView = FindViewById<ListView>(Resource.Id.listView1);

                viewSearch.viewTask();
                btnCode.Click += viewCourse;
                btnTask.Click += viewTask;
                btnAdd.Click += AddRecord;
                btnAll.Click += viewAll;

                ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, viewSearch.Items);
                listView.Adapter = adapter;

                listView.ItemClick += delegate (object sender, AdapterView.ItemClickEventArgs e)
                {
                    var item = adapter.GetItem(e.Position);
                    Option(item.ToString());
                };

            }
            catch
            {
                string[] nodata = new string[] { "" };
                ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, nodata);
                listView.Adapter = adapter;
            }
        }

        public void viewCourse(object sender, EventArgs e)
        { 
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            alert.SetTitle("Search Course");
            alert.SetMessage("Enter Course Code (e.g. IT123P)");

            EditText input = new EditText(this);
            alert.SetView(input);
            alert.SetPositiveButton("SEARCH", delegate
            {
                viewSearch.viewCourse(input.Text);

                if (viewSearch.Items.Length != 0)
                {
                    ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, viewSearch.Items);
                    listView.Adapter = adapter;
                }
                else
                {
                    string[] nodata = new string[] { "" };
                    ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, nodata);
                    listView.Adapter = adapter;

                    Toast.MakeText(this, "No Data Found.", ToastLength.Long).Show();
                }
            });
            alert.SetNegativeButton("CANCEL", delegate
            {
                alert.Dispose();
            });

            alert.Show();
        }
        
        public void viewTask(object sender, EventArgs e)
        {
            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            alert.SetTitle("Search Task");
            alert.SetMessage("Enter Task (e.g. Final Course Assessment)");

            EditText input = new EditText(this);
            alert.SetView(input);
            alert.SetPositiveButton("SEARCH", delegate
            {
                viewSearch.viewTask(input.Text);

                if (viewSearch.Items.Length != 0)
                {
                    ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, viewSearch.Items);
                    listView.Adapter = adapter;
                }
                else
                {
                    string[] nodata = new string[] { "" };
                    ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, nodata);
                    listView.Adapter = adapter;

                    Toast.MakeText(this, "No Data Found.", ToastLength.Long).Show();
                }
            });
            alert.SetNegativeButton("CANCEL", delegate
            {
                alert.Dispose();
            });

            alert.Show();
        }

        public void viewAll(object sender, EventArgs e)
        {
            ViewClass viewSearch = new ViewClass();
            viewSearch.viewTask();

            if (viewSearch.Items.Length != 0)
            {
                ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, viewSearch.Items);
                listView.Adapter = adapter;
            }
            else
            {
                string[] nodata = new string[] { "" };
                ArrayAdapter adapter = new ArrayAdapter(this, Resource.Layout.listlayout, nodata);
                listView.Adapter = adapter;
            }
        }

        public void AddRecord(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(Add));
            StartActivity(i);
        }

        public void Option(string item)
        {
            string[] data = item.Split("|");
            Intent i = new Intent(this, typeof(TaskActivity));
            Bundle bundle = new Bundle();
            bundle.PutString("Course", data[0]);
            bundle.PutString("Task", data[1]);
            bundle.PutString("Date", data[2]);
            bundle.PutString("Time", data[3]);
            i.PutExtras(bundle);
            StartActivityForResult(i, 1);
        }

        public void onActivityResult(int requestCode, Result resultCode, Intent i)
        {
            base.OnActivityResult(requestCode, resultCode, i);
            if (resultCode == Result.Ok)
            {
                return;
            }
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}