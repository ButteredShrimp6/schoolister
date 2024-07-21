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

namespace Group3_IT123P_A55
{
    public class UpdateClass
    {
        HttpWebResponse response;
        HttpWebRequest request;
        public void updateTask(string courseCode, string courseTask, string courseDate, string courseTime)
        {
            request = (HttpWebRequest)WebRequest.Create("http://192.168.0.110:8080/IT123P/REST/update_record.php?" + "&courseCode=" + courseCode + "&courseTask=" + courseTask + "&courseDeadline=" + courseDate + "&courseTime=" + courseTime);
            request.Timeout = 500;
            response = (HttpWebResponse)request.GetResponse();
        }
    }
}