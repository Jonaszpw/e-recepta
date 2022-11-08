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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  using System.ComponentModel;

  public interface IData : INotifyPropertyChanged
  {
    string SearchText { get; set; }

    List<PrescriptionData> PrescriptionList { get; }

    PrescriptionData SelectedPrescription { get; set; }

    List<DrugData> DrugsList { get; }

    }
}
