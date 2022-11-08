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

  public interface IDoctor
  {
    PrescriptionData[ ] GetPrescriptions( string searchText );

    bool AddPrescription( PrescriptionData pres );

    DrugData[] GetDrugs(string searchText);

  }
}
