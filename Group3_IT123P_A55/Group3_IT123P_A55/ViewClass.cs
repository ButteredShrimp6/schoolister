using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Net;
using System.IO;
using System.Text.Json;
using System.Globalization;

namespace Group3_IT123P_A55
{
    public class ViewClass
    {
        HttpWebResponse response;
        HttpWebRequest request;
        private string[] items;
        String res;

        public string[] Items
        {
            get
            {
                return items;
            }
            private set
            {
                items = value;
            }
        }
        public void viewCourse(string input)
        {
            request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT123P/REST/search_code.php?" + "&courseCode=" + input);
            request.Timeout = 500;
            response = (HttpWebResponse)request.GetResponse();
            res = response.ProtocolVersion.ToString();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            List<string> itemList = new List<string>();
            var u1 = root.EnumerateArray();

            while (u1.MoveNext())
            {
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                var u2 = u1.Current;

                string course = u2.GetProperty("courseCode").ToString();
                string task = u2.GetProperty("courseTask").ToString();

                string getdate = u2.GetProperty("courseDeadline").ToString();
                string[] d = getdate.Split("-");
                string year = d[0];
                string month = dtfi.GetMonthName(Int32.Parse(d[1]));
                string day = d[2];
                string date = $"{month} {day}, {year}";

                string gettime = u2.GetProperty("courseTime").ToString();
                string[] t = gettime.Split(":");
                string time = $"{t[0]}:{t[1]}";

                string finalItem = $"{course}|{task}|{date}|{time}";

                itemList.Add(finalItem);
            }

            Items = itemList.ToArray();
        }

        public void viewTask(string input)
        {

            request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT123P/REST/search_task.php?" + "&courseTask=" + input);
            request.Timeout = 500;
            response = (HttpWebResponse)request.GetResponse();
            res = response.ProtocolVersion.ToString();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            var result = reader.ReadToEnd();
            using JsonDocument doc = JsonDocument.Parse(result);
            JsonElement root = doc.RootElement;

            List<string> itemList = new List<string>();
            var u1 = root.EnumerateArray();

            while (u1.MoveNext())
            {
                DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                var u2 = u1.Current;

                string course = u2.GetProperty("courseCode").ToString();
                string task = u2.GetProperty("courseTask").ToString();

                string getdate = u2.GetProperty("courseDeadline").ToString();
                string[] d = getdate.Split("-");
                string year = d[0];
                string month = dtfi.GetMonthName(Int32.Parse(d[1]));
                string day = d[2];
                string date = $"{month} {day}, {year}";

                string gettime = u2.GetProperty("courseTime").ToString();
                string[] t = gettime.Split(":");
                string time = $"{t[0]}:{t[1]}";

                string finalItem = $"{course}|{task}|{date}|{time}";

                itemList.Add(finalItem);
            }

            Items = itemList.ToArray();
        }
        public void viewTask()
        {
            try
            {
                request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT123P/REST/get_courseCodes.php?");
                request.Timeout = 1000;
                response = (HttpWebResponse)request.GetResponse();
                res = response.ProtocolVersion.ToString();
                StreamReader reader = new StreamReader(response.GetResponseStream());
                var result = reader.ReadToEnd();
                using JsonDocument doc = JsonDocument.Parse(result);
                JsonElement root = doc.RootElement;

                List<string> itemList = new List<string>();
                var u1 = root.EnumerateArray();

                while (u1.MoveNext())
                {
                    DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
                    var u2 = u1.Current;

                    string course = u2.GetProperty("courseCode").ToString();
                    string task = u2.GetProperty("courseTask").ToString();

                    string getdate = u2.GetProperty("courseDeadline").ToString();
                    string[] d = getdate.Split("-");
                    string year = d[0];
                    string month = dtfi.GetMonthName(Int32.Parse(d[1]));
                    string day = d[2];
                    string date = $"{month} {day}, {year}";

                    string gettime = u2.GetProperty("courseTime").ToString();
                    string[] t = gettime.Split(":");
                    string time = $"{t[0]}:{t[1]}";

                    string finalItem = $"{course}|{task}|{date}|{time}";

                    itemList.Add(finalItem);
                }

                Items = itemList.ToArray();
            }
            catch
            {
                
            }
        }
    }
}