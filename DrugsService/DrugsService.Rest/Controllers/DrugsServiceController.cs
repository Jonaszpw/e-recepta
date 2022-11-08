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

  using Microsoft.AspNetCore.Mvc;
  using Microsoft.Extensions.Logging;

    [ApiController]
    [Route("[controller]")]
    public class DrugsServiceController : ControllerBase, IDrugsService
    {
        private readonly ILogger<DrugsServiceController> logger;
        private DrugsService pharmacy;

        public DrugsServiceController(ILogger<DrugsServiceController> logger)
        {
            this.logger = logger;
            this.pharmacy = new DrugsService();
        }
        
    [HttpGet]
    [Route( "GetDrugs" )]
    public Drug[ ] GetDrugs( string searchText)
    {
        return this.pharmacy.GetDrugs(searchText);
    }
    
    [HttpPost]
    [Route("buyDrugs")]
    public bool buyDrugs(string id, int ilosc)
        {
            return pharmacy.buyDrugs(id, ilosc);
        }
  }
}
