namespace PrescriptionsService
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;

    public class PrescriptionReader
    {
        public string file { get; set; }
        public Prescription[] prescriptions;


        public PrescriptionReader() { }
        public PrescriptionReader(string f)
        {
            file = f;
        } 

        public Prescription[] ReadAll()
        {
            try
            {
                PrescriptionData[] prescriptionsData = JsonSerializer.Deserialize<PrescriptionData[]>(File.ReadAllText(file));
                prescriptions = prescriptionsData.Select(prescriptionData => new Prescription(prescriptionData.Id, prescriptionData.DoctorDetails, prescriptionData.PatientDetails, prescriptionData.Date, prescriptionData.IsCollected, prescriptionData.MedicinesIds)).ToArray();
        
                return prescriptions;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
         
            return null;
        }

      public bool UpdateOne(string id, bool flag)
        {
            try
            {
                PrescriptionData[] prescriptionsData = JsonSerializer.Deserialize<PrescriptionData[]>(File.ReadAllText(file));
                prescriptions = prescriptionsData.Select(prescriptionData => new Prescription(prescriptionData.Id, prescriptionData.DoctorDetails, prescriptionData.PatientDetails, prescriptionData.Date, prescriptionData.IsCollected, prescriptionData.MedicinesIds)).ToArray();
                int i = Array.IndexOf(prescriptions, Array.Find(prescriptions, element => element.Id == id));
                if (i == -1)
                    return false;
                else
                {
                    prescriptions[i].IsCollected = flag;
                    string json = JsonSerializer.Serialize(prescriptions);
                    File.WriteAllText(file, json);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;

            }
        }
        public bool AddOne(string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds)
        {

            Console.WriteLine("post");
            Console.WriteLine(id + doctorDetails + patientDetails + date + medicineIds);

            if(id == null || doctorDetails == null || patientDetails == null || date == null || medicineIds == null)
            {
                return false;
            }
            try
            {
               
                //prescriptionjson =prescriptionjson.Replace("\\", "");
               // prescriptionjson.Substring(1, prescriptionjson.Length - 2);
                Prescription prescription = new Prescription(id, doctorDetails, patientDetails, date, isCollected, medicineIds);
                PrescriptionData[] prescriptionsData = JsonSerializer.Deserialize<PrescriptionData[]>(File.ReadAllText(file));
                prescriptions = prescriptionsData.Select(prescriptionData => new Prescription(prescriptionData.Id, prescriptionData.DoctorDetails, prescriptionData.PatientDetails, prescriptionData.Date, prescriptionData.IsCollected, prescriptionData.MedicinesIds)).ToArray();
                Prescription[] newprescriptions = new Prescription[prescriptions.Length+1];
                Console.WriteLine(prescription);
                for (int j = 0; j < prescriptions.Length; j++)
                {
                    newprescriptions[j] = prescriptions[j];
                    if (prescriptions[j].Id == id) return false;
                }
                newprescriptions[prescriptions.Length] = prescription;
                string json = JsonSerializer.Serialize(newprescriptions);
                File.WriteAllText(file, json);
                return true;
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return false;

            }
        }
    }
}
