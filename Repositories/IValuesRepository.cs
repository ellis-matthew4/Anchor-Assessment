using Anchor_Assessment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Anchor_Assessment.Repositories
{
    public interface IValuesRepository
    {
        public void addRecord(RecordModel rec);
        public void deleteRecord(RecordModel rec);
        public StatsModel ssAmountOverEntireSet();
        public StatsModel ssForTypeStockBuy();
        public Dictionary<string, StatsModel> ssByType();
        public Dictionary<string, StatsModel> ssByTypeAndQuoteCombination();
    }
}
