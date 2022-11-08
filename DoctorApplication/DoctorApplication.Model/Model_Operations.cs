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
            IDoctor doctorClient = DoctorClientFactory.GetDoctorClient( );

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

        public void AddPrescription()
        {
            this.AddPrescriptionTask();

        }

        private void AddPrescriptionTask()
        {
            IDoctor doctorClient = DoctorClientFactory.GetDoctorClient();

            try
            {
                this.Pres.IsCollected = false;
                bool res = doctorClient.AddPrescription(this.Pres);

                //this.PrescriptionList = prescriptions.ToList();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e);
            }
        }


        public void GetDrugs()
        {
            this.GetDrugsTask();
        }

        private void GetDrugsTask()
        {
            IDoctor doctorClient = DoctorClientFactory.GetDoctorClient();

            try
            {
                DrugData[] drugs = doctorClient.GetDrugs(this.SearchText);

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
