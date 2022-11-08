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

namespace PatientApplication2.Utilities
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  public class EmptyEventDispatcher : IEventDispatcher
  {
    #region IEventDispatcher

    public void Dispatch( Action eventAction )
    {
    }
    #endregion
  }
}
