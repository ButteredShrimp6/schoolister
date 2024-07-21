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
    [Activity(Label = "TaskActivity")]
    public class TaskActivity : Activity
    {
        Button btnHome, btnUpdate, btnDelete;
        EditText editCourse, editTask, editDate, editTime;
        HttpWebResponse response;
        HttpWebRequest request;
        String res, courseCode, courseTask, courseDate, courseTime;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.tasklayout);

            btnHome = FindViewById<Button>(Resource.Id.button1);
            
            btnUpdate = FindViewById<Button>(Resource.Id.button2);
            btnDelete = FindViewById<Button>(Resource.Id.button3);

            editCourse = FindViewById<EditText>(Resource.Id.editText1);
            editTask = FindViewById<EditText>(Resource.Id.editText2);
            editDate = FindViewById<EditText>(Resource.Id.editText3);
            editTime = FindViewById<EditText>(Resource.Id.editText4);

            editCourse.Text = Intent.GetStringExtra("Course");
            editTask.Text = Intent.GetStringExtra("Task");
            editDate.Text = Intent.GetStringExtra("Date");
            editTime.Text = Intent.GetStringExtra("Time");

            btnHome.Click += Home;
            btnUpdate.Click += UpdateTask;
            btnDelete.Click += DeleteTask;
        }
        public void Home(object sender, EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }

        protected void UpdateTask(object sender, EventArgs e)
        {
            UpdateClass update = new UpdateClass();

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

                    update.updateTask(courseCode, courseTask, d, t);

                    alert.SetTitle("NOTICE");
                    alert.SetMessage("Task Updated Successfully.");
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
                alert.SetMessage("Please Enter Record To Delete.");
                alert.SetPositiveButton("OK", delegate
                {
                    alert.Dispose();
                });
                alert.Show();
            }
        }
        protected void DeleteTask(object sender, EventArgs e)
        {
            DeleteClass delete = new DeleteClass();

            AlertDialog.Builder alert = new AlertDialog.Builder(this);

            courseCode = editCourse.Text;
            courseTask = editTask.Text;
            courseDate = editDate.Text;
            courseTime = editTime.Text;

            if (courseCode != "" && courseTask != "" && courseDate != "" && courseTime != "")
            {
                delete.deleteTask(courseCode, courseTask);

                if (delete.Res.Contains("Deleted"))
                {
                    alert.SetTitle("NOTICE");
                    alert.SetMessage("Task Deleted Successfully.");
                    alert.SetPositiveButton("OK", delegate
                    {
                        Intent i = new Intent(this, typeof(MainActivity));
                        StartActivity(i);
                    });
                    alert.Show();
                }

                else if (delete.Res.Contains("No Data"))
                {
                    alert.SetTitle("NOTICE");
                    alert.SetMessage("No Task Found.");
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
                alert.SetMessage("Please Enter Record To Delete.");
                alert.SetPositiveButton("OK", delegate
                {
                    alert.Dispose();
                });
                alert.Show();
            }
        }
    }
}