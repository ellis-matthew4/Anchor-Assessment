using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Anchor_Assessment.Models;
using Anchor_Assessment.Repositories;

namespace Anchor_Assessment.Services
{
    public class ValuesService : IValuesService
    {
        private readonly IValuesRepository _valuesRepository;

        public ValuesService(IValuesRepository valuesRepository)
        {
            _valuesRepository = valuesRepository ?? throw new ArgumentNullException(nameof(ValuesRepository));
        }

        public void addRecord(RecordModel rec)
        {
            _valuesRepository.addRecord(rec);
        }

        public void deleteRecord(RecordModel rec)
        {
            _valuesRepository.deleteRecord(rec);
        }

        public StatsModel ssAmountOverEntireSet()
        {
            return _valuesRepository.ssAmountOverEntireSet();
        }
        public StatsModel ssForTypeStockBuy()
        {
            return _valuesRepository.ssForTypeStockBuy();
        }
        public Dictionary<string, StatsModel> ssByType()
        {
            return _valuesRepository.ssByType();
        }
        public Dictionary<string, StatsModel> ssByTypeAndQuoteCombination()
        {
            return _valuesRepository.ssByTypeAndQuoteCombination();
        }
    }
}
