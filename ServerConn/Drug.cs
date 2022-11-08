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

  public class Drug
  {
        public string id { get; private set; }
        public string name { get; private set; }
        public int quantity { get; set; }
        public string description { get; private set; }
        public double price { get; set; } //in PLN
        public int numberOfPills { get; private set; }

        public Drug() { }

        public Drug( string id ) 
    {
            this.id = id;
    }
    
    public Drug(string id, string name, int quantity, string description, double price, int numberOfPills)
        {
            this.id=id;
            this.name=name;
            this.quantity=quantity;
            this.description=description;
            this.price=price;
            this.numberOfPills=numberOfPills;
             
        }


    public string MyToString()
        {
            string res = "Id: " + id + " name: " + name + " qantity: " + quantity + " description: " + description + " price: " + price + " number of pills: " + numberOfPills;
            return res;
        }
    }
}

   