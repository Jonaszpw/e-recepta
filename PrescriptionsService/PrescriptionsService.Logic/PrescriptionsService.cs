//===============================================================================
//
// PlaZa System Platform
//
//===============================================================================
//
// Warsaw University of Technology
// Computer Networks and Services Division
// Copyright © 2020 PlaZa Creators
// All rights reserved.
//
//===============================================================================

namespace PrescriptionsService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class PrescriptionsService : IPrescriptionsService
    {
        
        private Prescription[] prescriptions;
        private PrescriptionReader pr = new PrescriptionReader("../PrescriptionsService.Model/prescriptions.json");

        public PrescriptionsService()
        {
        }
        public Prescription[ ] GetPrescriptions()
        {
            prescriptions = pr.ReadAll();
            return prescriptions;
        }

        public bool SetCollected( string id, bool flag )
        {
            prescriptions = pr.ReadAll();
            if(pr.UpdateOne(id, flag))
            return true;
            return false;
        
        }
        public bool AddPrescription(string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds)
        {
            return pr.AddOne(id, doctorDetails, patientDetails, date, isCollected, medicineIds);
        }

        public bool AddPrescription(Prescription prescription)
        {
            //PrescriptionData prescription = (PrescriptionData)prescriptionObject;
            //PrescriptionData prescription = JsonSerializer.Deserialize<PrescriptionData>((string)prescriptionObject);
            return pr.AddOne(prescription.Id, prescription.DoctorDetails, prescription.PatientDetails, prescription.Date, prescription.IsCollected, prescription.MedicinesIds);
        }

       
    }
}
