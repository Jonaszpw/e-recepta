namespace PatientAppService
{
    using System;
    using System.IO;
    using System.Text.Json;
    using System.Threading.Tasks;
    using System.Diagnostics;
    using System.Collections.Generic;
    using System.Linq;

    public class DrugReader
    {
        public string file { get; set; }
        public Drug[] drugs;


        public DrugReader() { }
        public DrugReader(string f)
        {
            file = f;
        }

        public Drug[] ReadAll()
        {
            try
            {
                DrugData[] drugsdata = JsonSerializer.Deserialize<DrugData[]>(File.ReadAllText(file));
                drugs = drugsdata.Select(drug => new Drug(drug.id, drug.name, drug.quantity, drug.description, drug.price, drug.numberOfPills)).ToArray();
                return drugs;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
         
            return null;
        }
        public Drug ReadDrug(string id)
        {
            try
            {
                DrugData[] drugsdata = JsonSerializer.Deserialize<DrugData[]>(File.ReadAllText(file));
                drugs = drugsdata.Select(drug => new Drug(drug.id, drug.name, drug.quantity, drug.description, drug.price, drug.numberOfPills)).ToArray(); 
                return Array.Find(drugs, element => element.id == id);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
            return null;
        }

        public void UpdateOne(Drug drug)
        {
            try
            {
                DrugData[] drugsdata = JsonSerializer.Deserialize<DrugData[]>(File.ReadAllText(file));
                drugs = drugsdata.Select(drug => new Drug(drug.id, drug.name, drug.quantity, drug.description, drug.price, drug.numberOfPills)).ToArray();
                int i = Array.IndexOf(drugs, Array.Find(drugs, element => element.id == drug.id));
                drugs[i] = drug;
                string json = JsonSerializer.Serialize(drugs, new JsonSerializerOptions() { WriteIndented = true});
                File.WriteAllText(file, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);

            }
        }
    }
}