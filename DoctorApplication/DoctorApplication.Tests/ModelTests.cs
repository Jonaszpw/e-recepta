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

namespace DoctorApplication.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using DoctorApplication.Controller;
  using DoctorApplication.Model;
  using DoctorApplication.Utilities;

  [TestClass]
  public class ModelTests
  {
    [TestMethod]
    public void LoadNodeList_ReadsFromNodeArray_ThereIsOneMatchingNode( )
    {
      IModel model = new Model( new EmptyEventDispatcher( ) );

      string searchText = "wszystkie";

      model.SearchText = searchText;

      model.LoadPrescriptionList( );

      int expectedCount = 8;

      int actualCount = model.PrescriptionList.Count;

      Assert.AreEqual( expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount );
    }
  }
}
