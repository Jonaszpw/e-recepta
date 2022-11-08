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

  public interface IPatient2
  {
    PrescriptionData[ ] GetPrescriptions( string searchText );

    DrugData[] GetDrugs(string searchText);


    }
}
