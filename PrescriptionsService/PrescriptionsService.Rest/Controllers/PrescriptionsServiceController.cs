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

namespace PrescriptionsService
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
    public class PrescriptionsServiceController : ControllerBase, IPrescriptionsService
    {
        private readonly ILogger<PrescriptionsServiceController> logger;
        private PrescriptionsService prescriptionService;

        public PrescriptionsServiceController(ILogger<PrescriptionsServiceController> logger)
        {
            this.logger = logger;
            this.prescriptionService = new PrescriptionsService();
        }
        [HttpGet]
        [Route("GetPrescriptions")]
        public Prescription[] GetPrescriptions()
        {
            return this.prescriptionService.GetPrescriptions();
        }

        [HttpPost]
        [Route("SetCollected")]
        public bool SetCollected(string id, bool flag)
        {
            return this.prescriptionService.SetCollected(id, flag);
        }
        [HttpPost]
        [Route("AddPrescription")]
       // public bool AddPrescription([FromBody] Prescription prescription)
        public bool AddPrescription(string id, string doctorDetails, string patientDetails, string date, bool isCollected, string medicineIds)
        
        {
            Console.WriteLine(id);
            //return this.prescriptionService.AddPrescription(prescription);
            return this.prescriptionService.AddPrescription(id, doctorDetails, patientDetails, date, isCollected, medicineIds);
        }
    
  }
}
