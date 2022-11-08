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

namespace PatientApplication.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using PatientApplication.Model;
  using PatientApplication.Utilities;

  public partial class Controller : PropertyContainerBase, IController
  {
    public IModel Model { get; private set; }

    public Controller( IEventDispatcher dispatcher, IModel model ) : base( dispatcher )
    {
      this.Model = model;

      this.SearchPrescriptionsCommand = new ControllerCommand( this.SearchPrescriptions);

      this.ShowListCommand = new ControllerCommand( this.ShowList );

      this.ShowMapCommand = new ControllerCommand( this.ShowMap );
    }
  }
}
