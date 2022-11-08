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

  public static class Patient2ClientFactory
  {
    public static IPatient2 GetPatient2Client( )
    {
#if DEBUG
      
      const string serviceHost = "localhost";
      const int servicePort = 5006;

      return new Patient2Client( serviceHost, servicePort );
#endif

        }
  }
}
