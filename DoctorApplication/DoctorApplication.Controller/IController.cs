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

  using System.ComponentModel;
  using System.Windows.Input;

  using DoctorApplication.Model;

  public interface IController : INotifyPropertyChanged
  {
    IModel Model { get; }

    ApplicationState CurrentState { get; }

    ICommand SearchPrescriptionsCommand { get; }

    ICommand ShowListCommand { get; }

    ICommand GetDrugsCommand { get; }
    ICommand AddPrescriptionCommand { get; set; }


    Task SearchPrescriptionsAsync( );

    Task ShowListAsync( );

    Task AddPrescriptionAsync();

    Task GetDrugsAsync();

    }
}
