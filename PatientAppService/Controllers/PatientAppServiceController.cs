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

namespace PatientAppService
{
  using System;
  using System.Collections.Generic;
  using System.Diagnostics;
  using System.Linq;
  using System.Threading.Tasks;

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;

  [ApiController]
  [Route( "[controller]" )]
  public class PatientAppServiceController : ControllerBase, IPatientAppService
  {
    private readonly ILogger<PatientAppServiceController> logger;
    private PatientAppService patientAppService;

    public PatientAppServiceController( ILogger<PatientAppServiceController> logger )
    {
      this.logger = logger;
      this.patientAppService = new PatientAppService();
    }
    [HttpGet]
    [Route( "GetPrescriptions" )]
    public Prescription[ ] GetPrescriptions(string searchText)
    {
      return this.patientAppService.GetPrescriptions(searchText);
    }

    [HttpPost]
    [Route( "SetCollected" )]
    public bool SetCollected( string id, bool flag )
    {
      return this.patientAppService.SetCollected( id, flag );
    }
    [HttpGet]
    [Route( "GetDrugs" )]
    public Drug[ ] GetDrugs( string searchText)
    {
        return this.patientAppService.GetDrugs(searchText);
    }
    
    [HttpPost]
    [Route("buyDrugs")]
    public bool buyDrugs(string id, int ilosc)
        {
            return patientAppService.buyDrugs(id, ilosc);
        }
  }
}
