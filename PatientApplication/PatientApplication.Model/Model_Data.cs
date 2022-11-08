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
  using System.Linq;
  using System.Text;
  using System.Threading.Tasks;

  public partial class Model : IData
  {
    public string SearchText
    {
      get { return this.searchText; }
      set
      {
        this.searchText = value;

        this.RaisePropertyChanged( "SearchText" );
      }
    }
    private string searchText;

    public List<PrescriptionData> PrescriptionList
        {
      get { return this.prescriptionList; }
      private set
      {
        this.prescriptionList = value;

        this.RaisePropertyChanged("PrescriptionsList");
      }
    }
    private List<PrescriptionData> prescriptionList = new List<PrescriptionData>( );

    public PrescriptionData SelectedPrescription
        {
      get { return this.selectedPrescription; }
      set
      {
        this.selectedPrescription = value;

        this.RaisePropertyChanged("SelectedPrescription");
      }
    }
    private PrescriptionData selectedPrescription;
  }
}
