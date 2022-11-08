namespace PatientAppService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;
    public class ServerConn
    {
        public ServerConn()
        {
        }
        public async Task<Prescription[]> GetPrescriptions(string webServiceHost, ushort webServicePort)
        {
            string webServiceUri = String.Format("https://{0}:{1}/PrescriptionsService/GetPrescriptions", webServiceHost, webServicePort);

            string jsonResponseContent = await CallWebService(webServiceUri, "GET");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            PrescriptionData[] prescriptionsData = JsonSerializer.Deserialize<PrescriptionData[]>(jsonResponseContent, options);

            Prescription[] prescriptions = prescriptionsData.Select(prescriptionData => new Prescription(prescriptionData.Id, prescriptionData.DoctorDetails, prescriptionData.PatientDetails, prescriptionData.Date, prescriptionData.IsCollected, prescriptionData.MedicinesIds)).ToArray();


            return prescriptions;
        }

        public async Task<bool> SetCollected(string webServiceHost, ushort webServicePort, string id, bool flag)
        {
            string webServiceUri = String.Format("https://{0}:{1}/PrescriptionsService/SetCollected?id={2}&flag={3}", webServiceHost, webServicePort, id, flag);

            string jsonResponseContent = await CallWebService(webServiceUri, "POST");

            bool responseFLag = JsonSerializer.Deserialize<bool>(jsonResponseContent);

            return responseFLag;
        }
        public async Task<bool> buyDrugs(string webServiceHost, ushort webServicePort, string id, int number)
        {
            string webServiceUri = String.Format("https://{0}:{1}/DrugsService/buyDrugs?id={2}&ilosc={3}", webServiceHost, webServicePort, id, number);

            Console.WriteLine(webServiceUri);

            string jsonResponseContent = await CallWebService(webServiceUri, "POST");

            bool ans = JsonSerializer.Deserialize<bool>(jsonResponseContent);

            return ans;
        }

        public async Task<Drug[]> GetDrugs(string webServiceHost, ushort webServicePort, string searchText)
        {
            string webServiceUri = String.Format("https://{0}:{1}/DrugsService/GetDrugs?searchText={2}", webServiceHost, webServicePort, searchText);

            string jsonResponseContent = await CallWebService(webServiceUri, "GET");

            Drug[] drugs = ConvertJson(jsonResponseContent);

            return drugs;
        }

        public static async Task<string> CallWebService(string webServiceUri, string httpmethod)
        {
            HttpClient httpClient = new HttpClient();

            HttpRequestMessage httpRequestMessage = null;
            if (httpmethod == "GET")
            {
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, webServiceUri);
            }
            else if (httpmethod == "POST")
            {
                httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, webServiceUri);
            }

            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            HttpResponseMessage httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            httpClient.Dispose();


            httpResponseMessage.EnsureSuccessStatusCode();

            string httpResponseContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return httpResponseContent;
        }

        public static Drug[] ConvertJson(string json)
        {
            if(json == null)
            {
                json = "[]";
            }
            DrugData[] drugsData = JsonSerializer.Deserialize<DrugData[]>(json);

            Drug[] drugs = drugsData.Select(drug => new Drug(drug.id, drug.name, drug.quantity, drug.description, drug.price, drug.numberOfPills)).ToArray();

            return drugs;
        }
    }
}
