﻿using AlertToCareUI.Models;
using Newtonsoft.Json;

using System.IO;

using System.Net;

using System.Windows;
using System.Windows.Controls;


namespace AlertToCareUI.Views
{
    /// <summary>
    /// Interaction logic for LLayout_12.xaml
    /// </summary>
    public partial class LLayout_12 : UserControl
    {
        public LLayout_12()
        {
            InitializeComponent();
        }
        static string _icuNo;
        public LLayout_12(string icuId)
        {
            _icuNo = icuId;
        }

        private void PatientInfo(object sender, RoutedEventArgs e)
        {
            string b = (string)((Button)sender).Content;
            string icu = _icuNo;

            HttpWebRequest httpReq = WebRequest.CreateHttp("http://localhost:5000/api/IcuOccupancy/Patient/" + b + "/" + icu);
            httpReq.Method = "GET";
            HttpWebResponse response = httpReq.GetResponse() as HttpWebResponse;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                var stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream);
                var result = reader.ReadToEnd();
                var patient = JsonConvert.DeserializeObject<PatientModel>(result);
                MessageBox.Show($"Occupied By PatientNo {patient.Id}");
            }
            else
            {
                MessageBox.Show("Bed Un Occupied");
            }
        }
    }
}
