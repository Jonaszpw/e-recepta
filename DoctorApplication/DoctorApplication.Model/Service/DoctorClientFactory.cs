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

  public static class DoctorClientFactory
  {
    public static IDoctor GetDoctorClient( )
    {
      
      const string serviceHost = "localhost";
      const int servicePort = 5008;

      return new DoctorClient( serviceHost, servicePort );
      //return new FakeNetworkClient( );

    }
  }
}
