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

namespace PatientApplication.Model
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using System.Net.Http;
  
  public class PatientClient : IPatient
  {
    private readonly ServiceClient serviceClient;

    public PatientClient( string serviceHost, int servicePort )
    {
      Debug.Assert( condition: !String.IsNullOrEmpty( serviceHost ) && servicePort > 0 );

      this.serviceClient = new ServiceClient( serviceHost, servicePort );
    }

    public PrescriptionData[ ] GetPrescriptions( string searchText )
    {
      string callUri = String.Format("PatientAppService/GetPrescriptions");

      PrescriptionData[ ] prescriptions = this.serviceClient.CallWebService<PrescriptionData[]>( HttpMethod.Get, callUri );

      return prescriptions;
    }
  }
}
