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

namespace DoctorApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.Net.Http;
  
  public class DoctorClient : IDoctor
  {
    private readonly ServiceClient serviceClient;

    public DoctorClient( string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort > 0 );

      this.serviceClient = new ServiceClient( serviceHost, servicePort );
    }

    public PrescriptionData[ ] GetPrescriptions( string searchText )
    {
      string callUri = $"DoctorAppService/GetPrescriptions?searchText={searchText}";

      PrescriptionData[ ] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>( HttpMethod.Get, callUri );

      return prescriptions;
    }

        public bool AddPrescription(PrescriptionData pres)
        {
            string callUri = $"DoctorAppService/AddPrescription?id={pres.Id}&doctorDetails={pres.DoctorDetails}&patientDetails={pres.PatientDetails}&date={pres.Date}&isCollected={pres.IsCollected}&medicineIds={pres.MedicinesIds}";

            bool res = this.serviceClient.CallWebService<bool>(HttpMethod.Post, callUri);

            return res;
        }


    public DrugData[] GetDrugs(string searchText)
    {
        string callUri = $"DoctorAppService/GetDrugs?searchText={searchText}";
            
        DrugData[] drugs = this.serviceClient.CallWebService<DrugData[]>(HttpMethod.Get, callUri);

        return drugs;
    }
    
    
  }
}
