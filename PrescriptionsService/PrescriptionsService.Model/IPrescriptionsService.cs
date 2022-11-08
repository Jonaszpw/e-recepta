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

namespace PrescriptionsService
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public interface IPrescriptionsService
    {
    public Prescription[ ] GetPrescriptions();

    public bool SetCollected(string id, bool flag);

        //public bool AddPrescription(object prescription);
    //public bool AddPrescription(Prescription prescription);

        public bool AddPrescription(string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds);
    }

}
