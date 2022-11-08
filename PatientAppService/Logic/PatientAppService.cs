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

namespace PatientAppService
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class PatientAppService : IPatientAppService
    {

            private Drug[] drugs;
            private Prescription[] prescriptions;
            private ServerConn serverConn = new ServerConn();
            private string webServiceHost = "localhost";
            private ushort webServicePortDrugs = 5002;
            private ushort webServicePortPrescriptions = 5004;

        public PatientAppService()
            {
            }
            private Prescription[] GetPrescriptionsFromServer()
            {
                Task<Prescription[]> getPrescriptionsTask = serverConn.GetPrescriptions(webServiceHost, webServicePortPrescriptions);

                getPrescriptionsTask.Wait();

                Prescription[] prescriptions = getPrescriptionsTask.Result;

                return prescriptions;
            }

            private bool SetCollectedOnServer(string id, bool flag)
            {
                Task<bool> setCollectedTask = serverConn.SetCollected(webServiceHost, webServicePortPrescriptions, id, flag);

                setCollectedTask.Wait();

                if (setCollectedTask.Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            public bool SetCollected(string id, bool flag)
            {
                if (SetCollectedOnServer(id, flag))
                 return true;
                return false;
            }
            private Drug[] GetDrugsFromServer()
            {
                string searchText = "wszystkie";

                Task<Drug[]> getDrugsTask = serverConn.GetDrugs(webServiceHost, webServicePortDrugs, searchText);

                getDrugsTask.Wait();

                Drug[] drugs = getDrugsTask.Result;
                return drugs;
            }

            private bool BuyDrugsFromServer(string id, int number)
            {
                Task<bool> buyDrugsTask = serverConn.buyDrugs(webServiceHost, webServicePortDrugs, id, number);
                buyDrugsTask.Wait();

                if (buyDrugsTask.Result)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            private bool searchInDrug(Drug drug, string phrase)
            {
                int number;
                bool isParsable = Int32.TryParse(phrase, out number);
                if (isParsable)
                {
                    bool b_id = drug.id.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                    bool b_qan = drug.quantity == int.Parse(phrase);
                    bool b_price = drug.price == int.Parse(phrase);
                    bool b_num = drug.numberOfPills == int.Parse(phrase);
                    return b_id || b_qan || b_price || b_num;
                }
                else
                {
                    bool b_id = drug.id.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                    bool b_name = drug.name.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                    bool b_description = drug.description.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                    return b_id || b_name || b_description;
                }

            }

            public Drug[] GetDrugs(string searchText)
            {
                drugs = GetDrugsFromServer();

                if (searchText == null || searchText == "" || searchText == string.Empty || searchText == "wszystkie")
                {
                    Drug[] res = new Drug[drugs.Length];
                    int i = 0;
                    foreach (Drug d in drugs)
                    {
                        res[i] = new Drug(d.id, d.name, d.quantity, d.description, d.price, d.numberOfPills);
                        i++;
                    }


                    return res;

                }
                return Array.FindAll(drugs, element => searchInDrug(element, searchText));
            }



            public bool buyDrugs(string id, int number)
            {

                drugs = GetDrugsFromServer();
                Drug drug = Array.Find(drugs, element => element.id == id);
                if (drug == null || number < 0 || drug.quantity < number) return false;
                drug.quantity -= number;

                if (BuyDrugsFromServer(id, number)) {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        private bool searchInPres(Prescription pres, string searchText)
        {

            bool b_id = pres.Id.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool b_doctor = pres.DoctorDetails.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool b_patient = pres.PatientDetails.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool b_date = pres.Date.Contains(searchText, StringComparison.OrdinalIgnoreCase);
            bool b_med = pres.MedicinesIds.Contains(searchText, StringComparison.OrdinalIgnoreCase);

            return b_id || b_doctor || b_patient || b_date || b_med;

        }
        public Prescription[] GetPrescriptions(string searchText)
        {
            prescriptions = GetPrescriptionsFromServer();
            if (searchText == null || searchText == "" || searchText == string.Empty || searchText == "wszystkie")
            {
                return prescriptions;
            }
            return Array.FindAll(prescriptions, element => searchInPres(element, searchText));
        }

  
    }
}

