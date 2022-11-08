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

namespace PatientApplication2.Tests
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.VisualStudio.TestTools.UnitTesting;

  using PatientApplication2.Controller;
  using PatientApplication2.Model;
  using PatientApplication2.Utilities;

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

      int expectedCount = 5;

      int actualCount = model.PrescriptionList.Count;

      Assert.AreEqual( expectedCount, actualCount, "Prescription count should be {0} and not {1}", expectedCount, actualCount );
    }
  }
}
