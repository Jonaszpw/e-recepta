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

namespace PatientApplication2.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.Net.Http;
  
  public class Patient2Client : IPatient2
  {
    private readonly ServiceClient serviceClient;

    public Patient2Client( string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort > 0 );

      this.serviceClient = new ServiceClient( serviceHost, servicePort );
    }

    public PrescriptionData[ ] GetPrescriptions( string searchText )
    {
      string callUri = $"PatientAppService/GetPrescriptions?searchText={searchText}";
          
      PrescriptionData[ ] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>( HttpMethod.Get, callUri );

      return prescriptions;
    }

        public DrugData[] GetDrugs(string searchText)
        {
            string callUri = $"PatientAppService/GetDrugs?searchText={searchText}";

            DrugData[] drugs = this.serviceClient.CallWebService<DrugData[]>(HttpMethod.Get, callUri);

            return drugs;
        }

    }
}
