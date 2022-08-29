using Anchor_Assessment.Data;
using Anchor_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Repositories
{
    public class ValuesRepository:IValuesRepository
    {
        private readonly IDataInterface _dataInterface;

        public ValuesRepository(IDataInterface dataInterface)
        {
            _dataInterface = dataInterface ?? throw new ArgumentNullException(nameof(DataInterface));
        }

        public void addRecord(RecordModel rec)
        {
            _dataInterface.addRecord(rec);
        }

        public void deleteRecord(RecordModel rec)
        {
            _dataInterface.deleteRecord(rec);
        }

        public StatsModel ssAmountOverEntireSet()
        {
            return getSSForDataSet(_dataInterface.getData());
        }
        public StatsModel ssForTypeStockBuy()
        {
            var set = (from data in _dataInterface.getData()
                                    where data.type == "stock_buy"
                                    select data).ToList();
            return getSSForDataSet(set);
        }
        public Dictionary<string, StatsModel> ssByType()
        {
            List<RecordModel> data = _dataInterface.getData();
            List<string> types = data.Select(r => r.type).Distinct().ToList();
            Dictionary<string, StatsModel> result = new Dictionary<string, StatsModel>();
            foreach(string type in types)
            {
                var set = (from d in data
                           where d.type == type
                           select d).ToList();
                result.Add(type, getSSForDataSet(set));
            }
            return result;
        }
        public Dictionary<string, StatsModel> ssByTypeAndQuoteCombination()
        {
            List<RecordModel> data = _dataInterface.getData();
            List<(string, string)> distinctValues = data.Select(r => (r.type, r.quote_currency)).Distinct().ToList();
            Dictionary<string, StatsModel> result = new Dictionary<string, StatsModel>();
            foreach ((string, string) t in distinctValues)
            {
                var set = (from d in data
                           where d.type == t.Item1 && d.quote_currency == t.Item2
                           select d).ToList();
                result.Add($"{t.Item1}|{t.Item2}", getSSForDataSet(set));
            }
            return result;
        }

        private StatsModel getSSForDataSet(List<RecordModel> dataset)
        {
            if (dataset.Count > 0)
            {
                return new StatsModel
                {
                    average = dataset.Average(x => x.quote_currency_amount),
                    max = dataset.Max(x => x.quote_currency_amount),
                    min = dataset.Min(x => x.quote_currency_amount)
                };
            }
            return new StatsModel { average = 0, max = 0, min = 0 };
        }
    }
}
