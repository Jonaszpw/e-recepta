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

  public class PrescriptionData
  {
    public string Id { get; set; }

    public string DoctorDetails { get; set; }

    public string PatientDetails { get; set; }

    public string Date { get; set; }

    public bool IsCollected { get; set; }

    public List<string> MedicinesIds { get; set; }

  }
}
