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

  using System.ComponentModel;
  using System.Windows.Input;

  using PatientApplication.Model;

  public interface IController : INotifyPropertyChanged
  {
    IModel Model { get; }

    ApplicationState CurrentState { get; }

    ICommand SearchPrescriptionsCommand { get; }

    ICommand ShowListCommand { get; }

    ICommand ShowMapCommand { get; }

    Task SearchPrescriptionsAsync( );

    Task ShowListAsync( );

    Task ShowMapAsync( );
  }
}
