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

namespace PatientApplication.Model
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;

    public class DrugData
    {
        public string id { get; set; }
        public string name { get; set; }
        public int quantity { get; set; }
        public string description { get; set; }
        public double price { get; set; } //in PLN
        public int numberOfPills { get; set; }

    }
}
