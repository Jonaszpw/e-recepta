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

  public interface IPatientAppService
  {
    public Drug[] GetDrugs( string searchText );

    public bool buyDrugs(string id, int number); //return true if correctly bought

    public Prescription[ ] GetPrescriptions(string searchText);

    public bool SetCollected(string id, bool flag);
  }

}
