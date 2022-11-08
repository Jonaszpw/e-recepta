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

namespace DoctorAppService
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

 public class Prescription
  {
    public string Id { get; set; }

    public string DoctorDetails { get; set; }

    public string PatientDetails { get; set; }

    public string Date { get; set; }

    public bool IsCollected { get; set; }

    public string MedicinesIds { get; set; }

    public Prescription( string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds)
    {
        this.Id = id;
        this.DoctorDetails = doctorDetails;
        this.PatientDetails = patientDetails;
        this.Date = date;
        this.IsCollected = isCollected;
        this.MedicinesIds = medicineIds;
    }


  }
}
