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

  public partial class Model : IOperations
  {
    public void LoadPrescriptionList( )
    {
      this.LoadPrescriptionsTask( );
  
    }

    private void LoadPrescriptionsTask( )
    {
            IPatient2 doctorClient = Patient2ClientFactory.GetPatient2Client( );

      try
      {
        PrescriptionData[ ] prescriptions = doctorClient.GetPrescriptions( this.SearchText );

        this.PrescriptionList = prescriptions.ToList( );
      }
      catch( Exception e )
      {
        Console.WriteLine( e.Message );
        Console.WriteLine( e );
      }
    }

        public void GetDrugs()
        {
            this.GetDrugsTask();
        }

        private void GetDrugsTask()
        {
            IPatient2 patient2Client = Patient2ClientFactory.GetPatient2Client();

            try
            {
                DrugData[] drugs = patient2Client.GetDrugs(this.SearchText);

                this.DrugsList = drugs.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }


    }
}
