using AlertToCareUI.Models;
using AlertToCareUI.ServiceAccessPoint;
using System;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;


namespace AlertToCareUI.Views
{
    /// <summary>
    /// Interaction logic for AdmissionAndDischarge.xaml
    /// </summary>
    public partial class AdmissionAndDischarge : UserControl
    {
        public AdmissionAndDischarge()
        {
            InitializeComponent();
        }
        static string _icuNo;
        public AdmissionAndDischarge(string icuid)
        {
            _icuNo = icuid;
        }
       // RequestHandler requestHandlerObj = new RequestHandler();
        //await requestHandlerObj.DeleteAlertsOnDischarge(idDischarged);
        private void Admit(object sender, RoutedEventArgs e)
        {
            PatientAdmission();

        }



        private void PatientAdmission()
        {


            var newPatient = new PatientModel()
            {
                Id = Id.Text,
                PatientName = Name.Text,
                //Age = int.Parse(age.Text),
                BedId = Bedno.Text,
                //IcuId = icuid.Text,
                IcuId = _icuNo,
                ContantNumber = Contact.Text
            };

            bool response = CheckValidityOfDetails(newPatient);
            if (response)
            {

                newPatient.Age = int.Parse(Age.Text);
                AddToDb(newPatient);

            }
            else
            {
                MessageBox.Show("Please Enter All Valid Details");
            }

        }

        private void AddToDb(PatientModel newPatient)
        {

            System.Net.HttpWebRequest httpReq =
                 System.Net.WebRequest.CreateHttp("http://localhost:5000/api/icuoccupancy");
            httpReq.Method = "POST";
            httpReq.ContentType = "application/json";
            DataContractJsonSerializer filterDataJsonSerializer = new DataContractJsonSerializer(typeof(PatientModel));
            filterDataJsonSerializer.WriteObject(httpReq.GetRequestStream(), newPatient);
            try
            {
                System.Net.HttpWebResponse response = httpReq.GetResponse() as System.Net.HttpWebResponse;
                // MessageBox.Show($"{response.StatusCode}");
                MessageBox.Show("Patient Registered Successfully");
                Id.Text = "";
                Name.Text = "";
                Age.Text = "";
                Bedno.Text = "";
                //IcuId = icuid.Text,
                Contact.Text = "";


            }
            catch (Exception)
            {
                //MessageBox.Show($"{ exception.Message}");
                MessageBox.Show("Please Ensure Correct Deatils of Patient ID And BedNo");
            }
        }

        private bool CheckValidityOfDetails(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.Id) || String.IsNullOrEmpty(newPatient.PatientName))
            {
                return false;
            }
            return CheckBedIdAndIcuId(newPatient);
        }

        private bool CheckBedIdAndIcuId(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.BedId) || String.IsNullOrEmpty(newPatient.IcuId))
            {
                return false;
            }
            return CheckContactNo(newPatient);
        }

        private bool CheckContactNo(PatientModel newPatient)
        {
            if (String.IsNullOrEmpty(newPatient.ContantNumber) || newPatient.ContantNumber.Length != 10)
            {
                return false;
            }
            return CheckAge();
        }

        private bool CheckAge()
        {
            try
            {
                int.Parse(Age.Text);
                return true;
            }
            catch (Exception)
            {
                return false;
            }


        }

        private async void Discharge(object sender, RoutedEventArgs e)
        {
           await Dischargepatient();
        }

        private  async Task Dischargepatient()
        {
            if (CheckId(Patientid.Text))
            {
             await RemovePatient(Patientid.Text);
            }
            else
            {
                MessageBox.Show("Please Enter Patient Id To Be discharged");
            }
        }

        private async Task RemovePatient(string idDischarged)
        {
            string icuId = _icuNo;
            System.Net.HttpWebRequest _httpReq =
                System.Net.WebRequest.CreateHttp("http://localhost:5000/api/icuoccupancy/" + idDischarged + "/" + icuId);
            _httpReq.Method = "DELETE";

            try
            {
                System.Net.HttpWebResponse response = _httpReq.GetResponse() as System.Net.HttpWebResponse;
                //MessageBox.Show($"{response.StatusCode}");
                MessageBox.Show("Patient Discharged Successfully");
                Patientid.Text = "";
                RequestHandler requestHandlerObj = new RequestHandler();
                await requestHandlerObj.DeleteAlertsOnDischarge(idDischarged);


            }
            catch (Exception)
            {
                //MessageBox.Show($"{exception.Message}");
                MessageBox.Show("InValid Patient Id Entered");
                Patientid.Text = "";
            }
        }

        private bool CheckId(string text)
        {
            if (String.IsNullOrEmpty(text))
            {
                return false;
            }
            return true;

        }
    }
}
