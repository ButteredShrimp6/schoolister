using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Net;
using AlertDialog = Android.App.AlertDialog;

namespace Group3_IT123P_A55
{
    [Activity(Label = "LogInActivity")]
    public class Add : Activity
    {
        Button btnHome, btnAdd;
        EditText editCourse, editTask, editDate, editTime;
        String courseCode, courseTask, courseDate, courseTime;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.addlayout);

            btnHome = FindViewById<Button>(Resource.Id.button1);
            btnAdd = FindViewById<Button>(Resource.Id.button2);
            editCourse = FindViewById<EditText>(Resource.Id.editText1);
            editTask = FindViewById<EditText>(Resource.Id.editText2);
            editDate = FindViewById<EditText>(Resource.Id.editText3);
            editTime = FindViewById<EditText>(Resource.Id.editText4);
            btnHome.Click += Home;
            btnAdd.Click += addTask;
        }
        public void Home(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        protected void addTask(object sender, EventArgs e)
        {
            AddClass add = new AddClass();

            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            courseCode = editCourse.Text;
            courseTask = editTask.Text;
            courseDate = editDate.Text;
            courseTime = editTime.Text;
            if (courseCode != "" && courseTask != "" && courseDate != "" && courseTime != "")
            {
                try
                {
                    DateTime Date = DateTime.ParseExact(courseDate, "MMMM dd, yyyy", null);
                    DateTime Time = DateTime.ParseExact(courseTime, "HH:mm", null);

                    string d = Date.Date.ToString("yyyy-MM-dd");
                    string t = Time.ToString("HH:mm:ss");

                    add.addTask(courseCode, courseTask, d, t);

                    alert.SetTitle("NOTICE");
                    alert.SetMessage("Task Added Successfully.");
                    alert.SetPositiveButton("OK", delegate
                    {
                        Intent i = new Intent(this, typeof(MainActivity));
                        StartActivity(i);
                    });
                    alert.Show();
                }
                catch (FormatException)
                {
                    alert.SetTitle("NOTICE");
                    alert.SetMessage("Invalid Value.");
                    alert.SetPositiveButton("OK", delegate
                    {
                        alert.Dispose();
                    });
                    alert.Show();
                }

            }
            else
            {
                alert.SetTitle("NOTICE");
                alert.SetMessage("Please Enter A Record.");
                alert.SetPositiveButton("OK", delegate
                {
                    alert.Dispose();
                });
                alert.Show();
            }
        }
    }
}