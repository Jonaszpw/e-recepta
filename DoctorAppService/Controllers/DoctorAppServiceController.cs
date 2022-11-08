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

namespace DoctorAppService
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
  public class DoctorAppServiceController : ControllerBase, IDoctorAppService
    {
    private readonly ILogger<DoctorAppServiceController> logger;
    private DoctorAppService doctorAppService;

    public DoctorAppServiceController( ILogger<DoctorAppServiceController> logger )
    {
      this.logger = logger;
      this.doctorAppService = new DoctorAppService();
    }
    [HttpGet]
    [Route("GetPrescriptions")]
    public Prescription[ ] GetPrescriptions(string searchText)
    {
      return this.doctorAppService.GetPrescriptions(searchText);
    }

    [HttpPost]
    [Route( "SetCollected" )]
    public bool SetCollected( string id, bool flag )
    {
      return this.doctorAppService.SetCollected( id, flag );
    }
    [HttpPost]
    [Route( "AddPrescription" )]
    public bool AddPrescription(string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds)
    {
       return this.doctorAppService.AddPrescription( id,doctorDetails,patientDetails,date,isCollected,medicineIds );
    }
    [HttpGet]
    [Route( "GetDrugs" )]
    public Drug[ ] GetDrugs( string searchText )
    {
        return this.doctorAppService.GetDrugs(searchText);
    }


  }
}
