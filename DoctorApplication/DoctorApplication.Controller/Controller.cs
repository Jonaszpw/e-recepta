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

namespace DoctorApplication.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using DoctorApplication.Model;
  using DoctorApplication.Utilities;

  public partial class Controller : PropertyContainerBase, IController
  {
    public IModel Model { get; private set; }

    public Controller( IEventDispatcher dispatcher, IModel model ) : base( dispatcher )
    {
      this.Model = model;

      this.SearchPrescriptionsCommand = new ControllerCommand( this.SearchPrescriptions);

      this.AddPrescriptionCommand = new ControllerCommand(this.AddPrescription);

      this.ShowListCommand = new ControllerCommand( this.ShowList );

      this.GetDrugsCommand = new ControllerCommand(this.GetDrugs);

    }
  }
}
