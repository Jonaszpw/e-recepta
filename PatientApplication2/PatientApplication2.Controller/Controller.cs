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

namespace PatientApplication2.Controller
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using PatientApplication2.Model;
  using PatientApplication2.Utilities;

  public partial class Controller : PropertyContainerBase, IController
  {
    public IModel Model { get; private set; }

    public Controller( IEventDispatcher dispatcher, IModel model ) : base( dispatcher )
    {
      this.Model = model;

      this.SearchPrescriptionsCommand = new ControllerCommand( this.SearchPrescriptions);

      this.GetDrugsCommand = new ControllerCommand(this.GetDrugs);

        }
    }
}
