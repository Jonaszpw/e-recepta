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

  public static class PatientClientFactory
  {
    public static IPatient GetPatientClient( )
    {
#if DEBUG
      
      const string serviceHost = "localhost";
      const int servicePort = 5006;

      return new PatientClient( serviceHost, servicePort );
      //return new FakeNetworkClient( );

#else
      /* AT
      const string serviceHost = "localhost";
      const int servicePort = 44328;

      const string serviceHost = "app_webservicerest";
      const int servicePort = 80;

      return new NetworkClient( serviceHost, servicePort );
      */
      return new FakeNetworkClient( );

#endif
    }
  }
}
