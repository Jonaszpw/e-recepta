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
    using System.Text.Json;
    using System.Threading.Tasks;

    public class DrugsService : IDrugsService
    {
        
        private Drug[] drugs;
        private DrugReader reader = new DrugReader("drugs.json");

        public DrugsService()
        {
        }

        private bool searchInDrug(Drug drug, string phrase)
        {
            int number;
            bool isParsable = Int32.TryParse(phrase, out number);
            if (isParsable)
            {
                bool b_id = drug.id.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                bool b_qan = drug.quantity == int.Parse(phrase);
                bool b_price = drug.price == int.Parse(phrase);
                bool b_num = drug.numberOfPills == int.Parse(phrase);
                return b_id || b_qan || b_price || b_num;
            }
            else
            {
                bool b_id = drug.id.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                bool b_name = drug.name.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                bool b_description = drug.description.Contains(phrase, StringComparison.OrdinalIgnoreCase);
                return b_id || b_name || b_description;
            }

        }

        public Drug[] GetDrugs(string searchText)
        {
            drugs = reader.ReadAll();

            if (searchText == null || searchText == "" || searchText == string.Empty || searchText == "wszystkie")
            {
                Drug[] res = new Drug[drugs.Length];
                int i= 0;
                foreach(Drug d in drugs)
                 {
                    res[i] = new Drug(d.id, d.name, d.quantity, d.description, d.price, d.numberOfPills);
                    i++;
                 }


                return res;
                
            }
            return Array.FindAll(drugs, element => searchInDrug(element, searchText));
        }

      

        public bool buyDrugs(string id, int number)
        {
            /*int i = Array.IndexOf(drugs, Array.Find(drugs, element => element.id == id));

            if (i < 0 || number < 0 || drugs[i].quantity < number) return false;

            drugs[i].quantity -= number; //doeasnt remain
            return true;*/

            Drug drug = reader.ReadDrug(id);
            if (drug == null || number < 0 || drug.quantity < number) return false;
            drug.quantity -= number;

            reader.UpdateOne(drug);

            return true;
        }
    }
}
