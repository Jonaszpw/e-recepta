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

namespace DrugsService
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;


  public static class DataConverter
  {
    public static DrugData ConvertToDrugData( this Drug drug )
    {
      return new DrugData { id=drug.id, name=drug.name, quantity=drug.quantity, description=drug.description, price=drug.price,numberOfPills=drug.numberOfPills };
    }

    public static Drug ConvertToData(DrugData dg )
    {
            return new Drug(dg.id,dg.name,dg.quantity,dg.description,dg.price,dg.numberOfPills);
    }
  }
}
