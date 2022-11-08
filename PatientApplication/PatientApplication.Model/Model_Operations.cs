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

  public partial class Model : IOperations
  {
    public void LoadPrescriptionList( )
    {
      this.LoadPrescriptionsTask( );
  
    }

    private void LoadPrescriptionsTask( )
    {
            IPatient patientClient = PatientClientFactory.GetPatientClient( );

      try
      {
        PrescriptionData[ ] prescriptions = patientClient.GetPrescriptions( this.SearchText );

        this.PrescriptionList = prescriptions.ToList( );
      }
      catch( Exception e )
      {
        Console.WriteLine( e.Message );
        Console.WriteLine( e );
      }
    }
  }
}
