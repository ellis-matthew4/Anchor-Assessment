using Anchor_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Anchor_Assessment.Data
{
    public class DataInterface : IDataInterface
    {
        private List<RecordModel> records;
        private string dataLocation = "./Data/original.json";

        public DataInterface()
        {
            string raw = System.IO.File.ReadAllText(dataLocation);
            List<List<dynamic>> rawData = JsonConvert.DeserializeObject<List<List<dynamic>>>(raw);

            records = new List<RecordModel>();
            foreach (List<dynamic> d in rawData)
            {
                records.Add(new RecordModel
                {
                    type = d[0],
                    status = d[1],
                    quote_currency = d[2],
                    quote_currency_amount = d[3]
                });
            }
            save();
        }

        public List<RecordModel> getData()
        {
            return records;
        }

        public void addRecord(RecordModel rec)
        {
            records.Add(rec);
            save();
        }

        public void deleteRecord(RecordModel rec)
        {
            records.Remove(rec);
            save();
        }

        private void save()
        {
            List<List<dynamic>> preserialized = new List<List<dynamic>>();
            foreach(RecordModel rec in records)
            {
                preserialized.Add(new List<dynamic>
                {
                    rec.type,
                    rec.status,
                    rec.quote_currency,
                    rec.quote_currency_amount
                });
            }
            var serialized = new string[] { JsonConvert.SerializeObject(preserialized) };
            System.IO.File.WriteAllLines(dataLocation, serialized);
        }
    }
}
