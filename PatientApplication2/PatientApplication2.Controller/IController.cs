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

  using System.ComponentModel;
  using System.Windows.Input;

  using PatientApplication2.Model;

  public interface IController : INotifyPropertyChanged
  {
    IModel Model { get; }

    ApplicationState CurrentState { get; }

    ICommand SearchPrescriptionsCommand { get; }

    ICommand GetDrugsCommand { get; }


    Task SearchPrescriptionsAsync( );

    Task GetDrugsAsync();

    }
}
